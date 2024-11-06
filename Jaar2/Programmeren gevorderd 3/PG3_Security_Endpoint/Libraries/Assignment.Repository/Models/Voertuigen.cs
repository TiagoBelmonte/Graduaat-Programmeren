using System;
using System.Collections.Generic;

namespace Assignment.Repository.Models;

public partial class Voertuigen
{
    public int VoertuigId { get; set; }

    public int KlantId { get; set; }

    public string Kenteken { get; set; } = null!;

    public string Merk { get; set; } = null!;

    public string Model { get; set; } = null!;

    public virtual ICollection<Bestellingen> Bestellingens { get; set; } = new List<Bestellingen>();

    public virtual Klanten Klant { get; set; } = null!;
}
