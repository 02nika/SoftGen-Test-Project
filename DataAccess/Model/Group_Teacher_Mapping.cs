using DataAccess.Model.General;

namespace DataAccess.Model
{
    public class Group_Teacher_Mapping : BaseEntity<int>
    {
        public int GroupId { get; set; }
        public int? TeacherId { get; set; } = null;
    }
}
