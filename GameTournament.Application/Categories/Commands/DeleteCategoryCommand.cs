using GameTournament.Application.Common.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest<ResultViewModel>
    {
        public Guid CategoryGuid { get; set; }
    }
}
