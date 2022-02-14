using GameTournament.Application.Payments.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Payments.Queries
{
    public class GetPaymentQuery : IRequest<PaymentViewModel>
    {
        public Guid PaymentGuid { get; set; }
    }
}
