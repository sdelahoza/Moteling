using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moteling.API.ViewModels
{
    public class RoomImageVM
    {
        public long Id { get; set; }

        public string ImageUrl { get; set; }

        public int RoomId { get; set; }
    }
}
