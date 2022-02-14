using GameTournament.Application.Categories.Commands;
using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Common.ViewModels;
using GameTournament.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTournament.Application.Categories.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ResultViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            // Get all the categories
            var categories = await _unitOfWork.Categories.Get().ToListAsync();

            // Check if there're any parent categories
            if (categories.Count <= 0)
            {
                string[] errors = new string[] { "موردی یافت نشد" };
                return new ResultViewModel(false, errors);
            };

            // Get the category
            var category = categories
                .Where(x => x.CategoryGuid.Equals(request.CategoryGuid))
                .SingleOrDefault();

            // Check if the category exist
            if (category == null)
            {
                string[] errors = new string[] { "دسته بندی مورد نظر یافت نشد" };
                return new ResultViewModel(false, errors);
            }

            // Delete the category
            category.IsDelete = true;
            _unitOfWork.Categories.Update(category);

            int deletedRecordsCount = 1;

            deletedRecordsCount = await RemoveCategoryChildren(categories, category, deletedRecordsCount);

            await _unitOfWork.CommitAsync();

            return ResultViewModel.Success();
        }

        #region Helper Methods

        //private async Task<int> RemoveCategory(Guid categoryGuid)
        //{
        //    // Get all the categories
        //    var categories = await _unitOfWork.Categories.Get().ToListAsync();

        //    // Check if there're any parent categories
        //    if (categories.Count <= 0)
        //    {
        //        return -1;
        //    };

        //    // Get the category
        //    var category = categories
        //        .Where(x => x.CategoryGuid.Equals(categoryGuid))
        //        .SingleOrDefault();

        //    // Check if the category exist
        //    if (category == null)
        //    {
        //        return -2;
        //    }

        //    // Delete the category
        //    category.IsDelete = true;
        //    _unitOfWork.Categories.Update(category);

        //    int deletedRecordsCount = 1;

        //    deletedRecordsCount = await RemoveCategoryChildren(categories, category, deletedRecordsCount);

        //    await _unitOfWork.CommitAsync();

        //    return 1;
        //}

        private async Task<int> RemoveCategoryChildren(List<Category> categories, Category category, int deletedRecordsCount)
        {
            // Get the category's children
            var subCategories = categories
                .Where(x => x.ParentCategoryId == category.CategoryId)
                .ToList();

            // Recursive loop through the category's children to find more
            foreach (var subCategory in subCategories)
            {
                // Delete the category and increase one unit
                subCategory.IsDelete = true;
                deletedRecordsCount++;

                deletedRecordsCount = await RemoveCategoryChildren(categories, subCategory, deletedRecordsCount);
            }

            return deletedRecordsCount;
        }

        #endregion
    }
}
