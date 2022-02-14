using GameTournament.Application.Common.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<ResultViewModel>
    {
        public Guid? ParentCategoryGuid { get; set; }
        public string Title { get; set; }
    }
}
