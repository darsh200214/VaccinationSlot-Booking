using Business.Interfaces;
using Contracts.Requests;
using Contracts.Responses;
using Domain;
using SlotBookingWebAPI.Filters;
using SlotBookingWebAPI.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace SlotBookingWebAPI.Controllers
{
    [SkipMyGlobalActionFilter]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly JwtSettings _jwtSettings;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly IRefreshTokenService _refreshTokenService;
        public LoginController(ILoginService loginService, JwtSettings jwtSettings,
            TokenValidationParameters tokenValidationParameters,
            IRefreshTokenService refreshTokenService)
        {
            _loginService = loginService;
            _jwtSettings = jwtSettings;
            _tokenValidationParameters = tokenValidationParameters;
            _refreshTokenService = refreshTokenService;
        }

        [HttpPost(ApiRoutes.Authenticate.login)]
        public async Task<IActionResult> Login([FromBody] AuthenticateLogin request)
        {
            var AuthResult = await _loginService.ValidateUserAsync(request.Email, request.Password);
            if (!AuthResult.status)
            {
                return BadRequest(new LoginFailureResponse
                {
                    errors = AuthResult.errors
                });
            }

            var loginSuccessResponse = await TokenGeneratorForUserAsync(AuthResult);
            return Ok(loginSuccessResponse);
        }

        [HttpPost(ApiRoutes.Authenticate.Refresh)]
        public async Task<IActionResult> refreshToken([FromBody] RefreshtokenRequest request)
        {
            var AuthResult = await RefreshTokenAsync(request.Token, request.RefreshToken);
            if (!AuthResult.status)
            {
                return BadRequest(new LoginFailureResponse
                {
                    errors = AuthResult.errors
                });
            }
            var loginSuccessResponse = await TokenGeneratorForUserAsync(AuthResult);
            return Ok(loginSuccessResponse);
        }


        private async Task<Object> TokenGeneratorForUserAsync(AuthResult _authResult)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(type: JwtRegisteredClaimNames.Sub, value:_authResult._user.Email),
                    new Claim(type: JwtRegisteredClaimNames.Jti, value: Guid.NewGuid().ToString()),
                    new Claim(type: JwtRegisteredClaimNames.Email, value:_authResult._user.Email),
                    new Claim(type: "Id", value:_authResult._user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifeTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), algorithm: SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var refreshToken = new RefreshToken
            {
                JwtId = token.Id,
                UserId = _authResult._user.Id,
                ExpiryDate = DateTime.UtcNow.AddMonths(6)
            };
            refreshToken = await _refreshTokenService.AddAsync(refreshToken);
            return (new LoginSuccessResponse
            {
                UserId = _authResult._user.Id,
                Token = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken.TokenId.ToString()
            });
        }
        private async Task<AuthResult> RefreshTokenAsync(string token, string refreshtoken)
        {
            var validatedToken = GetPrincipalFromToken(token);
            var errorsLst = new List<string>();
            var authResult = new AuthResult
            {
                status = false,
                _user = null,
                errors = errorsLst
            };

            if (validatedToken == null)
            {
                errorsLst.Add("Invalid Token");
                authResult.errors = errorsLst;
                return authResult;
            }
            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            Guid _refreshToken = Guid.Parse(refreshtoken);
            var storeRefreshToken = await _refreshTokenService.GetByTokenIdAsync(_refreshToken);

            if (storeRefreshToken == null)
            {
                errorsLst.Add("Token does not exist");
                authResult.errors = errorsLst;
                return authResult;
            }
            if (DateTime.UtcNow > storeRefreshToken.ExpiryDate)
            {
                errorsLst.Add("Token expired!");
                authResult.errors = errorsLst;
                return authResult;
            }

            if (storeRefreshToken.Invalidated)
            {
                errorsLst.Add("password changed or account deactivated!");
                authResult.errors = errorsLst;
                return authResult;
            }

            //if (storeRefreshToken.Used)
            //{
            //    errorsLst.Add("Token Used!");
            //    authResult.errors = errorsLst;
            //    return authResult;
            //}

            if (storeRefreshToken.JwtId != jti)
            {
                errorsLst.Add("Jwt Does not match!");
                authResult.errors = errorsLst;
                return authResult;
            }

            storeRefreshToken.Used = true;
            var isUpdated = await _refreshTokenService.UpdateAsync(storeRefreshToken);
            if (isUpdated)
            {
                bool success = Int32.TryParse(validatedToken.Claims.Single(x => x.Type == "Id").Value, out int _UserId);
                if (success)
                {
                    var _userObj = await _loginService.GetLoginDetails(_UserId);
                    authResult.status = true;
                    authResult._user = _userObj;
                    return authResult;
                }
            }
            errorsLst.Add("exception in token update!");
            authResult.errors = errorsLst;
            return authResult;
        }

        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                //var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
                var tokenValidationParameters = _tokenValidationParameters.Clone();
                tokenValidationParameters.ValidateLifetime = false;
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
                if (!isJwtWithValidSecurityAlgorithm(validatedToken))
                {
                    return null;
                }
                return principal;
            }
            catch
            {
                return null;
            }
        }

        private bool isJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
                jwtSecurityToken.Header.Alg.Equals(value: SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}