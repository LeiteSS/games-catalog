using games.api.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace games.api.Infraestructure.Data.Mapping
{
    public class GameMapping : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("TB_GAME");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name);
            builder.Property(p => p.Producer);
            builder.Property(p => p.Price);
        }
    }
}