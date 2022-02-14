using GameTournament.Application.Common.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GameTournament.Application.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest<ResultViewModel>
    {
        [JsonIgnore]
        public Guid CategoryGuid { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
