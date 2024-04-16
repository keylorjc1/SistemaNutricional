namespace WebNutricion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class valoresNutricionale
    {
        [Key]
        public int idValores { get; set; }

        [StringLength(300)]
        public string motivo { get; set; }

        [StringLength(300)]
        public string expectativas { get; set; }

        [StringLength(300)]
        public string informacionConsulta { get; set; }

        [StringLength(300)]
        public string historial { get; set; }

        [StringLength(9)]
        public string Cedula { get; set; }

        public DateTime? fecha { get; set; }

        [StringLength(128)]
        public string idUser { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
