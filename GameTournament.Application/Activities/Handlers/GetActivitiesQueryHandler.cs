using GameTournament.Application.Activities.Queries;
using GameTournament.Application.Activities.ViewModels;
using GameTournament.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTournament.Application.Activities.Handlers
{
    public class GetActivitiesQueryHandler : IRequestHandler<GetActivitiesQuery, ActivitiesViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetActivitiesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActivitiesViewModel> Handle(GetActivitiesQuery request, CancellationToken cancellationToken)
        {
            // Get activities query
            var activities = await _unitOfWork.Activities
                .Get(null, a => a.OrderBy(a => a.Name))
                .Select(a => new ActivityDto
                {
                    ActivityGuid = a.ActivityGuid,
                    Name = a.Name,
                    IsActive = a.IsActive,
                    CreationDate = a.CreationDate,
                    ModifiedDate = a.ModifiedDate

                }).ToListAsync();

            // Check if there're any provinces exist
            if (activities.Count <= 0)
            {
                string[] errors = new string[] { "موردی یافت نشد" };
                return new ActivitiesViewModel(false, errors);
            }

            return new ActivitiesViewModel(true, new string[] { }) { Activities = activities };
        }
    }
}
