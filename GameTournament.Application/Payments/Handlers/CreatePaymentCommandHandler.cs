using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Common.ViewModels;
using GameTournament.Application.Payments.Commands;
using GameTournament.Application.Payments.ViewModels;
using GameTournament.Domain.Entities;
using GameTournament.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTournament.Application.Payments.Handlers
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, CreatePaymentViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;
        private readonly IZarinPalService _zarinPalService;

        public CreatePaymentCommandHandler(IUnitOfWork unitOfWork,
            ICurrentUserService currentUserService,
            IZarinPalService zarinPalService)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
            _zarinPalService = zarinPalService;
        }

        public async Task<CreatePaymentViewModel> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            // Create a new payment

            var payment = new Payment
            {
                UserId = _currentUserService.UserId,
                Cost = 1000,
                Discount = 0
            };

            _unitOfWork.Payments.Insert(payment);

            // Commit the changes
            await _unitOfWork.CommitAsync();

            // Send request to ZarinPal
            string paymentUrl = await _zarinPalService.Request(payment.PaymentGuid,
                payment.Cost,
                _currentUserService.Email,
                _currentUserService.PhoneNumber);

            // Check if the sent request was successful
            if (paymentUrl == null)
            {
                string[] errors = new string[] { "اتصال به درگاه پرداخت با مشکل مواجه شد" };
                return CreatePaymentViewModel.Failure(errors);
            };

            return CreatePaymentViewModel.Success(paymentUrl);
        }
    }
}
