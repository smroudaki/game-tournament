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
    public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, PaymentViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPaymentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaymentViewModel> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {
            // Get payment
            var payment = await _unitOfWork.Payments
                .Get(p => p.PaymentGuid.Equals(request.PaymentGuid), null, "User")
                .Select(p => new PaymentDto
                {
                    PaymentGuid = p.PaymentGuid,
                    User = p.User.FirstName + " " + p.User.LastName,
                    Cost = p.Cost,
                    Discount = p.Discount,
                    TrackingToken = p.TrackingToken,
                    IsSuccessful = p.IsSuccessful,
                    CreationDate = p.CreationDate,

                }).SingleOrDefaultAsync();

            // Check if the payment exist
            if (payment == null)
            {
                string[] errors = new string[] { "پرداخت مورد نظر یافت نشد" };
                return new PaymentViewModel(false, errors);
            }

            return new PaymentViewModel(true, new string[] { }) { Payment = payment };
        }
    }
}
