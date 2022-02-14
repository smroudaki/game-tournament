using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameTournament.Application.Common.Interfaces
{
    public interface IZarinPalService
    {
        Task<string> Request(Guid paymentGuid, long amount, string email, string mobile);
        Task<(bool, long)> Verify(long amount, string authority);
    }
}
