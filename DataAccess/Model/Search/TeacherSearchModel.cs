using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model.Search
{
    public class TeacherSearchModel
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string PersonalId { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
    }
}
