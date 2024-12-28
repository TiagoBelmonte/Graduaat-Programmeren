using FitnesDataEF.Model;
using System.ComponentModel.DataAnnotations;

public class EquipmentEF
{
    public EquipmentEF()
    {
    }

    public EquipmentEF(int? id, string device, bool main)
    {
        equipment_id = id;
        device_type = device;
        maintenance = main;
    }

    [Key]
    public int? equipment_id { get; set; }

    [Required]
    [MaxLength(45)]
    public string device_type { get; set; }

    public bool maintenance { get; set; }

    public ICollection<ReservationEF> reservation { get; set; }
}
