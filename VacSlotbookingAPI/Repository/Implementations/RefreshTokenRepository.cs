using Dapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Repository.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class RefreshTokenRepository : BaseRepository, IRefreshTokenRepository
    {
        public RefreshTokenRepository(IHttpContextAccessor httpContentAccessor, IConfiguration objConfig) : base(httpContentAccessor, objConfig)
        {
        }
        public async Task<RefreshToken> AddAsync(RefreshToken entity)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("p_JwtId", entity.JwtId);
                parameters.Add("p_Used", entity.Used);
                parameters.Add("p_Invalidated", entity.Invalidated);
                parameters.Add("p_ExpiryDate", entity.ExpiryDate);
                parameters.Add("p_UserId", entity.UserId);
                var _refershToken = await SqlMapper.QueryAsync<RefreshToken>((MySqlConnection)con, Sp_AddRefreshToken, parameters, commandType: CommandType.StoredProcedure);
                return _refershToken.SingleOrDefault();
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Exception occured while AddAsync");
                throw ex;
            }
        }

        public async Task<RefreshToken> GetByTokenIdAsync(Guid id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("p_TokenId", id);
                var _refershToken = await SqlMapper.QueryAsync<RefreshToken>((MySqlConnection)con, Sp_GetRefreshTokenById, parameters, commandType: CommandType.StoredProcedure);
                return _refershToken.SingleOrDefault();
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Exception occured while GetByTokenIdAsync");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(RefreshToken entity)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("p_TokenId", entity.TokenId);
                parameters.Add("p_JwtId", entity.JwtId);
                parameters.Add("p_Used", entity.Used);
                parameters.Add("p_Invalidated", entity.Invalidated);
                parameters.Add("p_ExpiryDate", entity.ExpiryDate);
                parameters.Add("p_UserId", entity.UserId);
                await SqlMapper.ExecuteAsync(con, Sp_UpdateRefreshToken, param: parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Exception occured while UpdateAsync");
                throw;
            }
        }
    }
}
