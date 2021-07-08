using BuildingManager.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingManager.DataAccess.Concrete.EntityFramework.Configurations
{
    public class BuildingConfiguration:IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
        }
    }
}