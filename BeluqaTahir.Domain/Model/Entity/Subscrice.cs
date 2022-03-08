using System;
using System.ComponentModel.DataAnnotations;

namespace BeluqaTahir.Domain.Model.Entity
{
    public class Subscrice : BaseEntity
    {
        [EmailAddress]
        public string Email { get; set; }
        public bool? EmailConfirmed { get; set; }
        public DateTime? EmailConfirmedDate { get; set; }
    }
}
