using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameTournament.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(string to, string subject, string body);
    }
}
