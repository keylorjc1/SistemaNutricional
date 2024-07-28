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
        public int idPlan { get; set; }
        [Required(ErrorMessage = "El desayuno es obligatorio.")]
        [StringLength(300, ErrorMessage = "El desayuno no puede exceder los 300 caracteres.")]
        public string desayuno { get; set; }

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

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
