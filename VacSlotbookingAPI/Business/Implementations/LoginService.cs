using Business.Interfaces;
using Domain;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class LoginService : ILoginService
    {
        ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<AuthResult> ValidateUserAsync(string Email, string Password)
        {
            var user = await _loginRepository.ValidateUser(Email, Password);

            if (user == null)
            {
                var errorsLst = new List<string>();
                errorsLst.Add("user name or password is invalid");
                return new AuthResult
                {
                    status = false,
                    _user = null,
                    errors = errorsLst
                };
            }
            return new AuthResult
            {
                status = true,
                _user = user,
                errors = null
            };
        }
        public async Task<Login> GetLoginDetails(int userId)
        {
            return await _loginRepository.GetLoginDetails(userId);
        }
    }
}
