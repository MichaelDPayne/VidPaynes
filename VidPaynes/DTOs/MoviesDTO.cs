using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidPaynes.Models;

namespace VidPaynes.DTOs
{
    public class MoviesDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }

        public DateTime? DateAdded { get; set; }
        
        [Required]
        public DateTime? DateReleased { get; set; }

        [Range(1, 20)]
        public int Stock { get; set; }
    }
}