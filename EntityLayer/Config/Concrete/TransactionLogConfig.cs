using EntityLayer.Models.Concrete;
using EntityLayer.Config.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EntityLayer.Config.Concrete
{
    public class TransactionLogConfig : BaseConfig<TransactionLog>
    {
        public override void Configure(EntityTypeBuilder<TransactionLog> builder)
        {
            base.Configure(builder); 

            builder.HasOne(tl => tl.DynamicObject)
                   .WithMany(tl => tl.TransactionLogs)
                   .HasForeignKey(tl => tl.DynamicObjectId)
                   .OnDelete(DeleteBehavior.SetNull); 

            
            builder.HasOne(tl => tl.DynamicField)
                   .WithMany()
                   .HasForeignKey(tl => tl.DynamicFieldId)
                   .OnDelete(DeleteBehavior.SetNull); 
        }
    }
}
