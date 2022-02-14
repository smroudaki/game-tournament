using GameTournament.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GameTournament.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public Guid UserGuid { get; }
        public int UserId { get; }
        public string PhoneNumber { get; }
        public string Email { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext != null &&
                httpContextAccessor.HttpContext.User != null &&
                httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                ClaimsPrincipal claimsPrincipal = httpContextAccessor.HttpContext.User;

                // Get the current user's info
                string userGuid = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
                string userId = claimsPrincipal.FindFirstValue(ClaimTypes.Name);
                string phoneNumber = claimsPrincipal.FindFirstValue(ClaimTypes.MobilePhone);
                string email = claimsPrincipal.FindFirstValue(ClaimTypes.Email);

                // Set the current user's info
                UserGuid = Guid.Parse(userGuid);
                UserId = Convert.ToInt32(userId);
                PhoneNumber = phoneNumber;
                Email = email;
            }
        }
    }
}
