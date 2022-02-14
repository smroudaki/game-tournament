using GameTournament.Application.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Payments.ViewModels
{
    public class PaymentViewModel : ResultViewModel
    {
        public PaymentViewModel(bool succeeded, IEnumerable<string> errors)
               : base(succeeded, errors)
        {
        }

        public PaymentDto Payment { get; set; }
    }

    public class PaymentDto
    {
        public Guid PaymentGuid { get; set; }
        public string User { get; set; }
        public long Cost { get; set; }
        public long Discount { get; set; }
        public string TrackingToken { get; set; }
        public bool IsSuccessful { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
