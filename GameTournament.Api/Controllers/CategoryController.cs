using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameTournament.Application.Categories.Commands;
using GameTournament.Application.Categories.Queries;
using GameTournament.Application.Categories.ViewModels;
using GameTournament.Application.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameTournament.Api.Controllers
{
    public class CategoryController : ApiController
    {
        /// <summary>
        /// دریافت دسته بندی
        /// </summary>
        /// <param name="categoryGuid"></param>
        /// <param name="includeChildren"></param>
        /// <returns></returns>
        /// <response code="200">دریافت موفق دسته بندی</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        [HttpGet("{categoryGuid}")]
        public async Task<ActionResult<CategoryViewModel>> Get(Guid categoryGuid, bool includeChildren = true)
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(new GetCategoryQuery
            {
                CategoryGuid = categoryGuid,
                IncludeChildren = includeChildren
            });
        }

        /// <summary>
        /// دریافت دسته بندی ها
        /// </summary>
        /// <returns></returns>
        /// <response code="200">دریافت موفق دسته بندی ها</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<CategoriesViewModel>> Get()
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(new GetCategoriesQuery());
        }

        /// <summary>
        /// دریافت نام کامل دسته بندی ها
        /// </summary>
        /// <returns></returns>
        /// <response code="200">دریافت موفق نام کامل دسته بندی ها</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<ActionResult<LiteCategoriesViewModel>> GetCategoriesLite()
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(new GetCategoriesLiteQuery());
        }

        /// <summary>
        /// افزودن دسته بندی
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="201">افزودن موفق دسته بندی</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<ResultViewModel>> Create(CreateCategoryCommand command)
        {
            Response.StatusCode = StatusCodes.Status201Created;
            return await Mediator.Send(command);
        }

        /// <summary>
        /// ویرایش دسته بندی
        /// </summary>
        /// <param name="categoryGuid"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="200">ویرایش موفق دسته بندی</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{categoryGuid}")]
        public async Task<ActionResult<ResultViewModel>> Update(Guid categoryGuid, UpdateCategoryCommand command)
        {
            if (categoryGuid == null || categoryGuid == Guid.Empty)
            {
                return BadRequest();
            }

            command.CategoryGuid = categoryGuid;

            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(command);
        }

        /// <summary>
        /// حذف دسته بندی
        /// </summary>
        /// <param name="categoryGuid"></param>
        /// <returns></returns>
        /// <response code="200">حذف موفق دسته بندی</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{categoryGuid}")]
        public async Task<ActionResult<ResultViewModel>> Delete(Guid categoryGuid)
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(new DeleteCategoryCommand { CategoryGuid = categoryGuid });
        }
    }
}
