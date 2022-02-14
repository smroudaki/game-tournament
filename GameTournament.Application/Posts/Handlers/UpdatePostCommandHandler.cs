using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Common.ViewModels;
using GameTournament.Application.Posts.Commands;
using GameTournament.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTournament.Application.Posts.Handlers
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, ResultViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _uploadFolderName;

        public UpdatePostCommandHandler(IUnitOfWork unitOfWork,
            IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _uploadFolderName = configuration.GetValue<string>("UploadFolderName").ToString();
        }

        public async Task<ResultViewModel> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            // Get the post
            var post = await _unitOfWork.Posts.GetByGuidAsync(request.PostGuid);

            // Check if the post exist
            if (post == null)
            {
                string[] errors = new string[] { "پست مورد نظر یافت نشد" };
                return ResultViewModel.Failure(errors);
            }

            // Update post

            // Get the post's input cover image
            var coverImage = await _unitOfWork.Documents.GetByGuidAsync(request.CoverImageGuid);

            // Check if the post's input cover image exist
            if (coverImage == null)
            {
                string[] errors = new string[] { "تصویر کاور مورد نظر یافت نشد" };
                return ResultViewModel.Failure(errors);
            }

            if (post.CoverDocumentId != coverImage.DocumentId)
            {
                // Get the post's old cover image
                var oldDocument = await _unitOfWork.Documents.GetByIdAsync(post.CoverDocumentId);

                // Update the post's cover image
                post.CoverDocumentId = coverImage.DocumentId;

                // Delete the post's old cover image
                DeleteDocument(oldDocument);
            }

            post.Title = request.Title;
            post.Abstract = request.Abstract;
            post.Description = request.Description;
            post.IsShow = request.IsShow;
            post.ModifiedDate = DateTime.Now;

            _unitOfWork.Posts.Update(post);

            // Get post's old categories
            var oldCategories = await _unitOfWork.PostCategories
                .Get(pc => pc.PostId.Equals(post.PostId))
                .ToListAsync();

            // Delete post's old categories
            foreach (var oldCategory in oldCategories)
            {
                _unitOfWork.PostCategories.Delete(oldCategory);
            }

            // Create post categories
            foreach (var categoryGuid in request.Categories)
            {
                // Get the category
                var category = await _unitOfWork.Categories.GetByGuidAsync(categoryGuid);

                // Check if the category exist
                if (category == null)
                {
                    string[] errors = new string[] { "دسته بندی با آیدی " + categoryGuid + " یافت نشد" };
                    return ResultViewModel.Failure(errors);
                };

                // Create a new post category

                var postCategory = new PostCategory()
                {
                    Post = post,
                    CategoryId = category.CategoryId
                };

                _unitOfWork.PostCategories.Insert(postCategory);
            }

            // Commit the changes
            await _unitOfWork.CommitAsync();

            return ResultViewModel.Success();
        }

        #region Helpers Methods

        private void DeleteDocument(Document oldDocument)
        {
            // Get the upload folder name index
            var uploadFolderNameIndex = oldDocument.Path.IndexOf(_uploadFolderName);

            // Get the file's relative path
            var relativePath = oldDocument.Path.Substring(uploadFolderNameIndex);

            // Get the current directory
            var currentDirectory = Directory.GetCurrentDirectory();

            // Get web root path
            string webRootPath = Path.Combine(currentDirectory, "wwwroot");

            // Get the file's path
            var path = Path.Combine(currentDirectory, webRootPath, relativePath);

            // Check if the physical file exist
            if (File.Exists(path))
            {
                // Delete the physical file
                File.Delete(path);
            }

            // Delete the file from database
            _unitOfWork.Documents.Delete(oldDocument);
        }

        #endregion
    }
}
