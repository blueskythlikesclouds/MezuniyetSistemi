using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Abstract
{
    public abstract class EntityBase : IEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Hard Delete islemleri disinda
        public virtual bool IsDeleted { get; set; } = false;

        // Ban - Yasaklama - Aktiflik Durumu kontrolu
        public virtual bool IsActive { get; set; } = true;
        public virtual string CreatedByName { get; set; } = "Admin";

        // Guncelleme isleminden sonra ezilmesi gereken alan
        public virtual string ModifiedByName { get; set; } = "Admin";
        public virtual string? Note { get; set; } = "Not Girilmemiş";
    }
}
