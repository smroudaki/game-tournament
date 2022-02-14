using GameTournament.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameTournament.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IUserTokenRepository UserTokens { get; }
        IDocumentRepository Documents { get; }
        ICategoryRepository Categories { get; }
        IPaymentRepository Payments { get; }
        IPostRepository Posts { get; }
        IPostCategoryRepository PostCategories { get; }
        IProvinceRepository Provinces { get; }
        IActivityRepository Activities { get; }
        Task CommitAsync();
    }
}
