using System;
using System.Collections.Generic;

namespace Assignment.Repository.Models;

public partial class Diensten
{
    public int DienstId { get; set; }

    public string Naam { get; set; } = null!;

    public string? Beschrijving { get; set; }

    public decimal Prijs { get; set; }

    public virtual ICollection<Bestellingsregel> Bestellingsregels { get; set; } = new List<Bestellingsregel>();
}
