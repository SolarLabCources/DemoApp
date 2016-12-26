using DataAccessLayer.Objects;
using System.Data.Entity;

namespace DataAccessLayer
{
    public class DemoContext : DbContext
    {
        public static DemoContext Create()
        {
            return new DemoContext();
        }
        public DemoContext() : this("DemoConnection")
        {
        }

        public DemoContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Database.SetInitializer<DemoContext>(new DropCreateDatabaseAlways<DemoContext>());
        }

        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<File> Files { get; set; }
    }
}
