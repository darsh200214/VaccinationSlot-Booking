using CsvHelper.Configuration;
using System;

namespace Domain
{
    public class PatientRecord : Log
    {
        public int Id { get; set; }
        public int HospitalSlotMappingId { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Description { get; set; }

        public string HospitalName { get; set; }
        public string SlotTime { get; set; }
        public DateTime SlotDate { get; set; }

    }

   
}
