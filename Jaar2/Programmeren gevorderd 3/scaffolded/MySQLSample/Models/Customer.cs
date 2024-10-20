using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind;

[Table("Customer")]
public partial class Customer
{
    [Key]
    [Column("custId")]
    public int CustId { get; set; }

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

    [Column("mobile")]
    [StringLength(24)]
    public string? Mobile { get; set; }

    [Column("email")]
    [StringLength(225)]
    public string? Email { get; set; }

    [Column("fax")]
    [StringLength(24)]
    public string? Fax { get; set; }

    [InverseProperty("Cust")]
    public virtual ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();

    [ForeignKey("CustId")]
    [InverseProperty("Custs")]
    public virtual ICollection<CustomerDemographic> CustomerTypes { get; set; } = new List<CustomerDemographic>();
}
