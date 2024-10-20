using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind;

[Table("Territory")]
[Index("RegionId", Name = "regionId")]
public partial class Territory
{
    [Key]
    [Column("territoryId")]
    [StringLength(20)]
    public string TerritoryId { get; set; } = null!;

    [Column("territorydescription")]
    [StringLength(50)]
    public string Territorydescription { get; set; } = null!;

    [Column("regionId")]
    public int RegionId { get; set; }

    [ForeignKey("RegionId")]
    [InverseProperty("Territories")]
    public virtual Region Region { get; set; } = null!;

    [ForeignKey("TerritoryId")]
    [InverseProperty("Territories")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
