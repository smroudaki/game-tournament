using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameTournament.Application.Admins.Commands;
using GameTournament.Application.Common.ViewModels;
using GameTournament.Application.Users.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameTournament.Api.Controllers
{
    public class AdminController : ApiController
    {
        /// <summary>
        /// ورود کاربران مدیر
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
        public async Task<ActionResult<ResultViewModel>> Login(LoginAdminCommand command)
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(command);
        }

        /// <summary>
        /// ویرایش کاربر توسط ادمین
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="200">ویرایش موفق کاربر توسط ادمین</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("[action]/{userGuid}")]
        public Task<ActionResult<ResultViewModel>> UpdateUser(Guid userGuid, UpdateUserCommand command)
        {
            throw new NotImplementedException();

            // if (userGuid == null || userGuid == Guid.Empty)
            // {
            //     return BadRequest();
            // }

            // command.UserGuid = userGuid;

            // Response.StatusCode = StatusCodes.Status200OK;
            // return await Mediator.Send(command);
        }

        /// <summary>
        /// ویرایش وضعیت کاربر توسط ادمین
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="200">ویرایش موفق وضعیت کاربر توسط ادمین</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("[action]/{userGuid}")]
        public async Task<ActionResult<ResultViewModel>> ChangeUserState(Guid userGuid, ChangeUserStateCommand command)
        {
            if (userGuid == null || userGuid == Guid.Empty)
            {
                return BadRequest();
            }

            command.UserGuid = userGuid;

            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(command);
        }

        /// <summary>
        /// حذف کاربر توسط ادمین
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        /// <response code="200">حذف موفق کاربر</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("[action]/{userGuid}")]
        public async Task<ActionResult<ResultViewModel>> DeleteUser(Guid userGuid)
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(new DeleteUserCommand { UserGuid = userGuid });
        }
    }
}
