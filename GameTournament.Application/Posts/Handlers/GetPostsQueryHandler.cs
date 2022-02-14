using GameTournament.Application.Categories.ViewModels;
using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Documents.ViewModels;
using GameTournament.Application.Posts.Queries;
using GameTournament.Application.Posts.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameTournament.Application.Posts.Handlers
{
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, PostsViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPostsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PostsViewModel> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            // Get posts query
            var postsQuery = _unitOfWork.Posts
                .Get(null, p => p.OrderByDescending(p => p.CreationDate), "CoverDocument,User");

            // Check if the pagination variable are valid
            if (request.Page > 0 && request.Take > 0)
            {
                // Calculate skip value
                int skipNum = request.Take * (request.Page - 1);

                postsQuery = postsQuery.Skip(skipNum).Take(request.Take);
            }

            // Get posts
            var posts = await postsQuery.Select(p => new PostDto
            {
                PostGuid = p.PostGuid,
                User = p.User.FirstName + ' ' + p.User.LastName,
                CoverImage = new FilepondDto
                {
                    Guid = p.CoverDocument.DocumentGuid,
                    Source = p.CoverDocument.Path,
                    Options = new FilepondOptions
                    {
                        Type = "local",
                        File = new FilepondFile
                        {
                            Name = p.CoverDocument.FileName,
                            Size = p.CoverDocument.Size.ToString(),
                            Type = _unitOfWork.Documents.GetDocumentType(p.CoverDocument.Type)
                        },
                        Metadata = new FilepondMetadata
                        {
                            Poster = p.CoverDocument.Path
                        }
                    }
                },
                Title = p.Title,
                Abstract = p.Abstract,
                Description = p.Description,
                IsShow = p.IsShow,
                CreationDate = p.CreationDate,
                ModifiedDate = p.ModifiedDate,
                Categories = p.PostCategory
                    .Select(pc => pc.Category)
                    .Select(c => new LiteCategoryDto
                    {
                        CategoryGuid = c.CategoryGuid,
                        Title = c.Title

                    }).ToList()

            }).ToListAsync();

            // Check if there're any posts exist
            if (posts.Count <= 0)
            {
                string[] errors = new string[] { "موردی یافت نشد" };
                return new PostsViewModel(false, errors);
            }

            return new PostsViewModel(true, new string[] { }) { Posts = posts };
        }
    }
}
