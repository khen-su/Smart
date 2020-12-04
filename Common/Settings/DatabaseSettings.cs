namespace Common.Settings
{
    public class DatabaseSettings
    {
        public string Name { get; set; }
        public string Extension { get; set; }

        public string FullName => $"{Name}.{Extension}";
    }
}