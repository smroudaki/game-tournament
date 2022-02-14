using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Provinces.Queries;
using GameTournament.Application.Provinces.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTournament.Application.Provinces.Handlers
{
    public class GetProvincesQueryHandler : IRequestHandler<GetProvincesQuery, ProvincesViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProvincesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProvincesViewModel> Handle(GetProvincesQuery request, CancellationToken cancellationToken)
        {
            // Get provinces query
            var provinces = await _unitOfWork.Provinces
                .Get(null, p => p.OrderBy(p => p.Name))
                .Select(p => new ProvinceDto
                {
                    ProvinceGuid = p.ProvinceGuid,
                    Name = p.Name

                }).ToListAsync();

            // Check if there're any provinces exist
            if (provinces.Count <= 0)
            {
                string[] errors = new string[] { "موردی یافت نشد" };
                return new ProvincesViewModel(false, errors);
            }

            return new ProvincesViewModel(true, new string[] { }) { Provinces = provinces };
        }
    }
}
