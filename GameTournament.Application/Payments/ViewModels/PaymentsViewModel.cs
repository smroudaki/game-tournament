using GameTournament.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Payments.ViewModels
{
    public class PaymentsViewModel : ResultViewModel
    {
        public PaymentsViewModel(bool succeeded, IEnumerable<string> errors)
                  : base(succeeded, errors)
        {
        }

        public List<PaymentDto> Payments { get; set; }
    }
}
