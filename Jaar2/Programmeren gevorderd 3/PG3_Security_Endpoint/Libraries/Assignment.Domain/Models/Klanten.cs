namespace Assignment.Domain.Models;

public partial class Klant: EntityBase
{
    public int KlantId { get; set; }

    public string Naam { get; set; } = null!;

    public string Adres { get; set; } = null!;

    public string Telefoon { get; set; } = null!;

    public string Email { get; set; } = null!;

    //public virtual ICollection<Bestellingen> Bestellingen { get; set; } = new List<Bestellingen>();

    //public virtual ICollection<Voertuigen> Voertuigen { get; set; } = new List<Voertuigen>();
}
