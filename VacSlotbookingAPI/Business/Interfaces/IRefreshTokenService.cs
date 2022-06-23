using Domain;
using System;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRefreshTokenService
    {
        Task<RefreshToken> GetByTokenIdAsync(Guid id);
        Task<RefreshToken> AddAsync(RefreshToken entity);
        Task<bool> UpdateAsync(RefreshToken entity);
    }
}
