using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace PM2P2T4.Models
{
   public class Fotos
    {
        [PrimaryKey, AutoIncrement]
        public int codigo { get; set; }

        [MaxLength(150)]
        public String nombre { get; set; }

        [MaxLength(255)]
        public String descripcion { get; set; }

        public String pathFile { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
}
