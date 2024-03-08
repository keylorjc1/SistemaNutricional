namespace WebNutricion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("planAlimentacion")]
    public partial class planAlimentacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idPlan { get; set; }

        [StringLength(100)]
        public string comida { get; set; }

        [StringLength(100)]
        public string alimentos { get; set; }

        public int? calorias { get; set; }
    }
}
