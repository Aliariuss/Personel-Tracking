using Microsoft.EntityFrameworkCore;
using Personel.EFCore.Domain;


namespace Personel.EFCore.DAL
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MSI;Initial Catalog=PersonelDB;User ID=TestUser;Password=admin123;TrustServerCertificate=true");
        }

        public DbSet<Personels> Workers { get; set; }
        public DbSet<PersonelDetail> PersonelDetails { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new PersonelsMapping().Configure(modelBuilder.Entity<Personels>());
            new PersonelDetailMapping().Configure(modelBuilder.Entity<PersonelDetail>());
            new DepartmentMapping().Configure(modelBuilder.Entity<Department>());
            new GenderMapping().Configure(modelBuilder.Entity<Gender>());
            new AddressMapping().Configure(modelBuilder.Entity<Address>());

            modelBuilder.Entity<Department>().HasData(
            new Department { DepartmentID = 1, DepartmentName = "Yazılım" },
            new Department { DepartmentID = 2, DepartmentName = "İnsan Kaynakları" },
            new Department { DepartmentID = 3, DepartmentName = "Yazar" },
            new Department { DepartmentID = 4, DepartmentName = "Pazarlamacı" }
        );
            modelBuilder.Entity<Gender>().HasData(
            new Gender { GenderID = 1, GenderName = "Erkek" },
            new Gender { GenderID = 2, GenderName = "Kadın" }
        );
            modelBuilder.Entity<Personels>().HasData(
                new Personels
                {
                    PersonelID = 1,
                    FirstName = "Ali",
                    LastName = "Kılıç",
                    IdentityNumber = "12345678901",
                    BirthDate = new DateTime(1985, 5, 20),
                    IsActive = true,
                    DepartmentID = 1,
                    GenderID = 1
                },
                new Personels
                {
                    PersonelID = 2,
                    FirstName = "Ayşe",
                    LastName = "Yılmaz",
                    IdentityNumber = "12345678902",
                    BirthDate = new DateTime(1990, 10, 10),
                    IsActive = true,
                    DepartmentID = 2,
                    GenderID = 2
                },
                new Personels
                {
                    PersonelID = 3,
                    FirstName = "Ahmet",
                    LastName = "Demir",
                    IdentityNumber = "12345678903",
                    BirthDate = new DateTime(1995, 3, 15),
                    IsActive = true,
                    DepartmentID = 3,
                    GenderID = 1
                },
                new Personels
                {
                    PersonelID = 4,
                    FirstName = "Fatma",
                    LastName = "Öztürk",
                    IdentityNumber = "12345678904",
                    BirthDate = new DateTime(1988, 7, 25),
                    IsActive = true,
                    DepartmentID = 4,
                    GenderID = 2
                },
                new Personels
                {
                    PersonelID = 5,
                    FirstName = "Mehmet",
                    LastName = "Ak",
                    IdentityNumber = "12345678905",
                    BirthDate = new DateTime(1983, 12, 1),
                    IsActive = true,
                    DepartmentID = 1,
                    GenderID = 1
                }
                );

            modelBuilder.Entity<PersonelDetail>().HasData(

                new PersonelDetail
                {
                    PersonelDetailID = 1,
                    PersonelID = 1,
                    Email = "ali.kilic@example.com",
                    Phone = "555-1234"
                },
                new PersonelDetail
                {
                    PersonelDetailID = 2,
                    PersonelID = 2,
                    Email = "ayse.yilmaz@example.com",
                    Phone = "555-5678"
                },
                new PersonelDetail
                {
                    PersonelDetailID = 3,
                    PersonelID = 3,
                    Email = "ahmet.demir@example.com",
                    Phone = "555-9101"
                },
                new PersonelDetail
                {
                    PersonelDetailID = 4,
                    PersonelID = 4,
                    Email = "fatma.ozturk@example.com",
                    Phone = "555-1122"
                },
                new PersonelDetail
                {
                    PersonelDetailID = 5,
                    PersonelID = 5,
                    Email = "mehmet.ak@example.com",
                    Phone = "555-1314"
                }
            );

            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    AddressID = 1,
                    City = "Istanbul",
                    Country = "Turkey",
                    PostalCode = "34000",
                    Region = "Marmara",
                    PersonelDetailID = 1
                },
                new Address
                {
                    AddressID = 2,
                    City = "Ankara",
                    Country = "Turkey",
                    PostalCode = "06000",
                    Region = "Anadolu",
                    PersonelDetailID = 2
                },
                new Address
                {
                    AddressID = 3,
                    City = "Izmir",
                    Country = "Turkey",
                    PostalCode = "35000",
                    Region = "Ege",
                    PersonelDetailID = 3
                },
                new Address
                {
                    AddressID = 4,
                    City = "Antalya",
                    Country = "Turkey",
                    PostalCode = "07000",
                    Region = "Akdeniz",
                    PersonelDetailID = 4
                },
                new Address
                {
                    AddressID = 5,
                    City = "Bursa",
                    Country = "Turkey",
                    PostalCode = "16000",
                    Region = "Marmara",
                    PersonelDetailID = 5
                }
            );
        }
    }
}
