namespace EvaluationSystem.Core.Domain.Users.Entities
{
    public class UserAccessToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Token { get; set; }       
    }
}
