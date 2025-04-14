using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Domain.Aggregates.OrderAggregate
{
    public class Feedback
    {
        public Guid FeedbackId { get; set; }
        public Guid UserId { get; set; }
        public Guid MenuItemId { get; set; } // Optional
        public int Rating { get; set; }      // 1-5 stars
        public string Comment { get; set; }
    }
}
