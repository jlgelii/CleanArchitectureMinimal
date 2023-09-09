namespace CleanArchitecture.Application.UserAccounts.Queries.GetUserAccounts
{
    public class GetUserAccountQueryResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}