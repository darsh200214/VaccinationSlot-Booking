using CsvHelper.Configuration;
using System;

namespace Domain
{
    public class HospitalDetails : Log
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string SlotTime { get; set; }
        public int PerSlotCount { get; set; }
        public int FilledCount { get; set; }

    }

   
}
