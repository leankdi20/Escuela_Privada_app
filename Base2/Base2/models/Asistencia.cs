using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base2.models
{
    [Table ("Asistencia")]
    class Asistencia
    {
        [PrimaryKey, AutoIncrement]
        public int IdAsistencia { get; set; }

        [MaxLength(50)]
        public DateTime Date { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }

        // Propiedad para la FK
        public int IdEstudiante { get; set; }

        // Relación con Estudiante
        [Ignore]
        public Estudiante Estudiante { get; set; }
    }
}
