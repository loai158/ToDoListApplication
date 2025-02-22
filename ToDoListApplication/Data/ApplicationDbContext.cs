using Microsoft.EntityFrameworkCore;
using ToDoListApplication.Models;

namespace ToDoListApplication.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<MyList> MyLists{ get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ToDoListDB;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Loai", Email = "Loai@yaho", Address="Mansoura", Password="123456", Phone = "0501255623"},
                new User { Id = 2, Name = "Menna", Email = "Menna@yaho", Address="Mansoura", Password="147258", Phone = "05012s55623"}
            );
            modelBuilder.Entity<MyList>().HasData(
                new MyList { Id = 1, Title = "Study HTML" , Description= "Study HTML Study HTML Study HTML " , Deadline= DateTime.Now.AddDays(5) , UserId =1 },
                new MyList { Id = 2, Title = "Study CSS", Description = "Study CSS Study CSS Study CSS ", Deadline = DateTime.Now.AddDays(10).AddHours(5), UserId = 2 },
                new MyList { Id = 3, Title = "Study JS", Description = "Study JS Study JS Study JS", Deadline = DateTime.Now.AddDays(15).AddHours(16), UserId = 1 },
                new MyList { Id = 4, Title = "Study MVC", Description = "Study MVC Study MVC Study MVC", Deadline = DateTime.Now.AddDays(25).AddHours(11), UserId = 2 },
                new MyList { Id = 5, Title = "Study LINQ", Description = "Study LINQ Study LINQ Study LINQ", Deadline = DateTime.Now.AddDays(25).AddHours(11), UserId = 1 }
            );
        }
    }
}
