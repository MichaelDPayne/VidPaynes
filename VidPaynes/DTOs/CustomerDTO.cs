using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VidPaynes.Models;

namespace VidPaynes.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        public List<RentalDto> MoviesRented { get; set; }

        //        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}