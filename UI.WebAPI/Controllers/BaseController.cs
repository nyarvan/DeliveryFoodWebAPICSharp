﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace UI.WebAPI
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        internal Guid UserId => !User.Identity.IsAuthenticated
           ? Guid.Empty
           : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
