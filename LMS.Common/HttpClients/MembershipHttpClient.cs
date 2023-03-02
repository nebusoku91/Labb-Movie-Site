namespace LMS.Common.HttpClients
{
    public class MembershipHttpClient
    {
        public HttpClient Client { get; }

        public MembershipHttpClient(HttpClient client)
        {
            Client = client;
        }

        public void AddBearerToken(string Token)
        {
            Client.DefaultRequestHeaders.Remove("Authorization");
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
        }
    }
}
