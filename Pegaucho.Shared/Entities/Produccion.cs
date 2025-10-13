using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pegaucho.Shared.Entities
{
    public class Produccion
    {
        [Key]
        public int idLogin { get; set; }


        /*[Required(ErrorMessage = "El campo es obligatorio")]*/
        /*[MaxLength(100, ErrorMessage = "El campo no puede tener mas caracteres")]*/
        public string usuario { get; set; } = null!;
        public string contrasena { get; set; } = null!;
    }
}
