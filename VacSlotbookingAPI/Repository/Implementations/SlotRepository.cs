using Dapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class SlotRepository : BaseRepository, ISlotRepository
    {
        public SlotRepository(IHttpContextAccessor httpContentAccessor, IConfiguration objConfig) : base(httpContentAccessor, objConfig)
        {

        }
        public async Task<int> AddPatientRecord(PatientRecord patientRecord)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("p_Id", patientRecord.Id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("p_HospitalSlotMappingId", patientRecord.HospitalSlotMappingId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("p_SlotDate", patientRecord.SlotDate, DbType.Date, ParameterDirection.Input);
                parameters.Add("p_PatientName", patientRecord.PatientName, DbType.String, ParameterDirection.Input);
                parameters.Add("p_Gender", patientRecord.Gender, DbType.String, ParameterDirection.Input);
                parameters.Add("p_Age", patientRecord.Age, DbType.String, ParameterDirection.Input);
                parameters.Add("p_Address", patientRecord.Address, DbType.String, ParameterDirection.Input);
                parameters.Add("p_ContactNo", patientRecord.ContactNo, DbType.String, ParameterDirection.Input);
                parameters.Add("p_Description", patientRecord.Description, DbType.String, ParameterDirection.Input);
                parameters.Add("p_CreatedBy", patientRecord.CreatedBy, DbType.Int32, ParameterDirection.Input);
                parameters.Add("p_Verfied", -1, DbType.Int32, ParameterDirection.Output);
                await SqlMapper.ExecuteAsync(con, Sp_AddPatientRecord, param: parameters, commandType: CommandType.StoredProcedure);
                var result = parameters.Get<Int32>("p_Verfied");
                return result;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Exception occured while AddPatientRecord");
                throw ex;
            }
        }
        public async Task<IEnumerable<HospitalDetails>> GetDashboardDetails(int HospitalId, int SlotId, DateTime SlotDate)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("p_HospitalId", HospitalId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("p_SlotId", SlotId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("p_SlotDate", SlotDate, DbType.Date, ParameterDirection.Input);
                IEnumerable<HospitalDetails> result = await SqlMapper.QueryAsync<HospitalDetails>(con, Sp_GetDashboardDetails, param: parameters, commandType: CommandType.StoredProcedure);
                IList<HospitalDetails> hospitalDetailsList = result.ToList();
                return hospitalDetailsList;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Exception occured while GetDashboardDetails");
                throw ex;
            }
        }

        public async Task<IEnumerable<PatientRecord>> GetPatientRecordsByFilter(int HospitalId, int SlotId, DateTime SlotDate)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("p_HospitalId", HospitalId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("p_SlotId", SlotId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("p_SlotDate", SlotDate, DbType.Date, ParameterDirection.Input);
                IEnumerable<PatientRecord> result = await SqlMapper.QueryAsync<PatientRecord>(con, Sp_GetPatientRecordsByFilter, param: parameters, commandType: CommandType.StoredProcedure);
                IList<PatientRecord> patientRecordList = result.ToList();
                return patientRecordList;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Exception occured while GetPatientRecordsByFilter");
                throw ex;
            }
        }
        public async Task<IEnumerable<HospitalDetails>> GetAllHospitals()
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                IEnumerable<HospitalDetails> result = await SqlMapper.QueryAsync<HospitalDetails>(con, Sp_GetAllHospitals, parameters, commandType: CommandType.StoredProcedure);
                IList<HospitalDetails> hospitalList = result.ToList();
                return hospitalList;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Exception occured while GetAllHospitals");
                throw ex;
            }
        }
        public async Task<IEnumerable<HospitalDetails>> GetAllSlots()
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                IEnumerable<HospitalDetails> result = await SqlMapper.QueryAsync<HospitalDetails>(con, Sp_GetAllSlots, parameters, commandType: CommandType.StoredProcedure);
                IList<HospitalDetails> slotList = result.ToList();
                return slotList;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Exception occured while GetAllSlots");
                throw ex;
            }
        }
        public async Task<IEnumerable<PatientRecord>> GetSlotBookings(int CreatedBy)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("p_CreatedBy", CreatedBy, DbType.Int32, ParameterDirection.Input);
                IEnumerable<PatientRecord> result = await SqlMapper.QueryAsync<PatientRecord>(con, Sp_GetSlotBookings, parameters, commandType: CommandType.StoredProcedure);
                IList<PatientRecord> patientRecordList = result.ToList();
                return patientRecordList;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Exception occured while GetSlotBookings");
                throw ex;
            }
        }
        public async Task<IEnumerable<PatientRecord>> GetAllPatientRecords()
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                IEnumerable<PatientRecord> result = await SqlMapper.QueryAsync<PatientRecord>(con, Sp_GetAllPatientRecords, parameters, commandType: CommandType.StoredProcedure);
                IList<PatientRecord> patientRecordList = result.ToList();
                return patientRecordList;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Exception occured while GetAllPatientRecords");
                throw ex;
            }
        }
    }
}
