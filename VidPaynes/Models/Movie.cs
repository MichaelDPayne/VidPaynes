using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidPaynes.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }
        
        [Display(Name = "Date Of Release")]
        [Required]
        public DateTime? DateReleased { get; set; }

        [Display(Name = "Stock Remaining")]
        [Range(1, 20)]
        public int Stock { get; set; }

        public int StockAvailable { get; set; }
    }
}