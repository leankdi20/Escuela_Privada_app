using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base2.models
{
    [Table ("Estudiante")]
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public String IdEstudiante { get; set; }

        [MaxLength(50)]
        public String FirstName { get; set; }

        [MaxLength(50)]
        public String LastName { get; set; }

        [MaxLength(10)]
        public DateTime FechaNacimiento { get; set; }

        [MaxLength(50)]
        public String Cedula { get; set; }

        [MaxLength(100)]
        public String Address { get; set; }

        [MaxLength(50)]
        public String City { get; set; }

        [MaxLength(50)]
        public String Genero { get; set; }

        [MaxLength(500)]
        public String FotoPerfil { get; set; }

        [MaxLength(100)]
        public string Enfermedad { get; set; }

        [MaxLength(100)]
        public string NombreMedicina { get; set; }

        [MaxLength(500)]
        public string Descripcion { get; set; }

        [MaxLength(100)]
        public string Alergia { get; set; }

        //propiedad para la FK
        public String IdUser { get; set; }

        [Ignore]
        public Usuario Usuario { get; set; }
        // Relación con Medicinas

    }
}
