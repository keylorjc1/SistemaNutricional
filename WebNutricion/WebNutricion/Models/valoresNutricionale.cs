namespace WebNutricion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class valoresNutricionale
    {
        [Key]
        public int idValores { get; set; }

        [Required(ErrorMessage = "El motivo es obligatorio.")]
        [StringLength(300, ErrorMessage = "El motivo no puede tener m�s de 300 caracteres.")]
        public string motivo { get; set; }

        [Required(ErrorMessage = "Las expectativas son obligatorias.")]
        [StringLength(300, ErrorMessage = "Las expectativas no pueden tener m�s de 300 caracteres.")]
        public string expectativas { get; set; }

        [Required(ErrorMessage = "La informaci�n de consulta es obligatoria.")]
        [StringLength(300, ErrorMessage = "La informaci�n de consulta no puede tener m�s de 300 caracteres.")]
        public string informacionConsulta { get; set; }

        [Required(ErrorMessage = "El historial es obligatorio.")]
        [StringLength(300, ErrorMessage = "El historial no puede tener m�s de 300 caracteres.")]
        public string historial { get; set; }

        [StringLength(9)]
        public string Cedula { get; set; }

        public DateTime? fecha { get; set; }

        [StringLength(128)]
        public string idUser { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
