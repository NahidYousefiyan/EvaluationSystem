using EvaluationSystem.Core.Domain.Users.Enums;

namespace EvaluationSystem.Core.Domain.Users.Dtos
{
    public class UserInfoResultDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int? CollegeId { get; set; }
        public string CollegeName { get; set; }
        public UserGroup UserGroup { get; set; }
        public string UserGroupName { get; set; }
    }
}
