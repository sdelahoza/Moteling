namespace Moteling.DATA.Entities
{
    public class RoomImage : BaseEntity<long>
    {
        public string ImageUrl { get; set; }

        public int RoomId { get; set; }
    }
}
