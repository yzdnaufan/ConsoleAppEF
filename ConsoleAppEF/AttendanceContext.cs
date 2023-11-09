using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEF
{
    public class AttendanceContext : DbContext
    {
        public AttendanceContext() : base("AttendanceDB")
        {
            Database.SetInitializer<AttendanceContext>(new CreateDatabaseIfNotExists<AttendanceContext>());
        }

        public DbSet<User> Users { get; set; }
    }
}
