using GameTournament.Application.Categories.Queries;
using GameTournament.Application.Categories.ViewModels;
using GameTournament.Application.Common.Interfaces;
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
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryViewModel> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            // Get the category
            var category = await GetCategory(request.CategoryGuid, request.IncludeChildren);

            // Check if the category exist
            if (category == null)
            {
                string[] errors = new string[] { "دسته بندی مورد نظر یافت نشد" };
                return new CategoryViewModel(false, errors);
            }

            return new CategoryViewModel(true, new string[] { }) { Category = category };
        }

        #region Helper Methods

        private async Task<List<CategoryDto>> GetCategories()
        {
            var parentCategories = new List<CategoryDto>();

            // Get all the categories
            var categories = await _unitOfWork.Categories.Get().ToListAsync();

            // Check if there're any parent categories
            if (categories.Count <= 0)
            {
                return parentCategories;
            };

            // Get the parent categories
            parentCategories = categories
                .Where(c => c.ParentCategoryId.Equals(null))
                .OrderBy(c => c.Title)
                .Select(c => new CategoryDto
                {
                    CategoryId = c.CategoryId,
                    CategoryGuid = c.CategoryGuid,
                    Title = c.Title,
                    IsActive = c.IsActive,
                    CreationDate = c.CreationDate,
                    ModifiedDate = c.ModifiedDate

                }).ToList();

            // Recursive loop through the parent categories to find more
            foreach (var parentCategory in parentCategories)
            {
                parentCategory.Children = await GetCategoryChildren(categories, parentCategory);
            }

            return parentCategories;
        }

        private async Task<CategoryDto> GetCategory(Guid categoryGuid, bool includeChildren)
        {
            // Get the category
            var category = await _unitOfWork.Categories
                .Get(c => c.CategoryGuid.Equals(categoryGuid))
                .Select(c => new CategoryDto
                {
                    CategoryId = c.CategoryId,
                    CategoryGuid = c.CategoryGuid,
                    Title = c.Title,
                    IsActive = c.IsActive,
                    CreationDate = c.CreationDate,
                    ModifiedDate = c.ModifiedDate

                }).SingleOrDefaultAsync();

            // Check if the category exist
            if (category == null)
            {
                return null;
            }

            // Check if the category's children are included
            if (includeChildren)
            {
                // Get all the categories
                var categories = await _unitOfWork.Categories.Get().ToListAsync();

                // Get the category's children
                category.Children = await GetCategoryChildren(categories, category);
            }

            return category;
        }

        private async Task<List<CategoryDto>> GetCategoryChildren(List<Category> categories, CategoryDto category)
        {
            // Get the category's children
            var subCategories = categories
                .Where(c => c.ParentCategoryId == category.CategoryId)
                .OrderBy(c => c.Title)
                .Select(c => new CategoryDto
                {
                    CategoryId = c.CategoryId,
                    CategoryGuid = c.CategoryGuid,
                    Title = c.Title,
                    IsActive = c.IsActive,
                    CreationDate = c.CreationDate,
                    ModifiedDate = c.ModifiedDate

                }).ToList();

            // Check if there're any category's children
            if (subCategories.Count <= 0)
            {
                return category.Children;
            };

            // Set the category's children
            category.Children = subCategories;

            // Recursive loop through the category's children to find more
            foreach (var subCategory in category.Children)
            {
                subCategory.Children = await GetCategoryChildren(categories, subCategory);
            }

            return category.Children;
        }

        #endregion
    }
}
