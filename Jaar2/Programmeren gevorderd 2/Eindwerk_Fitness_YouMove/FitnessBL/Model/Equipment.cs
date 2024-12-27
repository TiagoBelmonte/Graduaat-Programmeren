using FitnessBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBL.Model
{
    public class Equipment
    {
        
        // Dit Id wordt waarschijnlijk door de database gegenereerd en is read-only
        public int? equipment_id { get; }

        // Private veld voor de beschrijving
        private string device_type;

        // Constructor
        public Equipment(string device_type)
        {
            Device_type = device_type; // De Beschrijving wordt gevalideerd door de setter
        }
        public Equipment(int? id, string device_type)
        {
            equipment_id = id;
            Device_type = device_type; // De Beschrijving wordt gevalideerd door de setter
        }

        // Eigenschap voor de Beschrijving
        public string Device_type
        {
            get { return device_type; }
            set
            {
                // Valideer of de Beschrijving niet leeg of null is
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new DomeinExceptions("device_type mag niet leeg zijn.");
                }
                device_type = value; // Toewijzing aan het private veld
            }
        }
    }
}
