namespace Utility
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Authenticate
        {
            public const string login = Base + "/login";
            public const string signup = Base + "/signup";
            public const string GetAllLoginUsers = Base + "/loginUsers";
            public const string GetEntityLastUpdateTime = Base + "/EntityUpdateTime";
            public const string Refresh = Base + "/refresh";
        }

        public static class Users
        {
            public const string GetUsersDetailsById = Base + "/users/GetUsersDetailsById/{Id}";
        }


        public static class Slot
        {
            public const string AddPatientRecord = Base + "/Slot/AddPatientRecord";
            public const string GetAllPatientRecords = Base + "/Slot/GetAllPatientRecords";
            public const string GetDashboardDetails = Base + "/Slot/GetDashboardDetails/{HospitalId}/{SlotId}/{SlotDate}";
            public const string GetPatientRecordsByFilter = Base + "/Slot/GetPatientRecordsByFilter/{HospitalId}/{SlotId}/{SlotDate}";
            public const string GetAllHospitals = Base + "/Slot/GetAllHospitals";
            public const string GetAllSlots = Base + "/Slot/GetAllSlots";
            public const string GetSlotBookingsById = Base + "/Slot/GetSlotBookingsById/{CreatedBy}";
        }


    }
}
