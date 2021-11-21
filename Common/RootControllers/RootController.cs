﻿using System.Net;
using Common.ApiErrors.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Common.RootControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RootController : Controller
    {
        protected readonly ILogger<RootController> _logger;

        public RootController(
            ILogger<RootController> logger
        )
        {
            _logger = logger;
        }

        protected IActionResult ToApiResult(Result result) => ToApiResult<object>(result);

        protected IActionResult ToApiResult<T>(T value) => ToApiResult(Result.Ok(value));

        protected IActionResult ToApiResult<T>(Result<T> result)
        {
            if (result.IsFailed)
            {
                var apiError = result.ToResult().ToApiError();

                _logger.LogError(JsonConvert.SerializeObject(apiError));

                return StatusCode((int)HttpStatusCode.BadRequest, apiError);
            }

            if (result.Value is not null)
            {
                return StatusCode((int)HttpStatusCode.OK, result.Value);
            }

            if (result.IsSuccess)
            {
                return StatusCode((int)HttpStatusCode.OK);
            }

            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}