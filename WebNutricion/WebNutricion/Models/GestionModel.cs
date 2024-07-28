﻿using System;
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
        [Required(ErrorMessage = "El desayuno es obligatorio.")]
        [StringLength(300, ErrorMessage = "El desayuno no puede exceder los 300 caracteres.")]
        public string Desayuno { get; set; }

        [Required(ErrorMessage = "El almuerzo es obligatorio.")]
        [StringLength(300, ErrorMessage = "El almuerzo no puede exceder los 300 caracteres.")]
        public string almuerzo { get; set; }

        [Required(ErrorMessage = "La merienda es obligatoria.")]
        [StringLength(300, ErrorMessage = "La merienda no puede exceder los 300 caracteres.")]
        public string merienda { get; set; }

        [Required(ErrorMessage = "La cena es obligatoria.")]
        [StringLength(300, ErrorMessage = "La cena no puede exceder los 300 caracteres.")]
        public string cena { get; set; }

        [Required(ErrorMessage = "Las calorías son obligatorias.")]
        [StringLength(50, ErrorMessage = "Las calorías no pueden exceder los 50 caracteres.")]
        public string calorias { get; set; }

        [StringLength(9)]
        public string Cedula { get; set; }
      
        public DateTime? fecha { get; set; }

        [StringLength(128)]
        public string idUser { get; set; }

    }

    public class PlanificacionNutricional
    {
        [Required(ErrorMessage = "El peso es obligatorio.")]
        [Range(0, 300, ErrorMessage = "El peso debe estar entre 0 y 300 kg.")]
        public int? peso { get; set; }
        [Required(ErrorMessage = "La altura es obligatoria.")]
        [Range(0, 250, ErrorMessage = "La altura debe estar entre 0 y 250 cm.")]
        public int? altura { get; set; }
        [Required(ErrorMessage = "El IMC es obligatorio.")]
        [Range(0, 100, ErrorMessage = "El IMC debe estar entre 0 y 100.")]
        public int? IMC { get; set; }
        [Required(ErrorMessage = "La grasa corporal es obligatoria.")]
        [Range(0, 100, ErrorMessage = "La grasa corporal debe estar entre 0 y 100%.")]
        public int? grasacorporal { get; set; }
        [Required(ErrorMessage = "El metabolismo basal es obligatorio.")]
        [Range(0, 5000, ErrorMessage = "El metabolismo basal debe estar entre 0 y 5000 kcal.")]
        public int? metabolismobasal { get; set; }
        [Required(ErrorMessage = "Las calorías diarias son obligatorias.")]
        [Range(0, 10000, ErrorMessage = "Las calorías diarias deben estar entre 0 y 10000 kcal.")]
        public int? caloriasdiarias { get; set; }
        [Required(ErrorMessage = "Las proteínas son obligatorias.")]
        [Range(0, 500, ErrorMessage = "Las proteínas deben estar entre 0 y 500 g.")]
        public int? proteinas { get; set; }
        [Required(ErrorMessage = "Los carbohidratos son obligatorios.")]
        [Range(0, 1000, ErrorMessage = "Los carbohidratos deben estar entre 0 y 1000 g.")]
        public int? carbohidratos { get; set; }
        [Required(ErrorMessage = "Las grasas son obligatorias.")]
        [Range(0, 500, ErrorMessage = "Las grasas deben estar entre 0 y 500 g.")]
        public int? grasas { get; set; }

        [Required(ErrorMessage = "El objetivo es obligatorio.")]
        [StringLength(100, ErrorMessage = "El objetivo no puede exceder los 100 caracteres.")]
        public string objetivo { get; set; }

        [StringLength(9)]
        public string Cedula { get; set; }
      
        public DateTime? fecha { get; set; }

        [StringLength(128)]
        public string idUser { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }

}
