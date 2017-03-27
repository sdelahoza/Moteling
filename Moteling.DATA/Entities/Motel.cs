using System.Collections.Generic;

namespace Moteling.DATA.Entities
{
    public class Motel : BaseEntity<int>
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Page { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

        public virtual MotelAddress Address { get; set; }
    }
}
