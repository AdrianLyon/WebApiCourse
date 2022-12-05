using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Dtos
{
    public class UserRegisterDto
    {
        [Required]
         public string Email { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "The password would to be between 4 and 8 characters")]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }  
        [Required]
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }

        public UserRegisterDto()
        {
            Date= DateTime.Now;
            Active = true;
        }
    }
}