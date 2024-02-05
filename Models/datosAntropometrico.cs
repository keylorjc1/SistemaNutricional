namespace SistemaNutricional.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("datosAntropometricos")]
    public partial class datosAntropometrico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDatos { get; set; }

        public int? peso { get; set; }

        public int? altura { get; set; }

        public int? IMC { get; set; }

        public int? grasacorporal { get; set; }

        [StringLength(100)]
        public string datosAnaliticos { get; set; }

        [StringLength(100)]
        public string progreso { get; set; }

        public virtual planificacionNutricional planificacionNutricional { get; set; }
    }
}
