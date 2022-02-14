using GameTournament.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZarinpalSandbox;

namespace GameTournament.Infrastructure.Services
{
    public class ZarinPalService : IZarinPalService
    {
        private readonly string _applicationUrl;
        private readonly string _merchantId;

        public ZarinPalService(IConfiguration configuration)
        {
            _applicationUrl = configuration.GetValue<string>("ApplicationUrl").ToString();
            _merchantId = configuration.GetValue<string>("ZarinPalMerchantId").ToString();
        }

        public async Task<string> Request(Guid paymentGuid, long amount, string email, string mobile)
        {
            string callbackUrl = $"{_applicationUrl}/Payment/Verify/{paymentGuid}";
            string description = "عملیات پرداخت";

            var payment = new Payment(/*_merchantId, */(int)amount);
            var request = await payment.PaymentRequest(description, callbackUrl, email, mobile);

            return request.Status == 100 ? $"https://sandbox.zarinpal.com/pg/StartPay/{request.Authority}" : null;
        }

        public async Task<(bool, long)> Verify(long amount, string authority)
        {
            var payment = new Payment(/*_merchantId, */(int)amount);
            var verification = await payment.Verification(authority);

            return (verification.Status == 100, verification.RefId);
        }
    }
}
