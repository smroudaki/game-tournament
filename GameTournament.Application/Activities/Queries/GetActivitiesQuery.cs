using GameTournament.Application.Activities.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Activities.Queries
{
    public class GetActivitiesQuery : IRequest<ActivitiesViewModel>
    {
    }
}
