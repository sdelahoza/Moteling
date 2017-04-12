using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moteling.API.ViewModels
{
    public class MotelVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Page { get; set; }

        public string Description { get; set; }

        public virtual ICollection<RoomVM> Rooms { get; set; }

        public virtual MotelAddressVM Address { get; set; }
    }
}
