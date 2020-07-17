using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        // Overriding default conventions = Data Annotations
        // This makes the string Name no longer nullable
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        //Navigation Property
        public MembershipType MembershipType { get; set; }

        //This is to get the foreign key instead of getting the whole object.
        public byte MembershipTypeId { get; set; }

       





    }
}