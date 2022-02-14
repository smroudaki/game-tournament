using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GameTournament.Application.Admins.Commands;
using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Common.ViewModels;
using GameTournament.Application.Users.Commands;
using GameTournament.Application.Users.Queries;
using GameTournament.Application.Users.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameTournament.Api.Controllers
{
    public class AccountController : ApiController
    {
        /// <summary>
        /// احراز هویت کاربران
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="200">احراز هویت موفق کاربر</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<AuthenticateViewModel>> Authenticate(AuthenticateCommand command)
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(command);
        }
    }
}
