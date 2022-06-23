namespace SlotBookingWebAPI.Options
{
    #region using
    using System;
    #endregion
    public class JwtSettings
    {
        public string Secret { get; set; }
        public TimeSpan TokenLifeTime { get; set; }
    }
}
