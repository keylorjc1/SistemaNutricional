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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idValores { get; set; }

        [StringLength(300)]
        public string informacionConsulta { get; set; }

        [StringLength(300)]
        public string historial { get; set; }
    }
}
