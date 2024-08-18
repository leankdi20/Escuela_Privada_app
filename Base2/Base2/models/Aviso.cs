using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base2
{

    [Table ("Aviso")]
    public class Aviso
    {

        [PrimaryKey, AutoIncrement]
        public String IdAviso { get; set; }

        [MaxLength(50)]
        public String TipoAviso { get; set; }


        
        public DateTime FechaEnvio { get; set; }
      
        [MaxLength(500)]
        public string Mensaje { get; set; }

        //propiedad para la FK
        public List<string> IdUsers { get; set; }

        public String IdEstudiante { get; set; }

        [Ignore]
        public Usuario Usuario { get; set; }
        // Relación con Medicinas
    }
}
