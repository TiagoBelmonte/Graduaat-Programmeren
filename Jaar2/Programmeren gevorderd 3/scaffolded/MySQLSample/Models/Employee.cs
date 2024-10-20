using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Northwind;

[Table("Employee")]
public partial class Employee
{
    [Key]
    [Column("employeeId")]
    public int EmployeeId { get; set; }

    [Column("lastname")]
    [StringLength(20)]
    public string Lastname { get; set; } = null!;

    [Column("firstname")]
    [StringLength(10)]
    public string Firstname { get; set; } = null!;

    [Column("title")]
    [StringLength(30)]
    public string? Title { get; set; }

    [Column("titleOfCourtesy")]
    [StringLength(25)]
    public string? TitleOfCourtesy { get; set; }

    [Column("birthDate", TypeName = "datetime")]
    public DateTime? BirthDate { get; set; }

    [Column("hireDate", TypeName = "datetime")]
    public DateTime? HireDate { get; set; }

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

    [Column("extension")]
    [StringLength(4)]
    public string? Extension { get; set; }

    [Column("mobile")]
    [StringLength(24)]
    public string? Mobile { get; set; }

    [Column("email")]
    [StringLength(225)]
    public string? Email { get; set; }

    [Column("photo", TypeName = "blob")]
    public byte[]? Photo { get; set; }

    [Column("notes", TypeName = "blob")]
    public byte[]? Notes { get; set; }

    [Column("mgrId")]
    public int? MgrId { get; set; }

    [Column("photoPath")]
    [StringLength(255)]
    public string? PhotoPath { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Employees")]
    public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
}
