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
    public class GetPostQueryHandler : IRequestHandler<GetPostQuery, PostViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPostQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PostViewModel> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            // Get the post
            var post = await _unitOfWork.Posts
                .Get(p => p.PostGuid.Equals(request.PostGuid), null, "CoverDocument,User")
                .Select(p => new PostDto
                {
                    PostGuid = p.PostGuid,
                    User = p.User.FirstName + " " + p.User.LastName,
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

                }).SingleOrDefaultAsync();

            // Check if the post exist
            if (post == null)
            {
                string[] errors = new string[] { "پست مورد نظر یافت نشد" };
                return new PostViewModel(false, errors);
            }

            return new PostViewModel(true, new string[] { }) { Post = post };
        }
    }
}
