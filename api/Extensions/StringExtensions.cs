namespace api.Extensions
{
    public static class StringExtensions
    {
        // this is used to get the container name based on the name of the type
        // for example, the Game type has an azure container named "games"
        public static string ToContainerName(this string entityName)
        {
            return $"{entityName.ToLower()}s";
        }

        // this is used to get the partition name based on the name of the type
        // for example, the Game type has an azure partition named "/games"
        public static string ToPartitionName(this string entityName)
        {
            return $"/{entityName.ToContainerName()}";
        }
    }
}