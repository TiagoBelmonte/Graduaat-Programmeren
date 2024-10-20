using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind;

[Table("Product")]
[Index("CategoryId", Name = "categoryId")]
[Index("SupplierId", Name = "supplierId")]
public partial class Product
{
    [Key]
    [Column("productId")]
    public int ProductId { get; set; }

    [Column("productName")]
    [StringLength(40)]
    public string ProductName { get; set; } = null!;

    [Column("supplierId")]
    public int? SupplierId { get; set; }

    [Column("categoryId")]
    public int? CategoryId { get; set; }

    [Column("quantityPerUnit")]
    [StringLength(20)]
    public string? QuantityPerUnit { get; set; }

    [Column("unitPrice")]
    [Precision(10, 2)]
    public decimal? UnitPrice { get; set; }

    [Column("unitsInStock")]
    public short? UnitsInStock { get; set; }

    [Column("unitsOnOrder")]
    public short? UnitsOnOrder { get; set; }

    [Column("reorderLevel")]
    public short? ReorderLevel { get; set; }

    [Column("discontinued")]
    [StringLength(1)]
    public string Discontinued { get; set; } = null!;

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category? Category { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [ForeignKey("SupplierId")]
    [InverseProperty("Products")]
    public virtual Supplier? Supplier { get; set; }
}
