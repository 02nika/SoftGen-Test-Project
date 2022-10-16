using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContext) : base(dbContext) { }

        #region DB set
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Group_Student_Mapping> Group_Student_Mappings { get; set; }
        public DbSet<Group_Teacher_Mapping> Group_Teacher_Mappings { get; set; }
        #endregion
    }
}
