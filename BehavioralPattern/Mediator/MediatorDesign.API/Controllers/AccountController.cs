using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MediatorDesign.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<AspNetUserEntity> _signInManager;
        private readonly IMediator _mediator;

        public AccountController(ILogger<AccountController> logger, SignInManager<AspNetUserEntity> signInManager, IMediator mediator)
        {
            _logger = logger;
            _signInManager = signInManager;
            _mediator = mediator;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [ServiceFilter(typeof(JwtTokenFilterAttribute))]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (!result.Succeeded)
                {
                    return Unauthorized();
                }
                _logger.LogInformation(LoggingEvent.USER_LOGGED_IN, "User logged in.");
            }

            return Ok(new LoginResponse(model.UserName));
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            _logger.LogInformation(LoggingEvent.USER_LOGGED_OUT, "User logged out.");
            return Ok(new { Message = "Logged out successfully" });
        }

        [HttpPost("forget-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new ForgetPasswordCommand(request.UserName, request.NewPassword));

                if (result.Succeeded)
                {
                    return Ok(new { Message = "Password changed successfully" });
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            return BadRequest(request);
        }

        [HttpPut("update-profile")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequest request)
        {
            var claimsPrincipal = HttpContext.User;

            // Retrieve user details from claims
            string stringUserId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            int userId = 0;
            int.TryParse(stringUserId, out userId);

            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new UpdateUserCommand(userId, request.FirstName, request.LastName));

                if (result.Succeeded)
                {
                    return Ok(result.Data);
                }
                else
                {
                    BadRequest(result.Errors);
                }
            }
            return BadRequest(request);
        }
    }
}