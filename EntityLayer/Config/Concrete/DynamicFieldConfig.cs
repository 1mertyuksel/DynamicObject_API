using EntityLayer.Models.Concrete;
using EntityLayer.Config.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EntityLayer.Config.Concrete
{
    public class DynamicFieldConfig : BaseConfig<DynamicField>
    {
        public override void Configure(EntityTypeBuilder<DynamicField> builder)
        {
            base.Configure(builder); // Call the base configuration

            // Configuring properties
            builder.Property(df => df.FieldName)
                .IsRequired()             // FieldName is required
                .HasMaxLength(100);      // Max length for FieldName

            builder.Property(df => df.FieldValue)
                .IsRequired()             // FieldValue is required
                .HasMaxLength(500);      // Max length for FieldValue

            builder.Property(df => df.DynamicObjectId)
                .IsRequired();            // DynamicObjectId is required

            // Configuring relationships if necessary
            builder.HasOne(df => df.DynamicObject)
                .WithMany()              // Assuming DynamicObject has a collection of DynamicField
                .HasForeignKey(df => df.DynamicObjectId)  // Foreign key configuration
                .OnDelete(DeleteBehavior.Cascade); // Define delete behavior if needed
        }
    }
}
