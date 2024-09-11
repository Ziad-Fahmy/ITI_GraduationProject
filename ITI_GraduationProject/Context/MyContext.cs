using ITI_GraduationProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI_GraduationProject.Context
{
    public class MyContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Graduation_ITI_Project;Trusted_Connection=True;Encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var _Categories = new List<Category>
            {
                 new Category { Id = 1, Name = "Electronics", Description = "All kinds of electronic items" },
            new Category { Id = 2, Name = "Books", Description = "Wide range of books and literature" },
            new Category { Id = 3, Name = "Furniture", Description = "Home and office furniture" },
            new Category { Id = 4, Name = "Clothing", Description = "Fashion and apparel" },
            new Category { Id = 5, Name = "Sports", Description = "Sports equipment and accessories" },
            new Category { Id = 6, Name = "Toys", Description = "Toys for children of all ages" },
            new Category { Id = 7, Name = "Grocery", Description = "Daily grocery and essentials" },
            new Category { Id = 8, Name = "Beauty", Description = "Beauty and personal care products" }

            };
            var _Products = new List<Product>
            {
            new Product { Id = 1, Title = " Mouse",             Quantity = 22, Price = 1234,    Description = "This is Description",  ImagePath = "Image_Path"  ,   CategoryId = 1 },
                new Product { Id = 2, Title = " Gaming Monitor  " , Quantity = 11, Price = 2234,    Description = "This is Description",  ImagePath = "Image_Path"  ,   CategoryId = 2 },
                new Product { Id = 3, Title = " Keyboard  ",        Quantity = 23, Price = 3234,    Description = "This is Description",  ImagePath = "Image_Path"  ,   CategoryId = 3 },
                new Product { Id = 4, Title = " Gaming Headset",    Quantity = 18, Price = 4234,    Description = "This is Description",  ImagePath = "Image_Path"  ,   CategoryId = 4 },
                new Product { Id = 5, Title = " Motherboard ",      Quantity = 8,  Price = 5234,    Description = "This is Description",  ImagePath = "Image_Path"  ,   CategoryId = 1 },
                new Product { Id = 6, Title = " Mouse pad",         Quantity = 3,  Price = 6234,    Description = "This is Description",  ImagePath = "Image_Path"  ,   CategoryId = 2 },
                new Product { Id = 7, Title = " RAM ",              Quantity = 2,  Price = 7234,    Description = "This is Description",  ImagePath = "Image_Path"  ,   CategoryId = 3 },
                new Product { Id = 8, Title = " Usb driver",        Quantity = 5,  Price = 8234,    Description = "This is Description",  ImagePath = "Image_Path"  ,   CategoryId = 4 },
                new Product { Id = 9, Title = " Hard disk ",        Quantity = 6,  Price = 9234,    Description = "This is Description",  ImagePath = "Image_Path"  ,   CategoryId = 1 },
                new Product { Id = 10,Title = " SSD ",              Quantity = 4,  Price = 10234,   Description = "This is Description",  ImagePath = "Image_Path"  ,   CategoryId = 2 },
                new Product { Id = 11,Title = " Proccessor ",       Quantity = 16, Price = 10234,   Description = "This is Description",  ImagePath = "Image_Path"  ,   CategoryId = 3 },
                new Product { Id = 12,Title = " Graphics card ",    Quantity = 26, Price = 10234,   Description = "This is Description",  ImagePath = "Image_Path"  ,   CategoryId = 4 }
           
        };
            var _Users = new List<User>
            {
            new User { Id = 1, FirstName = "Ziad"  ,LastName = "Fahmy" ,Email = "Ziad123@mail.com"   ,Password ="123 "},
                new User { Id = 2, FirstName = "Nourhan" ,  LastName = "Khalil" ,Email = "Nour123@mail.com"   ,Password ="123 "},
                new User { Id = 3, FirstName = "Rewan" , LastName = "Reda"  ,Email = "Rewan123@mail.com"   ,Password ="123 "},
                new User { Id = 4, FirstName = "Morcos"  ,LastName = "Osama" ,Email = "Morcos123@mail.com"   ,Password ="123 "}

            };



            modelBuilder.Entity<User>().HasData(_Users);
            modelBuilder.Entity<Category>().HasData(_Categories);
            modelBuilder.Entity<Product>().HasData(_Products);

        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
