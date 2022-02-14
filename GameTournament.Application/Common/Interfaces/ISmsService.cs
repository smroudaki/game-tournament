using GameTournament.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameTournament.Application.Common.Interfaces
{
    public interface ISmsService
    {
        Task<object> SendServiceableAsync(
            string template,
            string receptor,
            string token = "",
            string token2 = "",
            string token3 = "",
            string token10 = "",
            string token20 = "");
        Task<object> SendAdvertisingAsync(
            string sender,
            string receptor,
            string message);
    }
}
