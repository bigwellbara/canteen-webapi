using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Domain.Aggregates.OrderAggregate
{
    public class DailySpecial
    {
        public Guid SpecialId { get; set; }
        public Guid MenuItemId { get; set; }
        public DayOfWeek Day { get; set; }   // Monday-Friday
        public bool IsActive { get; set; }
    }
}
