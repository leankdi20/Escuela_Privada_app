using Base2.models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;



namespace Base2
{
    [Table("User")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public String IdUser { get; set; }

        [MaxLength(50)]
        public String FirstName { get; set; }

        [MaxLength(50)]
        public String LastName { get; set; }

        [MaxLength(100)]
        public String Email { get; set; }

        [MaxLength(100)]
        public String Password { get; set; }

        [MaxLength(15)]
        public String Phone { get; set; }

        [MaxLength(200)]
        public String Address { get; set; }

        [MaxLength(50)]
        public String City { get; set; }

        [MaxLength(500)]
        public string FotoPerfil { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        [MaxLength(50)]
        public int Edad { get; set; }

        [MaxLength(50)]
        public String Genero { get; set; }

        // Propiedad para la FK
        public int IdRol { get; set; }

        [Ignore]
        public Rol Rol { get; set; }

        // Propiedad para manejar la selección
        public bool IsSelected { get; set; }

        [Ignore]
        public string FullName => $"{FirstName} {LastName}";

    }
}
