using Business.Interfaces;
using Domain;
using Repository.Interfaces;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        public async Task<User> GetUsersDetailsById(int Id)
        {
            return await _userRepository.GetUsersDetailsById(Id);
        }

    }
}
