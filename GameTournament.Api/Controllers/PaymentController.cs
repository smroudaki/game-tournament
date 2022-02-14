using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameTournament.Application.Common.Interfaces;
using GameTournament.Application.Payments.Commands;
using GameTournament.Application.Payments.Queries;
using GameTournament.Application.Payments.ViewModels;
using GameTournament.Application.Users.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GameTournament.Api.Controllers
{
    public class PaymentController : ApiController
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly string _verificationCallbackUrl;

        public PaymentController(ICurrentUserService currentUserService,
            IConfiguration configuration)
        {
            _currentUserService = currentUserService;
            _verificationCallbackUrl = configuration.GetValue<string>("ZarinPalVerificationCallbackUrl").ToString();
        }

        /// <summary>
        /// دریافت پرداخت
        /// </summary>
        /// <param name="paymentGuid"></param>
        /// <returns></returns>
        /// <response code="200">دریافت موفق پرداخت</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{paymentGuid}")]
        public async Task<ActionResult<PaymentViewModel>> Get(Guid paymentGuid)
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(new GetPaymentQuery { PaymentGuid = paymentGuid });
        }

        /// <summary>
        /// دریافت پرداخت ها
        /// </summary>
        /// <returns></returns>
        /// <response code="200">دریافت موفق پرداخت ها</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<PaymentsViewModel>> Get()
        {
            Response.StatusCode = StatusCodes.Status200OK;
            return await Mediator.Send(new GetPaymentsQuery());
        }

        /// <summary>
        /// افزودن پرداخت
        /// </summary>
        /// <returns></returns>
        /// <response code="201">افزودن موفق پرداخت</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<CreatePaymentViewModel>> Create()
        {
            var command = new CreatePaymentCommand
            {
                UserGuid = _currentUserService.UserGuid
            };

            Response.StatusCode = StatusCodes.Status201Created;
            return await Mediator.Send(command);
        }

        /// <summary>
        /// اعتبارسنجی پرداخت
        /// </summary>
        /// <param name="paymentGuid"></param>
        /// <returns></returns>
        /// <response code="200">اعتبارسنجی موفق پرداخت</response>
        /// <response code="400">خطای پارامتر ارسالی</response>
        /// <response code="500">خطای سمت سرور</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("[action]/{paymentGuid}")]
        [AllowAnonymous]
        public async Task<ActionResult> Verify(Guid paymentGuid)
        {
            // TODO: Check if payment's tracking token exist -> If yes return it!

            // Check if request's status and authority are passed
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                // Verify the payment
                var paymentVerification = await Mediator.Send(new VerifyPaymentCommand
                { 
                    PaymentGuid = paymentGuid,
                    Authority = HttpContext.Request.Query["Authority"].ToString() 
                });

                // Check if the verification's successful
                if (paymentVerification.Succeeded)
                {
                    // Get the payment
                    var payment = await Mediator.Send(new GetPaymentQuery { PaymentGuid = paymentGuid });

                    // Check if the payment's not null
                    if (payment.Succeeded)
                    {
                        return Redirect($"{_verificationCallbackUrl}?succeeded=true&trackingToken={payment.Payment.TrackingToken}");
                    }
                }
            }

            return Redirect($"{_verificationCallbackUrl}?succeeded=false");
        }
    }
}
