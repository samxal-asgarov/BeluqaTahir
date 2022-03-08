using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeluqaTahir.Domain.Model.Entity
{
   public class Contact:BaseEntity
    {
        [Required] 
        public string Name { get; set; }

        [Required]
        [EmailAddress] 

        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Content { get; set; }

        public string Answer { get; set; } 

        public DateTime? AnswerdData { get; set; } 

        public int? AnswerByUserId { get; set; } 
    }
}
