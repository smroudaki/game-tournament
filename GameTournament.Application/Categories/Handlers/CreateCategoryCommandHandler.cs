using GameTournament.Application.Categories.Commands;
using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Common.ViewModels;
using GameTournament.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTournament.Application.Categories.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ResultViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            int? parentCategoryId = null;

            if (request.ParentCategoryGuid != null)
            {
                // Get the category
                var parentCategory = await _unitOfWork.Categories.GetByGuidAsync(request.ParentCategoryGuid.Value);

                // Check if the category exist
                if (parentCategory == null)
                {
                    string[] errors = new string[] { "دسته بندی مورد نظر یافت نشد" };
                    return ResultViewModel.Failure(errors);
                }

                parentCategoryId = parentCategory.CategoryId;
            }

            // Create a new category

            var category = new Category
            {
                ParentCategoryId = parentCategoryId,
                Title = request.Title
            };

            _unitOfWork.Categories.Insert(category);

            // Commit the changes
            await _unitOfWork.CommitAsync();

            return ResultViewModel.Success();
        }
    }
}
