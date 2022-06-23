using Domain;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUsersDetailsById(int Id);
    }
}
