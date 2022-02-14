using GameTournament.Application.Common.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTournament.Application.Users.ViewModels
{
    public class AuthenticateViewModel
    {
        internal AuthenticateViewModel(bool succeeded,
            IEnumerable<string> errors,
            string token,
            string expireDate)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
            Token = token;
            ExpireDate = expireDate;
        }

        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Token { get; set; }
        public string ExpireDate { get; set; }

        public static AuthenticateViewModel Success(string token,
            string expireDate)
        {
            return new AuthenticateViewModel(true,
                new string[] { },
                token,
                expireDate);
        }

        public static AuthenticateViewModel Failure(IEnumerable<string> errors)
        {
            return new AuthenticateViewModel(false,
                errors,
                null,
                null);
        }
    }
}
