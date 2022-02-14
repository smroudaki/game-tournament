using GameTournament.Application.Common.Interfaces;
using GameTournament.Domain.Enums;
using Kavenegar;
using Kavenegar.Core.Exceptions;
using Kavenegar.Core.Models;
using Kavenegar.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameTournament.Infrastructure.Services
{
    public class SmsService : ISmsService
    {
        private readonly string _apiKey;

        public SmsService(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<object> SendAdvertisingAsync(string sender,
            string receptor,
            string message)
        {
            try
            {
                var kavenegar = new KavenegarApi(_apiKey);
                var result = await kavenegar.Send(sender,
                    receptor,
                    message);

                return result;
            }
            catch (ApiException ex)
            {
                return ex.Message;
            }
            catch (HttpException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> SendServiceableAsync(string template,
            string receptor,
            string token,
            string token2,
            string token3,
            string token10,
            string token20)
        {
            try
            {
                var kavenegar = new KavenegarApi(_apiKey);
                var result = await kavenegar.VerifyLookup(receptor,
                    token,
                    token2,
                    token3,
                    token10,
                    token20,
                    template,
                    VerifyLookupType.Sms);

                return result;
            }
            catch (ApiException ex)
            {
                return ex.Message;
            }
            catch (HttpException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
