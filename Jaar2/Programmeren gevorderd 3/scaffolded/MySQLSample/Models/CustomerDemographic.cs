using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind;

public partial class CustomerDemographic
{
    [Key]
    [Column("customerTypeId")]
    public int CustomerTypeId { get; set; }

    [Column("customerDesc", TypeName = "text")]
    public string? CustomerDesc { get; set; }

    [ForeignKey("CustomerTypeId")]
    [InverseProperty("CustomerTypes")]
    public virtual ICollection<Customer> Custs { get; set; } = new List<Customer>();
}
