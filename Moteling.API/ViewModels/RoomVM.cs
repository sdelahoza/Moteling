using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moteling.API.ViewModels
{
    public class RoomVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MotelId { get; set; }

        public virtual ICollection<RoomImageVM> Images { get; set; }
    }
}
