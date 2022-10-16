using DataAccess.Model.General;

namespace DataAccess.Model
{
    public class Group : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public int GroupNumber { get; set; }
    }
}
