using Domain;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUsersDetailsById(int Id);
    }

}
