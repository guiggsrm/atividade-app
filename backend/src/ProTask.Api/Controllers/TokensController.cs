using Microsoft.AspNetCore.Mvc;
using ProTask.Application.DTOs;
using ProTask.Application.Interfaces;
using ProTask.Domain.Account;

namespace ProTask.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokensController : ControllerBase
    {
        private readonly ILogger<TokensController> _logger;
        private readonly IAuthenticate _authenticate;
        private readonly ITokenService _tokenService;
        private readonly ISeedUserRoleService _seedUserRoleService;

        public TokensController(ILogger<TokensController> logger, IAuthenticate authenticate, ITokenService tokenService, ISeedUserRoleService seedUserRoleService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authenticate = authenticate ?? throw new ArgumentNullException(nameof(authenticate));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _seedUserRoleService = seedUserRoleService ?? throw new ArgumentNullException(nameof(seedUserRoleService));
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDTO>> Login(TokenRequestDTO tokenRequest)
        {
            if (await _authenticate.Authenticate(tokenRequest.UserName, tokenRequest.Password))
            {
                var userRoles = await _seedUserRoleService.GetRoles(tokenRequest.UserName);
                var tokenResponse = _tokenService.Generate(tokenRequest.UserName, userRoles);
                var user = await _authenticate.GetUserName<UserDTO>(tokenRequest.UserName);
                tokenResponse.User = user;
                return Ok(tokenResponse);
            }

            return BadRequest(new { message = "Invalid login attempt" });
        }

        [HttpPost("register")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult> Register(NewUserDTO newUser)
        {
            if (await _authenticate.RegisterUser(newUser.UserName, newUser.Password, newUser.Name, newUser.Lang, false))
            {
                return Ok(new { message = "User was create  successfully" });
            }

            return BadRequest(new { message = "It's no possible to create the user"});
        }
    }
}