using Business.Interfaces;
using Domain;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using System;
using System.Net;

namespace SlotBookingWebAPI.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly IErrorLogService _errorLogService;
        private readonly IStringLocalizer<ErrorController> _localizer;

        public ErrorController(IErrorLogService errorLogService, IStringLocalizer<ErrorController> localizer)
        {
            _errorLogService = errorLogService;
            _localizer = localizer;

        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error-local-development")]
        public IActionResult ErrorLocalDevelopment(
        [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (!webHostEnvironment.IsDevelopment())
            {
                throw new InvalidOperationException(
                     _localizer["LBLEnvironmentErrorMsg"]);
            }

            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = feature?.Error;

            var errorLog = new ErrorLog
            {
                Instance = feature?.Path,
                Title = ex.GetType().Name,
                Detail = ex.StackTrace,
            };
            _errorLogService.AddErrorLogAsync(errorLog);
            return StatusCode((int)HttpStatusCode.InternalServerError, _localizer["LBLSomethingWentWrong"]);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error")]
        public ActionResult Error(
            [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = feature?.Error;
            var isDev = webHostEnvironment.IsDevelopment();
            var errorLog = new ErrorLog
            {
                Instance = feature?.Path,
                Title = isDev ? $"{ex.GetType().Name}: {ex.Message}" : _localizer["LBLErrorOccured"],
                Detail = isDev ? ex.StackTrace : null,
            };
            _errorLogService.AddErrorLogAsync(errorLog);
            return StatusCode((int)HttpStatusCode.InternalServerError, _localizer["LBLSomethingWentWrong"]);
        }

    }
}