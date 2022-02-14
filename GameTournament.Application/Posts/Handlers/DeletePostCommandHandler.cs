using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Common.ViewModels;
using GameTournament.Application.Posts.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTournament.Application.Posts.Handlers
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, ResultViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            // Get the post
            var post = await _unitOfWork.Posts.GetByGuidAsync(request.PostGuid);

            // Check if the post exist
            if (post == null)
            {
                string[] errors = new string[] { "پست مورد نظر یافت نشد" };
                return ResultViewModel.Failure(errors);
            }

            // Delete the post
            post.IsDelete = true;
            _unitOfWork.Posts.Update(post);

            // Commit the changes
            await _unitOfWork.CommitAsync();

            return ResultViewModel.Success();
        }
    }
}
