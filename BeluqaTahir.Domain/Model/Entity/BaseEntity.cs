using BeluqaTahir.Domain.Model.Entity.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeluqaTahir.Domain.Model.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateData { get; set; } = DateTime.Now;
        public DateTime? DeleteData { get; set; }

        public virtual BeluqaUser CreateByUser { get; set; }
        public int? CreateByUserId { get; set; }

        public virtual BeluqaUser DeleteByUser { get; set; }

        public int? DeleteByUserId { get; set; }

    }
}
