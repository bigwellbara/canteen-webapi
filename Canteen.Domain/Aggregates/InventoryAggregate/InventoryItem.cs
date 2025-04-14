using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Domain.Aggregates.InventoryAggregate
{
    public class InventoryItem
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }       // E.g., "Flour", "Tomatoes"
        public decimal Quantity { get; set; }  // In stock (e.g., 5.5 kg)
        public string Unit { get; set; }       // "kg", "liters", "units"
        public DateTime LastRestocked { get; set; }
    }
}
