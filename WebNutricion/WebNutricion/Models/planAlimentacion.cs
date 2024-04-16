namespace WebNutricion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("planAlimentacion")]
    public partial class planAlimentacion
    {
        [Key]
        [HiddenInput]

        public int idPlan { get; set; }

        [StringLength(300)]
        public string desayuno { get; set; }

        [StringLength(300)]
        public string almuerzo { get; set; }

        [StringLength(300)]
        public string merienda { get; set; }

        [StringLength(300)]
        public string cena { get; set; }

        [StringLength(50)]
        public string calorias { get; set; }

        [StringLength(9)]
        public string Cedula { get; set; }


        public DateTime? fecha { get; set; }

        [StringLength(128)]
        public string idUser { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
