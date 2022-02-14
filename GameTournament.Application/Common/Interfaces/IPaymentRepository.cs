using GameTournament.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameTournament.Application.Common.Interfaces
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<Payment> GetByGuidAsync(Guid paymentGuid);
    }
}
