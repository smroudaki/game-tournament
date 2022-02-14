using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Common.ViewModels;
using GameTournament.Application.Users.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTournament.Application.Users.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            // Get the user
            var user = await _unitOfWork.Users.GetByGuidAsync(request.UserGuid);

            // Check if the user exist
            if (user == null)
            {
                string[] errors = new string[] { "کاربر مورد نظر یافت نشد" };
                return ResultViewModel.Failure(errors);
            }

            // Delete the user
            user.IsDelete = true;
            _unitOfWork.Users.Update(user);

            // Commit the changes
            await _unitOfWork.CommitAsync();

            return ResultViewModel.Success();
        }
    }
}
