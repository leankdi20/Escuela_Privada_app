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
        public string IdAviso { get; set; }

        [MaxLength(50)]
        public String TipoAviso { get; set; }


        [MaxLength(10)]
        public DateTime FechaEnvio { get; set; }
      
        [MaxLength(500)]
        public string Mensaje { get; set; }

        //propiedad para la FK
        public String IdUser { get; set; }

        public String IdEstudiante { get; set; }

        [Ignore]
        public Usuario Usuario { get; set; }
        // Relación con Medicinas
    }
}
