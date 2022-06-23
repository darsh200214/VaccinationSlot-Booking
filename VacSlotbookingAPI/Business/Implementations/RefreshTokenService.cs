using Business.Interfaces;
using Domain;
using Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class RefreshTokenService : IRefreshTokenService
    {
        IRefreshTokenRepository _refreshTokenRepository;
        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task<RefreshToken> AddAsync(RefreshToken entity)
        {
            return await _refreshTokenRepository.AddAsync(entity);
        }

        public async Task<RefreshToken> GetByTokenIdAsync(Guid id)
        {
            return await _refreshTokenRepository.GetByTokenIdAsync(id);
        }

        public async Task<bool> UpdateAsync(RefreshToken entity)
        {
            return await _refreshTokenRepository.UpdateAsync(entity);
        }
    }
}
