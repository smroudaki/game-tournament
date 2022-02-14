using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameTournament.Application.Activities.Queries;
using GameTournament.Application.Activities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameTournament.Api.Controllers
{
    public class ActivityController : ApiController
    {
        /// <summary>
        /// دریافت فعالیت ها
        /// </summary>
        /// <returns></returns>
        /// <response code="200">دریافت موفق فعالیت ها</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ActivitiesViewModel>> Get()
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(new GetActivitiesQuery());
        }
    }
}
