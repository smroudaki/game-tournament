using GameTournament.Application.Common.Interfaces;
using GameTournament.Domain.Entities;
using GameTournament.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameTournament.Infrastructure.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(GameTournamentTournamentContext context)
               : base(context)
        {
        }

        public async Task<Payment> GetByGuidAsync(Guid paymentGuid)
        {
            return await _context.Payment
                .SingleOrDefaultAsync(u => u.PaymentGuid.Equals(paymentGuid));
        }
    }
}
