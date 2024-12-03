using FitnessBL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnesDataEF.Model
{
    public class ProgrammaEF
    {
        public ProgrammaEF()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string naam { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public string doelpubliek { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public DateTime startdatum { get; set; }

        [Required]
        public int maxLeden { get; set; }

        // Relatie met klanten
        public List<KlantEF> Klanten { get; set; } 

    }
}
