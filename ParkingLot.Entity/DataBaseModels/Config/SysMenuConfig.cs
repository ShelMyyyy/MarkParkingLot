using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingLot.Models.DataBaseModels.Config
{
    public class SysMenuConfig : IEntityTypeConfiguration<SysMenu>
    {
        public void Configure(EntityTypeBuilder<SysMenu> builder)
        {
            builder.ToTable("menus");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("menu_id");
            builder.Property(x => x.Header).HasColumnName("menu_header");
            builder.Property(x => x.TargetView).HasColumnName("target_view");
            builder.Property(x => x.ParentId).HasColumnName("parent_id");
            builder.Property(x => x.MenuIcon).HasColumnName("menu_icon");
            builder.Property(x => x.Index).HasColumnName("_index");
            builder.Property(x => x.MenuType).HasColumnName("menu_type");
            builder.Property(x => x.State).HasColumnName("state");
        }
    }
}
