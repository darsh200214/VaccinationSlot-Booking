using Domain;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ILoginRepository
    {
        Task<Login> ValidateUser(string Email, string Password);
        Task<Login> GetLoginDetails(int userId);
    }
}
