using DataAccess.Model.General;

namespace DataAccess.Model
{
    public class Student : BaseEntity<int>
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string PersonalId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
    }
}
