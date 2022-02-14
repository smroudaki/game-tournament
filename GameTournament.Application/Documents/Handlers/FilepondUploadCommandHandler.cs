using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Documents.Commands;
using GameTournament.Domain.Entities;
using GameTournament.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTournament.Application.Documents.Handlers
{
    public class FilepondUploadCommandHandler : IRequestHandler<FilepondUploadCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _applicationUrl;
        private readonly string _uploadFolderName;

        public FilepondUploadCommandHandler(IUnitOfWork unitOfWork,
            IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _applicationUrl = configuration.GetValue<string>("ApplicationUrl").ToString();
            _uploadFolderName = configuration.GetValue<string>("UploadFolderName").ToString();
        }

        public async Task<Guid> Handle(FilepondUploadCommand request, CancellationToken cancellationToken)
        {
            DocumentType documentType;

            // Check if the file's extension is valid
            switch (request.File.ContentType)
            {
                case "image/png":
                    documentType = DocumentType.PNG;
                    break;
                case "image/jpg":
                    documentType = DocumentType.JPG;
                    break;
                case "image/jpeg":
                    documentType = DocumentType.JPEG;
                    break;
                default:
                    return Guid.Empty;
            }

            // Get the file name
            var fileName = request.File.FileName;

            // Get the last index of dot to specify its extension
            var lastDotIndex = fileName.LastIndexOf('.');

            // Get the file's extension
            var extention = fileName.Substring(lastDotIndex);

            // Set the file's new name
            var newFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + extention;

            // Get the current directory
            var currentDirectory = Directory.GetCurrentDirectory();

            // Get web root path
            string webRootPath = Path.Combine(currentDirectory, "wwwroot");

            // Get the file's path
            var path = Path.Combine(currentDirectory, webRootPath, _uploadFolderName, newFileName);

            // Get the file's stream
            var stream = new FileStream(path, FileMode.Create);

            // Copy file to the specified location
            await request.File.CopyToAsync(stream);

            // Set the file's path to save into database
            var documentPath = Path.Combine(_applicationUrl, _uploadFolderName, newFileName);

            // Create a new document

            var document = new Document
            {
                Path = documentPath,
                FileName = newFileName,
                Type = documentType,
                Size = request.File.Length
            };

            _unitOfWork.Documents.Insert(document);

            // Commit the changes
            await _unitOfWork.CommitAsync();

            return document.DocumentGuid;
        }
    }
}
