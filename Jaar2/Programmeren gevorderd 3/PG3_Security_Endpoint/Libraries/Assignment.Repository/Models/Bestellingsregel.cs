using System;
using System.Collections.Generic;

namespace Assignment.Repository.Models;

public partial class Bestellingsregel
{
    public int BestellingsregelId { get; set; }

    public int BestellingId { get; set; }

    public int DienstId { get; set; }

    public int Aantal { get; set; }

    public decimal PrijsPerStuk { get; set; }

    public decimal TotaalPrijs { get; set; }

    public virtual Bestellingen Bestelling { get; set; } = null!;

    public virtual Diensten Dienst { get; set; } = null!;
}
