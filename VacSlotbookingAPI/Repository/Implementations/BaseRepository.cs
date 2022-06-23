using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Repository.Implementations
{
    public class BaseRepository
    {
        public string _connectionString;
        public IDbConnection con;
        protected int UserId = 0;
        private HttpContext _httpContext;
        #region StoredProceduresList
        protected const string Sp_GetAllUser = "sp_GetAllUser";
        protected const string Sp_ValidateLogin = "sp_ValidateLogin";
        protected const string Sp_AddRefreshToken = "sp_AddRefreshToken";
        protected const string Sp_GetRefreshTokenById = "sp_GetRefreshTokenById";
        protected const string Sp_UpdateRefreshToken = "sp_UpdateRefreshToken";
        protected const string sp_GetUserDetailsByID = "sp_GetUserDetailsByID";
        protected const string Sp_AddErrorLog = "sp_AddErrorLog";
        protected const string Sp_GetLoginDetailsById = "sp_GetLoginDetailsById";

        protected const string Sp_AddPatientRecord = "sp_AddPatientRecord";
        protected const string Sp_GetDashboardDetails = "sp_GetDashboardDetails";
        protected const string Sp_GetAllPatientRecords = "sp_GetAllPatientRecords";
        protected const string Sp_GetAllHospitals = "sp_GetAllHospitals";
        protected const string Sp_GetAllSlots = "sp_GetAllSlots";
        protected const string Sp_GetPatientRecordsByFilter = "sp_GetPatientRecordsByFilter";
        protected const string Sp_GetSlotBookings = "sp_GetSlotBookings";


        #endregion

        public BaseRepository(IHttpContextAccessor httpContentAccessor, IConfiguration objConfig)
        {
            _httpContext = httpContentAccessor.HttpContext;
            _connectionString = objConfig.GetConnectionString("DefaultConnection");
            con = new MySqlConnection(_connectionString);
            UserId = this.GetUserId();
        }
        private int GetUserId()
        {
            try
            {
                bool success = Int32.TryParse("1", out int _UserId);
                //this._httpContext.User.Claims.Where(p => p.Type == "Id").FirstOrDefault().Value
                if (success)
                {
                    return _UserId;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public void Dispose()
        {
            con.Close();
            con.Dispose();
            _httpContext = null;
        }
    }
}
