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
        public int IdEstudiante { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        //propiedad para la FK
        public int IdUser { get; set; }

        [Ignore]
        public Usuario Usuario { get; set; }
       
    }
}
