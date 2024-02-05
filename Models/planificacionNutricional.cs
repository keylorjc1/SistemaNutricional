namespace SistemaNutricional.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("planificacionNutricional")]
    public partial class planificacionNutricional
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idPlanificacionNutricional { get; set; }

        public int? porcentajedemasagrasa { get; set; }

        public int? metabolismobasal { get; set; }

        public int? actividadfisica { get; set; }

        public int? caloriasdiarias { get; set; }

        public int? proteinas { get; set; }

        public int? carbohidratos { get; set; }

        public int? grasas { get; set; }

        [StringLength(100)]
        public string objetivo { get; set; }

        public int? peso { get; set; }

        public int? altura { get; set; }

        public virtual datosAntropometrico datosAntropometrico { get; set; }
    }
}
