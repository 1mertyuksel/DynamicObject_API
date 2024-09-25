using EntityLayer.Models.Abstract;
using System;

namespace EntityLayer.Models.Concrete
{
    public class TransactionLog : BaseEntity
    {
        public string OperationType { get; set; }         // Yapılan işlemin türü (örneğin: Create, Update, Delete)
        public string ObjectType { get; set; }            // İşlem yapılan nesnenin türü (örneğin: DynamicObject, DynamicField)
        public string? Description { get; set; }          // İşlem ile ilgili ek açıklama (isteğe bağlı)

        // İlişki referansları (nullable, çünkü işlem yalnızca bir tür üzerinde olabilir)
        public int? DynamicObjectId { get; set; }         // İlgili DynamicObject ID'si
        public virtual DynamicObject? DynamicObject { get; set; }

        public int? DynamicFieldId { get; set; }          // İlgili DynamicField ID'si
        public virtual DynamicField? DynamicField { get; set; }
    }
}
