using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Common.ViewModels;
using GameTournament.Application.Users.Commands;
using GameTournament.Application.Users.Queries;
using GameTournament.Application.Users.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameTournament.Api.Controllers
{
    public class CurrentUserController : ApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public CurrentUserController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        /// <summary>
        /// دریافت کاربر کنونی
        /// </summary>
        /// <returns></returns>
        /// <response code="200">دریافت موفق کاربر لاگین شده</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<UserViewModel>> GetCurrentUser()
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(new GetUserQuery { UserGuid = _currentUserService.UserGuid });
        }

        /// <summary>
        /// ویرایش کاربر کنونی
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="200">ویرایش موفق کاربر</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<ActionResult<ResultViewModel>> Update(UpdateUserCommand command)
        {
            command.UserGuid = _currentUserService.UserGuid;

            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(command);
        }
    }
}
