using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind;

[PrimaryKey("OrderId", "CustId")]
[Table("SalesOrder")]
[Index("CustId", Name = "custId")]
[Index("Shipperid", Name = "shipperid")]
public partial class SalesOrder
{
    [Key]
    [Column("orderId")]
    public int OrderId { get; set; }

    [Key]
    [Column("custId")]
    public int CustId { get; set; }

    [Column("employeeId")]
    public int? EmployeeId { get; set; }

    [Column("orderDate", TypeName = "datetime")]
    public DateTime? OrderDate { get; set; }

    [Column("requiredDate", TypeName = "datetime")]
    public DateTime? RequiredDate { get; set; }

    [Column("shippedDate", TypeName = "datetime")]
    public DateTime? ShippedDate { get; set; }

    [Column("shipperid")]
    public int Shipperid { get; set; }

    [Column("freight")]
    [Precision(10, 2)]
    public decimal? Freight { get; set; }

    [Column("shipName")]
    [StringLength(40)]
    public string? ShipName { get; set; }

    [Column("shipAddress")]
    [StringLength(60)]
    public string? ShipAddress { get; set; }

    [Column("shipCity")]
    [StringLength(15)]
    public string? ShipCity { get; set; }

    [Column("shipRegion")]
    [StringLength(15)]
    public string? ShipRegion { get; set; }

    [Column("shipPostalCode")]
    [StringLength(10)]
    public string? ShipPostalCode { get; set; }

    [Column("shipCountry")]
    [StringLength(15)]
    public string? ShipCountry { get; set; }

    [ForeignKey("CustId")]
    [InverseProperty("SalesOrders")]
    public virtual Customer Cust { get; set; } = null!;

    [ForeignKey("Shipperid")]
    [InverseProperty("SalesOrders")]
    public virtual Shipper Shipper { get; set; } = null!;
}
