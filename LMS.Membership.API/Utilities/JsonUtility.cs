namespace LMS.Membership.API.Utilities
{
    public static class JsonUtility
    {
        public static T HandleLoops<T>(T obj)
        {
            try
            {
                var json = JsonSerializer.Serialize(obj, new JsonSerializerOptions()
                {
                    WriteIndented = true,
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                });
                return JsonSerializer.Deserialize<T>(json);

            }
            catch
            {
                throw;
            }
        }
    }
}
