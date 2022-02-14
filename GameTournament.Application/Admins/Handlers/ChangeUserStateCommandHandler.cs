using GameTournament.Application.Admins.Commands;
using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Common.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTournament.Application.Admins.Handlers
{
    public class ChangeUserStateCommandHandler : IRequestHandler<ChangeUserStateCommand, ResultViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangeUserStateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel> Handle(ChangeUserStateCommand request, CancellationToken cancellationToken)
        {
            // Get the user
            var user = await _unitOfWork.Users.GetByGuidAsync(request.UserGuid);

            // Check if the user exist
            if (user == null)
            {
                string[] errors = new string[] { "کاربر مورد نظر یافت نشد" };
                return ResultViewModel.Failure(errors);
            }

            // Update the user's account state
            user.AccountState = request.AccountState;
            user.ModifiedDate = DateTime.Now;

            _unitOfWork.Users.Update(user);

            // Commit the changes
            await _unitOfWork.CommitAsync();

            return ResultViewModel.Success();
        }
    }
}
