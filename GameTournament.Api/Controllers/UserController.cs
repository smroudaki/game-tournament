using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameTournament.Application.Common.ViewModels;
using GameTournament.Application.Users.Commands;
using GameTournament.Application.Users.Queries;
using GameTournament.Application.Users.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameTournament.Api.Controllers
{
    public class UserController : ApiController
    {
        /// <summary>
        /// دریافت کاربر
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        /// <response code="200">دریافت موفق کاربر</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{userGuid}")]
        public async Task<ActionResult<UserViewModel>> Get(Guid userGuid)
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(new GetUserQuery { UserGuid = userGuid });
        }

        /// <summary>
        /// دریافت کاربران
        /// </summary>
        /// <returns></returns>
        /// <response code="200">دریافت موفق کاربران</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<UsersViewModel>> Get()
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(new GetUsersQuery());
        }

        /// <summary>
        /// ثبت نام کاربران
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="201">ثبت نام موفق کاربر</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<ResultViewModel>> Register(RegisterUserCommand command)
        {
            Response.StatusCode = StatusCodes.Status201Created;
            return await Mediator.Send(command);
        }

        /// <summary>
        /// ورود کاربران
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="200">ارسال موفق SMS</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<ResultViewModel>> Login(LoginUserCommand command)
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(command);
        }
    }
}
