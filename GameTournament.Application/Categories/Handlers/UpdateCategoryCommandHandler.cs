using GameTournament.Application.Categories.Commands;
using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Common.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTournament.Application.Categories.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ResultViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            // Get the category
            var category = await _unitOfWork.Categories.GetByGuidAsync(request.CategoryGuid);

            // Check if the category exist
            if (category == null)
            {
                string[] errors = new string[] { "دسته بندی مورد نظر یافت نشد" };
                return ResultViewModel.Failure(errors);
            }

            // Update category

            category.Title = request.Title;
            category.IsActive = request.IsActive;
            category.ModifiedDate = DateTime.Now;

            _unitOfWork.Categories.Update(category);

            // Commit the changes
            await _unitOfWork.CommitAsync();

            return ResultViewModel.Success();
        }
    }
}
