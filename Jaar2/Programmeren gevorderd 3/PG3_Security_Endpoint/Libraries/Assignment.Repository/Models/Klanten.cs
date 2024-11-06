using System;
using System.Collections.Generic;

namespace Assignment.Repository.Models;

public partial class Klanten
{
    public int KlantId { get; set; }

    public string Naam { get; set; } = null!;

    public string Adres { get; set; } = null!;

    public string Telefoon { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Bestellingen> Bestellingens { get; set; } = new List<Bestellingen>();

    public virtual ICollection<Voertuigen> Voertuigens { get; set; } = new List<Voertuigen>();
}
