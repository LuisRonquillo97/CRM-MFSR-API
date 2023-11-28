namespace Security.Models
{
    internal class JwtConfiguration
    {
        public string Path { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
    }
}
