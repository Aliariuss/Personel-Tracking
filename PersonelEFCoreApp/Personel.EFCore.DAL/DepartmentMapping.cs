using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Personel.EFCore.Domain;


namespace Personel.EFCore.DAL
{
    public class DepartmentMapping : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            {
                builder.ToTable("Departments");
                builder.HasKey(d => d.DepartmentID);

                builder.Property(d => d.DepartmentName).IsRequired().HasMaxLength(100);
            }
        }
    }
}
