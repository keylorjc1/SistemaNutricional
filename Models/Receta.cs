namespace SistemaNutricional.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Receta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Ingredientes { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string PasosPreparacion { get; set; }
    }
}
