using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Personel.EFCore.Domain;


namespace Personel.EFCore.DAL
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey(a => a.AddressID);

            builder.Property(a => a.City).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Country).IsRequired().HasMaxLength(50);
            builder.Property(a => a.PostalCode).IsRequired(false).HasMaxLength(10);
            builder.Property(a => a.Region).IsRequired(false).HasMaxLength(50);
        }
    }
}
