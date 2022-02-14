using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Common.ViewModels;
using GameTournament.Application.Posts.Commands;
using GameTournament.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTournament.Application.Posts.Handlers
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, ResultViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public CreatePostCommandHandler(IUnitOfWork unitOfWork,
            ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        public async Task<ResultViewModel> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            // Get the input cover image
            var coverImage = await _unitOfWork.Documents.GetByGuidAsync(request.CoverImageGuid);

            // Check if the post's input cover image exist
            if (coverImage == null)
            {
                string[] errors = new string[] { "تصویر کاور مورد نظر یافت نشد" };
                return ResultViewModel.Failure(errors);
            }

            // Create a new post

            var post = new Post
            {
                UserId = _currentUserService.UserId,
                CoverDocumentId = coverImage.DocumentId,
                Title = request.Title,
                Abstract = request.Abstract,
                Description = request.Description
            };

            _unitOfWork.Posts.Insert(post);

            // Create post categories
            foreach (var categoryGuid in request.Categories)
            {
                // Get the category
                var category = await _unitOfWork.Categories.GetByGuidAsync(categoryGuid);

                // Check if the category exist
                if (category == null)
                {
                    string[] errors = new string[] { "دسته بندی با آیدی " + categoryGuid + " یافت نشد" };
                    return ResultViewModel.Failure(errors);
                };

                // Create a new post category

                var postCategory = new PostCategory()
                {
                    Post = post,
                    CategoryId = category.CategoryId
                };

                _unitOfWork.PostCategories.Insert(postCategory);
            }

            // Commit the changes
            await _unitOfWork.CommitAsync();

            return ResultViewModel.Success();
        }
    }
}
