using Microsoft.EntityFrameworkCore;

namespace ReactAPICrud.Models
{
    public class StudentDbContextcs : DbContext
    {
        public StudentDbContextcs(DbContextOptions<StudentDbContextcs> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source =TASDEV12\\SQL2K19ENT; Initial Catalog =testapi ; User Id=sa;password=1234;TrustServerCertificate=True");
        }
    }
}
