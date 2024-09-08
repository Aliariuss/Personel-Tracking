using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Personel.EFCore.Domain;

namespace Personel.EFCore.DAL
{
    public class PersonelDetailMapping : IEntityTypeConfiguration<PersonelDetail>
    {
        public void Configure(EntityTypeBuilder<PersonelDetail> builder)
        {
            builder.ToTable("PersonelDetails");
            builder.HasKey(pd => pd.PersonelDetailID);

            builder.Property(pd => pd.Email).IsRequired(false).HasMaxLength(50);
            builder.Property(pd => pd.Phone).IsRequired().HasMaxLength(15);

            builder.HasMany(pd => pd.Addresses)
                   .WithOne(a => a.PersonelDetail)
                   .HasForeignKey(a => a.PersonelDetailID);
        }
    }

}
