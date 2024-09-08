using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Personel.EFCore.Domain;


namespace Personel.EFCore.DAL
{
    public class GenderMapping : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            {
                builder.ToTable("Genders");
                builder.HasKey(g => g.GenderID);

                builder.Property(g => g.GenderName).IsRequired().HasMaxLength(10);
                builder.Property(g => g.State).IsRequired();
            }
        }
    }
}
