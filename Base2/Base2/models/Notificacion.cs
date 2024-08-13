using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base2.models
{
    [Table("Notificacion")]
    public class Notificacion
    {
        [PrimaryKey, AutoIncrement]
        public string IdNotificacion { get; set; }

        [MaxLength(100)]
        public string Titulo { get; set; }

        [MaxLength(500)]
        public string Mensaje { get; set; }
        
        [MaxLength(50)]
        public DateTime Fecha { get; set; }

        public bool Leida { get; set; }

        // Propiedad para la FK
        public string IdUser { get; set; }

        // Relación con Usuario
        [Ignore]
        public Usuario Usuario { get; set; }
        
    }
}
