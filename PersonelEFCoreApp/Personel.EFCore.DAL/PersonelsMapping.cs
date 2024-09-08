using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Personel.EFCore.Domain;


namespace Personel.EFCore.DAL
{
    public class PersonelsMapping : IEntityTypeConfiguration<Personels>
    {
        public void Configure(EntityTypeBuilder<Personels> builder)
        {
            builder.ToTable("Workers");
            builder.HasKey(p => p.PersonelID);

            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.IdentityNumber).IsRequired().HasMaxLength(12);
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Ignore(p => p.IsActive);

            builder.HasOne(p => p.Department)
                   .WithMany(d => d.Personels)
                   .HasForeignKey(p => p.DepartmentID);

            builder.HasOne(p => p.Gender)
                   .WithMany(g => g.Personels)
                   .HasForeignKey(p => p.GenderID);

            builder.HasOne(p => p.PersonelDetail)
                   .WithOne(pd => pd.Personel)
                   .HasForeignKey<PersonelDetail>(pd => pd.PersonelID);
        }
    }
}
