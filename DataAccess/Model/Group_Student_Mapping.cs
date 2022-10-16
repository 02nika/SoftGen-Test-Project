using DataAccess.Model.General;

namespace DataAccess.Model
{
    public class Group_Student_Mapping : BaseEntity<int>
    {
        public int GroupId { get; set; }
        public int? StudentId { get; set; } = null;
    }
}
