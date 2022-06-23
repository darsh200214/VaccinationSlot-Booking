using Domain;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILoginService
    {
        Task<AuthResult> ValidateUserAsync(string Email, string Password);
        Task<Login> GetLoginDetails(int userId);
    }
}
