namespace Domain
{
    public class User : Log 
    {
        public int? Id { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int TalukId { get; set; }
        public int DistrictId { get; set; }
        public int StateId { get; set; }
        public string Pincode { get; set; }
        public string MobileNumber { get; set; }
        public string ProfilePic { get; set; }
        public int DeviceType { get; set; }
        public string DeviceID { get; set; }
        public string Topic { get; set; }


        public string Role { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Taluk { get; set; }
       
    }

    public class PushNotificaiton
    {
        public int UserId { get; set; }
        public int AppId { get; set; }
        public int NotificationType { get; set; }
    }
}
