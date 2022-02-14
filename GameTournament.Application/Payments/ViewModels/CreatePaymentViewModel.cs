using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTournament.Application.Payments.ViewModels
{
    public class CreatePaymentViewModel
    {
        internal CreatePaymentViewModel(bool succeeded,
            IEnumerable<string> errors,
            string url)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
            Url = url;
        }

        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Url { get; set; }

        public static CreatePaymentViewModel Success(string url)
        {
            return new CreatePaymentViewModel(true,
                new string[] { },
                url);
        }

        public static CreatePaymentViewModel Failure(IEnumerable<string> errors)
        {
            return new CreatePaymentViewModel(false,
                errors,
                null);
        }
    }
}
