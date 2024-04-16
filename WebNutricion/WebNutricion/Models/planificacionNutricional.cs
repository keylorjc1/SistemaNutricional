namespace WebNutricion.Models
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
        public int idPlanificacionNutricional { get; set; }

        public int? peso { get; set; }

        public int? altura { get; set; }

        public int? IMC { get; set; }

        public int? grasacorporal { get; set; }

        public int? metabolismobasal { get; set; }

        public int? caloriasdiarias { get; set; }

        public int? proteinas { get; set; }

        public int? carbohidratos { get; set; }

        public int? grasas { get; set; }

        [StringLength(100)]
        public string objetivo { get; set; }

        [StringLength(9)]
        public string Cedula { get; set; }

        public DateTime? fecha { get; set; }

        [StringLength(128)]
        public string idUser { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
