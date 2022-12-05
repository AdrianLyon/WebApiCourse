using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Dtos
{
    public class UserListDto
    {
         public int Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }  
        public string? Phone { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
    }
}