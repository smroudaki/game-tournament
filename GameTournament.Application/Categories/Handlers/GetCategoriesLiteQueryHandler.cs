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
    public class GetCategoriesLiteQueryHandler : IRequestHandler<GetCategoriesLiteQuery, LiteCategoriesViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoriesLiteQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<LiteCategoriesViewModel> Handle(GetCategoriesLiteQuery request, CancellationToken cancellationToken)
        {
            // Get lite categories
            var liteCategories = await GetCategoriesLite();

            // Check if there're any lite categories exist
            if (liteCategories.Count <= 0)
            {
                string[] errors = new string[] { "موردی یافت نشد" };
                return new LiteCategoriesViewModel(false, errors);
            };

            return new LiteCategoriesViewModel(true, new string[] { }) { LiteCategories = liteCategories };
        }

        #region Helper Methods

        private async Task<List<LiteCategoryDto>> GetCategoriesLite()
        {
            // TODO
            var absoluteCategories = new List<LiteCategoryDto>();

            // Get all the categories
            var categories = await _unitOfWork.Categories.Get().ToListAsync();

            // Check if there're any parent categories
            if (categories.Count <= 0)
            {
                return absoluteCategories;
            };

            // Get the parent categories
            var parentCategories = categories
                .Where(c => c.ParentCategoryId.Equals(null))
                .OrderBy(c => c.Title)
                .Select(c => new CategoryDto
                {
                    CategoryId = c.CategoryId,
                    CategoryGuid = c.CategoryGuid,
                    ParentCategoryId = c.ParentCategoryId,
                    Title = c.Title,
                    IsActive = c.IsActive,
                    CreationDate = c.CreationDate,
                    ModifiedDate = c.ModifiedDate

                }).ToList();

            // Recursive loop through the parent categories to find more
            foreach (var parentCategory in parentCategories)
            {
                // TODO
                var previousCategories = new List<Tuple<int, int?>>
                {
                    new Tuple<int, int?>
                    (
                        parentCategory.CategoryId,
                        parentCategory.ParentCategoryId
                    )
                };

                // TODO
                absoluteCategories.Add(
                    new LiteCategoryDto
                    {
                        CategoryGuid = parentCategory.CategoryGuid,
                        Title = parentCategory.Title
                    });

                parentCategory.Children = await GetCategoryChildren
                (
                    categories,
                    parentCategory,
                    previousCategories,
                    absoluteCategories
                );
            }

            return absoluteCategories;
        }

        private async Task<List<CategoryDto>> GetCategoryChildren(List<Category> categories,
            CategoryDto category,
            List<Tuple<int, int?>> previousCategories,
            List<LiteCategoryDto> absoluteCategories)
        {
            // Get the category's children
            var subCategories = categories
                .Where(c => c.ParentCategoryId == category.CategoryId)
                .OrderBy(c => c.Title)
                .Select(c => new CategoryDto
                {
                    CategoryId = c.CategoryId,
                    CategoryGuid = c.CategoryGuid,
                    ParentCategoryId = c.ParentCategoryId,
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
                // TODO
                if (subCategory.ParentCategoryId == previousCategories[^1].Item1)
                {
                    // TODO
                    absoluteCategories.Add
                    (
                        new LiteCategoryDto
                        {
                            CategoryGuid = subCategory.CategoryGuid,
                            Title = absoluteCategories[^1].Title + $", {subCategory.Title}"
                        }
                    );
                }
                else
                {
                    // TODO
                    string name = string.Copy(absoluteCategories[^1].Title);

                    // TODO
                    int counter = 0;

                    // TODO
                    do
                    {
                        counter++;

                    } while (subCategory.ParentCategoryId != previousCategories[^counter].Item2);

                    // TODO
                    for (int i = 0; i < counter; i++)
                    {
                        int startIndex = name.LastIndexOf(",", StringComparison.Ordinal);
                        int length = name.Length;
                        name = name.Remove(startIndex, length - startIndex);
                    }

                    // TODO
                    absoluteCategories.Add
                    (
                        new LiteCategoryDto
                        {
                            CategoryGuid = subCategory.CategoryGuid,
                            Title = name + $", {subCategory.Title}"
                        }
                    );

                    // TODO
                    int index = previousCategories.FindIndex(pc => pc.Item2 == subCategory.ParentCategoryId);
                    while (previousCategories.Count >= index + 1)
                    {
                        previousCategories.RemoveAt(index);
                    }
                }

                // TODO
                previousCategories.Add
                (
                    new Tuple<int, int?>
                    (
                        subCategory.CategoryId,
                        subCategory.ParentCategoryId
                    )
                );

                subCategory.Children = await GetCategoryChildren
                (
                    categories,
                    subCategory,
                    previousCategories, 
                    absoluteCategories
                );
            }

            return category.Children;
        }

        #endregion
    }
}
