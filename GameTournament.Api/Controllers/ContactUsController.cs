using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameTournament.Application.Common.ViewModels;
using GameTournament.Application.ContactUsMessages.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameTournament.Api.Controllers
{
    public class ContactUsController : ApiController
    {
        /// <summary>
        /// ارسال پیام ارتباط با ما
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="200">ارسال موفق پیام ارتباط با ما</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ResultViewModel>> SendMessage(CreateContactUsMessageCommand command)
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(command);
        }
    }
}
