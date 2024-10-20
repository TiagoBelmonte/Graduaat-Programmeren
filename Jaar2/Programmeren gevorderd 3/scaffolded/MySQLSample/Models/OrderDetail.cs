using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind;

[Table("OrderDetail")]
[Index("OrderId", Name = "orderId")]
[Index("ProductId", Name = "productId")]
public partial class OrderDetail
{
    [Key]
    [Column("orderDetailId")]
    public int OrderDetailId { get; set; }

    [Column("orderId")]
    public int OrderId { get; set; }

    [Column("productId")]
    public int ProductId { get; set; }

    [Column("unitPrice")]
    [Precision(10, 2)]
    public decimal UnitPrice { get; set; }

    [Column("quantity")]
    public short Quantity { get; set; }

    [Column("discount")]
    [Precision(10, 2)]
    public decimal Discount { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("OrderDetails")]
    public virtual Product Product { get; set; } = null!;
}
