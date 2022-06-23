using Domain;
using System;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetByTokenIdAsync(Guid id);
        Task<RefreshToken> AddAsync(RefreshToken entity);
        Task<bool> UpdateAsync(RefreshToken entity);
    }
}
