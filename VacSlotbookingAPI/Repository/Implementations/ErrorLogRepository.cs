namespace Repository.Implementations
{
    #region using
    using Dapper;
    using Domain;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    #endregion
    public class ErrorLogRepository : BaseRepository, IRepository<ErrorLog, int>
    {

        public ErrorLogRepository(IHttpContextAccessor httpContentAccessor, IConfiguration objConfiguration) : base(httpContentAccessor, objConfiguration)
        {

        }

        public async Task<bool> AddAsync(ErrorLog entity)
        {
            try
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("p_Title", entity.Title);
                parameters.Add("p_Instance", entity.Instance);
                parameters.Add("p_Detail", entity.Detail);
                parameters.Add("p_UserId", UserId);
                await SqlMapper.ExecuteAsync(con, Sp_AddErrorLog, param: parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ErrorLog>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ErrorLog> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ErrorLog>> GetUpdatedDataAsync(DateTime LastUpdatedTime)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ErrorLog entity)
        {
            throw new NotImplementedException();
        }
    }
}
