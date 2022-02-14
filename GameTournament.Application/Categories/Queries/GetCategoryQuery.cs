using GameTournament.Application.Categories.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Categories.Queries
{
    public class GetCategoryQuery : IRequest<CategoryViewModel>
    {
        public Guid CategoryGuid { get; set; }
        public bool IncludeChildren { get; set; }
    }
}
