using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind;

[Table("Category")]
public partial class Category
{
    [Key]
    [Column("categoryId")]
    public int CategoryId { get; set; }

    [Column("categoryName")]
    [StringLength(15)]
    public string CategoryName { get; set; } = null!;

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("picture", TypeName = "blob")]
    public byte[]? Picture { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
