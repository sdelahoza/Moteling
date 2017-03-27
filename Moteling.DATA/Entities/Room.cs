using System.Collections.Generic;

namespace Moteling.DATA.Entities
{
    public class Room : BaseEntity<int>
    {
        public string Name { get; set; }

        public int MotelId { get; set; }

        public virtual ICollection<RoomImage> Images { get; set; }
    }
}
