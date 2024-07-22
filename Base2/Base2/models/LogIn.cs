using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base2
{
    [Table("LogIn")]
    public class LogIn
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }

        // Propiedad para la FK
        public int IdUser { get; set; }

        // Relación con Usuario
        [Ignore]
        public Usuario Usuario { get; set; }

    }
}
