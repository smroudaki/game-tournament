using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GameTournament.Application.Documents.Commands
{
    public class FilepondUploadCommand : IRequest<Guid>
    {
        public IFormFile File { get; set; }
    }
}
