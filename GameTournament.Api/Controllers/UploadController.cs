using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GameTournament.Application.Documents.Commands;
using GameTournament.Application.Documents.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameTournament.Api.Controllers
{
    public class UploadController : ApiController
    {
        /// <summary>
        /// بارگذاری توسط CKEditor
        /// </summary>
        /// <param name="upload"></param>
        /// <returns></returns>
        /// <response code="201">افزودن فایل جدید</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<UploadViewModel>> CKEditor(IFormFile upload)
        {
            if (upload == null)
            {
                return BadRequest();
            }

            Response.StatusCode = StatusCodes.Status201Created;

            return await Mediator.Send(new UploadCommand
            {
                File = upload
            });
        }

        /// <summary>
        /// بارگذاری توسط Filepond
        /// </summary>
        /// <param name="filepond"></param>
        /// <returns></returns>
        /// <response code="201">افزودن فایل جدید</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<UploadViewModel>> Filepond(IFormFile filepond)
        {
            if (filepond == null)
            {
                return BadRequest();
            }

            Response.StatusCode = StatusCodes.Status201Created;

            return await Mediator.Send(new UploadCommand
            {
                File = filepond
            });
        }

        /// <summary>
        /// بارگذاری توسط Filepond
        /// </summary>
        /// <param name="filepond"></param>
        /// <returns></returns>
        /// <response code="201">افزودن فایل جدید</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<Guid>> FilepondTest(IFormFile filepond)
        {
            if (filepond == null)
            {
                return BadRequest();
            }

            Response.StatusCode = StatusCodes.Status201Created;

            return await Mediator.Send(new FilepondUploadCommand
            {
                File = filepond
            });
        }
    }
}
