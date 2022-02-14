using GameTournament.Application.Common.Interfaces;
using GameTournament.Domain.Entities;
using GameTournament.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameTournament.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly GameTournamentTournamentContext _context;
        private IUserRepository _userRepository;
        private IDocumentRepository _documentRepository;
        private ICategoryRepository _categoryRepository;
        private IPaymentRepository _paymentRepository;
        private IPostRepository _postRepository;
        private IPostCategoryRepository _postCategoryRepository;
        private IUserTokenRepository _userTokenRepository;
        private IProvinceRepository _provinceRepository;
        private IActivityRepository _activityRepository;

        public UnitOfWork(GameTournamentTournamentContext context)
        {
            _context = context;
        }

        public IUserRepository Users
        {
            get
            {
                _userRepository ??= new UserRepository(_context);
                return _userRepository;
            }
        }

        public IUserTokenRepository UserTokens
        {
            get
            {
                _userTokenRepository ??= new UserTokenRepository(_context);
                return _userTokenRepository;
            }
        }

        public ICategoryRepository Categories
        {
            get
            {
                _categoryRepository ??= new CategoryRepository(_context);
                return _categoryRepository;
            }
        }

        public IPaymentRepository Payments
        {
            get
            {
                _paymentRepository ??= new PaymentRepository(_context);
                return _paymentRepository;
            }
        }

        public IPostRepository Posts
        {
            get
            {
                _postRepository ??= new PostRepository(_context);
                return _postRepository;
            }
        }

        public IPostCategoryRepository PostCategories
        {
            get
            {
                _postCategoryRepository ??= new PostCategoryRepository(_context);
                return _postCategoryRepository;
            }
        }

        public IProvinceRepository Provinces
        {
            get
            {
                _provinceRepository ??= new ProvinceRepository(_context);
                return _provinceRepository;
            }
        }

        public IDocumentRepository Documents
        {
            get
            {
                _documentRepository ??= new DocumentRepository(_context);
                return _documentRepository;
            }
        }

        public IActivityRepository Activities
        {
            get
            {
                _activityRepository ??= new ActivityRepository(_context);
                return _activityRepository;
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
