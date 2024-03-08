namespace WebNutricion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cita
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }

        public TimeSpan hora { get; set; }
    }
}
