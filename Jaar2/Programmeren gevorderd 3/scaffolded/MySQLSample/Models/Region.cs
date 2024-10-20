using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind;

[Table("Region")]
public partial class Region
{
    [Key]
    [Column("regionId")]
    public int RegionId { get; set; }

    [Column("regiondescription")]
    [StringLength(50)]
    public string Regiondescription { get; set; } = null!;

    [InverseProperty("Region")]
    public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
}
