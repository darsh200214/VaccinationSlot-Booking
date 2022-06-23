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
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IHttpContextAccessor httpContentAccessor, IConfiguration objConfig) : base(httpContentAccessor, objConfig)
        {
        }

        public async Task<User> GetUsersDetailsById(int Id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("p_ID", Id);
                var objUser = await SqlMapper.QueryAsync<User>((MySqlConnection)con, sp_GetUserDetailsByID, parameters, commandType: CommandType.StoredProcedure);
                return objUser.SingleOrDefault();
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Exception occured while GetUsersDetailsById");
                throw ex;
            }
        }
    }
}
