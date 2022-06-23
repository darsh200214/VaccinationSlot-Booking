using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ISlotRepository
    {
        Task<int> AddPatientRecord(PatientRecord patientRecord);
        Task<IEnumerable<PatientRecord>> GetAllPatientRecords();
        Task<IEnumerable<HospitalDetails>> GetDashboardDetails(int HospitalId, int SlotId, DateTime SlotDate);
        Task<IEnumerable<PatientRecord>> GetPatientRecordsByFilter(int HospitalId, int SlotId, DateTime SlotDate);
        Task<IEnumerable<HospitalDetails>> GetAllHospitals();
        Task<IEnumerable<HospitalDetails>> GetAllSlots();
        Task<IEnumerable<PatientRecord>> GetSlotBookings(int CreatedBy);
    }
}
