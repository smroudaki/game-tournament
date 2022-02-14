using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GameTournament.Application.Common.ViewModels;
using GameTournament.Application.Posts.Commands;
using GameTournament.Application.Posts.Queries;
using GameTournament.Application.Posts.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameTournament.Api.Controllers
{
    public class PostController : ApiController
    {
        /// <summary>
        /// دریافت پست
        /// </summary>
        /// <param name="postGuid"></param>
        /// <returns></returns>
        /// <response code="200">دریافت موفق پست</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        [HttpGet("{postGuid}")]
        public async Task<ActionResult<PostViewModel>> Get(Guid postGuid)
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(new GetPostQuery { PostGuid = postGuid });
        }

        /// <summary>
        /// دریافت پست ها
        /// </summary>
        /// <param name="page"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        /// <response code="200">دریافت موفق پست ها</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<PostsViewModel>> Get(int page = 0, int take = 0)
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(new GetPostsQuery 
            {
                Page = page,
                Take = take
            });
        }

        /// <summary>
        /// افزودن پست
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="201">افزودن موفق پست</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<ResultViewModel>> Create(CreatePostCommand command)
        {
            Response.StatusCode = StatusCodes.Status201Created;
            return await Mediator.Send(command);
        }

        /// <summary>
        /// ویرایش پست
        /// </summary>
        /// <param name="postGuid"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="200">ویرایش موفق پست</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{postGuid}")]
        public async Task<ActionResult<ResultViewModel>> Update(Guid postGuid, UpdatePostCommand command)
        {
            if (postGuid == null || postGuid == Guid.Empty)
            {
                return BadRequest();
            }

            command.PostGuid = postGuid;

            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(command);
        }

        /// <summary>
        /// حذف پست
        /// </summary>
        /// <param name="postGuid"></param>
        /// <returns></returns>
        /// <response code="200">حذف موفق پست</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{postGuid}")]
        public async Task<ActionResult<ResultViewModel>> Delete(Guid postGuid)
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(new DeletePostCommand { PostGuid = postGuid });
        }
    }
}
