using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base2.models
{
    [Table("Rol")]
    public class Rol
    {
        [PrimaryKey, AutoIncrement]
        public int IdRol { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
    }
}
