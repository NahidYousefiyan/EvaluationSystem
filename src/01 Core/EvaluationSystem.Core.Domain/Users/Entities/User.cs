using EvaluationSystem.Core.Domain.Colleges.Entities;
using EvaluationSystem.Core.Domain.Users.Enums;

namespace EvaluationSystem.Core.Domain.Users.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationCode { get; set; }      
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserGroup UserGroup { get; set; }
        public College College { get; set; }
        public int? CollegeId { get; set; }

    }
}
