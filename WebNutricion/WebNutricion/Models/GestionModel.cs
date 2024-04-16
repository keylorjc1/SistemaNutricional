using System;
using System.ComponentModel.DataAnnotations;

namespace WebNutricion.Models
{
    public class GestionModel
    {
        public string UserId { get; set; }

        public PlanAlimentacion PlanAlimentacion { get; set; }

        public PlanificacionNutricional PlanificacionNutricional { get; set; }

    }

    public class PlanAlimentacion
    {
        public string Desayuno { get; set; }

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

    }

    public class PlanificacionNutricional
    {
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
