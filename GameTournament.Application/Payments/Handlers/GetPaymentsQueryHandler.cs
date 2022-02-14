using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Payments.Queries;
using GameTournament.Application.Payments.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTournament.Application.Payments.Handlers
{
    public class GetPaymentsQueryHandler : IRequestHandler<GetPaymentsQuery, PaymentsViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPaymentsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaymentsViewModel> Handle(GetPaymentsQuery request, CancellationToken cancellationToken)
        {
            // Get payments
            var payments = await _unitOfWork.Payments
                .Get(null, p => p.OrderByDescending(u => u.CreationDate), "User")
                .Select(p => new PaymentDto
                {
                    PaymentGuid = p.PaymentGuid,
                    User = p.User.FirstName + " " + p.User.LastName,
                    Cost = p.Cost,
                    Discount = p.Discount,
                    TrackingToken = p.TrackingToken,
                    IsSuccessful = p.IsSuccessful,
                    CreationDate = p.CreationDate,

                }).ToListAsync();

            // Check if there're any payments exist
            if (payments.Count <= 0)
            {
                string[] errors = new string[] { "موردی یافت نشد" };
                return new PaymentsViewModel(false, errors);
            }

            return new PaymentsViewModel(true, new string[] { }) { Payments = payments };
        }
    }
}
