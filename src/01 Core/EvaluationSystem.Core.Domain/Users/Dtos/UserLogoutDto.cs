namespace EvaluationSystem.Core.Domain.Users.Dtos
{
    public class UserLogoutDto
    {
        public int UserId { get; set; }
        public string AccessToken { get; set; }
    }
}
