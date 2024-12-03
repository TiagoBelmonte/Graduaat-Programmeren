using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Model
{
    public class ReservatieEF
    {
        public ReservatieEF() 
        { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime datum { get; set; }
        [Required]
        public KlantEF KlantEF { get; set; }
        [Required]
        //Lijst van tijdsloten moeten hier nog komen
    }
}
