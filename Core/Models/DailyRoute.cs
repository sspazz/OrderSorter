using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class DailyRoute : BaseEntityModel
    {
        public DeliveryPerson DeliveryPerson { get; set; }

        public List<Address> Addresses { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}
