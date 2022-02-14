using GameTournament.Application.Provinces.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Provinces.Queries
{
    public class GetProvincesQuery : IRequest<ProvincesViewModel>
    {
    }
}
