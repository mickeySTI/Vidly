using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {   
        //In entity framework, every entity must have a key. Id = Key 
        public byte Id { get; set; }
        public short SignUpFee { get; set; }

        public byte DurationInMonths { get; set; }
        [Required]
        public string Name { get; set; }

        public byte DiscountRate { get; set; }

        




    }
}