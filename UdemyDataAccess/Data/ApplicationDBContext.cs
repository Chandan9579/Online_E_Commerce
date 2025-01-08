using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using UdemyModels.Models;

namespace UdemyDataAccess.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {

        }
     public DbSet<Category> Chandan_Categories {get; set;}

     public DbSet<Books> Chandan_Books {get; set;}

     
     protected override void  OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Category>().HasData(
            new Category{ Id = 1, Name= "Chandan", DisplayOrder=1},
            new Category{ Id = 2, Name= "Rahul", DisplayOrder=2},
            new Category{ Id = 3, Name= "Adil", DisplayOrder=3}
        );

         modelBuilder.Entity<Books>().HasData(
            new Books{ BookId = 1, BookName= "History", Taken=true},
            new Books{ BookId = 2, BookName= "Civics", Taken=false},
            new Books{ BookId = 3, BookName= "Geography", Taken=true}
        );
    
     }

     
     
   
}
}