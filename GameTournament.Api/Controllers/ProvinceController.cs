using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameTournament.Application.Provinces.Queries;
using GameTournament.Application.Provinces.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameTournament.Api.Controllers
{
    public class ProvinceController : ApiController
    {
        /// <summary>
        /// دریافت استان ها
        /// </summary>
        /// <returns></returns>
        /// <response code="200">دریافت موفق استان ها</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ProvincesViewModel>> Get()
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(new GetProvincesQuery());
        }
    }
}
