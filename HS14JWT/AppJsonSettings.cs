namespace HS14JWT
{
    public class AppJsonSettings
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public TimeSpan ExperiedTime { get; set; }
        public string Secret { get; set; }
    }
}
