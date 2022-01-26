namespace api.Extensions
{
    public static class StringExtensions
    {
        public static string ToContainerName(this string entityName)
        {
            return $"{entityName.ToLower()}s";
        }

        public static string ToPartitionName(this string entityName)
        {
            return $"/{entityName.ToContainerName()}";
        }
    }
}