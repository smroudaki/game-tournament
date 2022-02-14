using GameTournament.Application.Common.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Posts.Commands
{
    public class DeletePostCommand : IRequest<ResultViewModel>
    {
        public Guid PostGuid { get; set; }
    }
}
