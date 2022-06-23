using Dapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Repository.Interfaces;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class LoginRepository : BaseRepository, ILoginRepository
    {
        public LoginRepository(IHttpContextAccessor httpContentAccessor, IConfiguration objConfig) : base(httpContentAccessor, objConfig)
        {
        }

        public async Task<Login> ValidateUser(string Email, string Password)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("p_Email", Email);
                parameters.Add("p_Password", Password);
                var _user = await SqlMapper.QueryAsync<Login>((MySqlConnection)con, Sp_ValidateLogin, parameters, commandType: CommandType.StoredProcedure);
                return _user.SingleOrDefault();
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Exception occured while ValidateUser");
                throw ex;
            }
        }
        public async Task<Login> GetLoginDetails(int userId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("p_UserId", userId);
                var _user = await SqlMapper.QueryAsync<Login>((MySqlConnection)con, Sp_GetLoginDetailsById, parameters, commandType: CommandType.StoredProcedure);
                return _user.SingleOrDefault();
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Exception occured while GetLoginDetails");
                throw;
            }
        }
    }
}
