using FitnessBL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnesDataEF.Model
{
    public class KlantEF
    {
        public KlantEF() 
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string voornaam { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(45)")]
        public string familienaam { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(45)")]
        public string email { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string verblijfplaats { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public DateTime geboorteDatum { get; set; }
        [Required]
        public KlantType type { get; set; }
        public List<String> interesses { get; set; }
        
    }
}
