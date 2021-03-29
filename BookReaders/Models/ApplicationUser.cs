using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReaders.Models
{
    public class ApplicationUser : IdentityUser
    {
       
        public string FistName { get; set; } 

        
        public string LastName { get; set; }



        public string Address { get; set; }

      
    }
}
