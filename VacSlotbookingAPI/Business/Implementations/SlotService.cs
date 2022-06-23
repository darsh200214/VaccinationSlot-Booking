using Business.Interfaces;
using Domain;
using System;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class SlotService : ISlotService
    {
        ISlotRepository _studentRepository;

        public SlotService(ISlotRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> AddPatientRecord(PatientRecord patientRecord)
        {
            return await _studentRepository.AddPatientRecord(patientRecord);
        }
        public async Task<IEnumerable<PatientRecord>> GetAllPatientRecords()
        {
            return await _studentRepository.GetAllPatientRecords();
        }
        public async Task<IEnumerable<PatientRecord>> GetSlotBookings(int CreatedBy)
        {
            return await _studentRepository.GetSlotBookings(CreatedBy);
        }
        public async Task<IEnumerable<HospitalDetails>> GetDashboardDetails(int HospitalId, int SlotId, DateTime SlotDate)
        {
            return await _studentRepository.GetDashboardDetails(HospitalId,SlotId,SlotDate);
        }
        public async Task<IEnumerable<PatientRecord>> GetPatientRecordsByFilter(int HospitalId, int SlotId, DateTime SlotDate)
        {
            return await _studentRepository.GetPatientRecordsByFilter(HospitalId, SlotId, SlotDate);
        }
        public async Task<IEnumerable<HospitalDetails>> GetAllHospitals()
        {
            return await _studentRepository.GetAllHospitals();
        }
        public async Task<IEnumerable<HospitalDetails>> GetAllSlots()
        {
            return await _studentRepository.GetAllSlots();
        }
    }
}
