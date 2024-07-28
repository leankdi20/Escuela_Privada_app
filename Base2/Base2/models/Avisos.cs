using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base2.models
{
    [Table("Avisos")]
    public class Avisos
    {
        [PrimaryKey, AutoIncrement]
        public int IdAviso { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Contenido { get; set; }
        
        [MaxLength(50)]
        public DateTime Date { get; set; }

        // Propiedad para la FK
        public int IdUser { get; set; }

        // Relación con Usuario
        [Ignore]
        public Usuario Usuario { get; set; }
        
    }
}
