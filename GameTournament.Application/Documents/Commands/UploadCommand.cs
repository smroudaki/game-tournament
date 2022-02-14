using GameTournament.Application.Documents.ViewModels;
using GameTournament.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GameTournament.Application.Documents.Commands
{
    public class UploadCommand : IRequest<UploadViewModel>
    {
        public IFormFile File { get; set; }
    }
}
