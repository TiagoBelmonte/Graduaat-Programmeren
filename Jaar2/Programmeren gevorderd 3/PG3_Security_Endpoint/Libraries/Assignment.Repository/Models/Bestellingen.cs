using System;
using System.Collections.Generic;

namespace Assignment.Repository.Models;

public partial class Bestellingen
{
    public int BestellingId { get; set; }

    public int KlantId { get; set; }

    public int VoertuigId { get; set; }

    public DateOnly BestelDatum { get; set; }

    public decimal TotaalBedrag { get; set; }

    public virtual ICollection<Bestellingsregel> Bestellingsregels { get; set; } = new List<Bestellingsregel>();

    public virtual Klanten Klant { get; set; } = null!;

    public virtual Voertuigen Voertuig { get; set; } = null!;
}
