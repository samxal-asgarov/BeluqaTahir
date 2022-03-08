using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeluqaTahir.Domain.Model.Entity
{
   public class HappyClients:BaseEntity
    {
        public string ImagePati { get; set; }
        public string FullName { get; set; }
        public string Answer { get; set; }
        public string Description { get; set; }

    }
}
