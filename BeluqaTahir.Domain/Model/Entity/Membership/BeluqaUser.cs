using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeluqaTahir.Domain.Model.Entity.Membership
{
    public class BeluqaUser:IdentityUser<int>
    {
        public bool Activates { get; set; }

    }
}
