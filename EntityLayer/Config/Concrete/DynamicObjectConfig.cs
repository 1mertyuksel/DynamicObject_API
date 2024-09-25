using EntityLayer.Models.Concrete;
using EntityLayer.Config.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EntityLayer.Config.Concrete
{
    public class DynamicObjectConfig : BaseConfig<DynamicObject>
    {
        public override void Configure(EntityTypeBuilder<DynamicObject> builder)
        {
            base.Configure(builder);
            builder.Property(df => df.ObjectName)
               .IsRequired()            
               .HasMaxLength(50);    


            builder.HasMany(df => df.DynamicFields)
                   .WithOne(df => df.DynamicObject)
                   .HasForeignKey(df => df.DynamicObjectId)
                   .OnDelete(DeleteBehavior.Cascade); 

            builder.HasMany(tl => tl.TransactionLogs)
                   .WithOne(tl => tl.DynamicObject)
                   .HasForeignKey(tl => tl.DynamicObjectId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
