using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind;

[Table("Shipper")]
public partial class Shipper
{
    [Key]
    [Column("shipperId")]
    public int ShipperId { get; set; }

    [Column("companyName")]
    [StringLength(40)]
    public string CompanyName { get; set; } = null!;

    [Column("phone")]
    [StringLength(44)]
    public string? Phone { get; set; }

    [InverseProperty("Shipper")]
    public virtual ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();
}
