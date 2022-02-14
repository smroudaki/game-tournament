using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Common.ViewModels;
using GameTournament.Application.Payments.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTournament.Application.Payments.Handlers
{
    public class VerifyPaymentCommandHandler : IRequestHandler<VerifyPaymentCommand, ResultViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;
        private readonly IZarinPalService _zarinPalService;

        public VerifyPaymentCommandHandler(IUnitOfWork unitOfWork,
            ICurrentUserService currentUserService,
            IZarinPalService zarinPalService)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
            _zarinPalService = zarinPalService;
        }

        public async Task<ResultViewModel> Handle(VerifyPaymentCommand request, CancellationToken cancellationToken)
        {
            // Get payment
            var payment = await _unitOfWork.Payments.GetByGuidAsync(request.PaymentGuid);

            // Check if the payment's exist
            if (payment == null)
            {
                string[] errors = new string[] { "پرداخت مورد نظر یافت نشد" };
                return ResultViewModel.Failure(errors);
            }

            // Verify the payment from ZarinPal
            (bool, long) res = await _zarinPalService.Verify((int)payment.Cost, request.Authority);

            // Check if the payment's verified
            if (!res.Item1)
            {
                string[] errors = new string[] { "پرداخت موفق نبوده است" };
                return ResultViewModel.Failure(errors);
            }

            // Update the payment
            payment.IsSuccessful = true;
            payment.TrackingToken = res.Item2.ToString();

            // Commit the changes
            await _unitOfWork.CommitAsync();

            return ResultViewModel.Success();
        }
    }
}
