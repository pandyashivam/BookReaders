using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReaders.Models
{
    public class BookModel
    {
        public string searching{ get; set; }

        public int Id { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of your book")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the author name")]
        public string Author { get; set; }

        [Required]
        public string Language { get; set; }

        public string Category { get; set; }

        [Required(ErrorMessage = "Please enter the total pages")]
        [Display(Name = "Total pages of book")]
        public int Pages { get; set; }

        [Required]
        public int Price { get; set; }

          [StringLength(500)]
        public string Description { get; set; }


        [Required]
       public string ImageUrl { get; set; }


    }
}
