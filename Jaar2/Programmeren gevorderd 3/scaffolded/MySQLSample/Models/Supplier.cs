using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind;

[Table("Supplier")]
public partial class Supplier
{
    [Key]
    [Column("supplierId")]
    public int SupplierId { get; set; }

    [Column("companyName")]
    [StringLength(40)]
    public string CompanyName { get; set; } = null!;

    [Column("contactName")]
    [StringLength(30)]
    public string? ContactName { get; set; }

    [Column("contactTitle")]
    [StringLength(30)]
    public string? ContactTitle { get; set; }

    [Column("address")]
    [StringLength(60)]
    public string? Address { get; set; }

    [Column("city")]
    [StringLength(15)]
    public string? City { get; set; }

    [Column("region")]
    [StringLength(15)]
    public string? Region { get; set; }

    [Column("postalCode")]
    [StringLength(10)]
    public string? PostalCode { get; set; }

    [Column("country")]
    [StringLength(15)]
    public string? Country { get; set; }

    [Column("phone")]
    [StringLength(24)]
    public string? Phone { get; set; }

    [Column("email")]
    [StringLength(225)]
    public string? Email { get; set; }

    [Column("fax")]
    [StringLength(24)]
    public string? Fax { get; set; }

    [Column(TypeName = "text")]
    public string? HomePage { get; set; }

    [InverseProperty("Supplier")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
