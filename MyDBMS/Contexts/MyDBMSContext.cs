using Microsoft.EntityFrameworkCore;
using MyDBMS.Models;

namespace MyDBMS.Contexts
{
    public class MyDBMSContextDbContext: DbContext
    {
        public DbSet<Database> Databases { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<Row> Rows { get; set; }
        public DbSet<Cell> Cells { get; set; }
         
        public MyDBMSContextDbContext()
        {
            Database.EnsureCreated();
        }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=localhost;Database=MyDBMSDatabase;User=SA;Password=yourStrong(!)Password;");
            optionsBuilder.UseSqlServer("Server=IPOTIIENKONB\\SQLEXPRESS;Database=MyDBMSDatabase;Trusted_Connection=True;");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Cell>()
                .HasOne(a => a.Attribute)
                .WithMany(c => c.Cells)
                .HasForeignKey(a => a.AttributeName)
                .HasPrincipalKey(c=>c.Name);
        }
    }
}