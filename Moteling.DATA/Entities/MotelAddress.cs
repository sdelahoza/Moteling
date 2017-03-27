namespace Moteling.DATA.Entities
{
    public class MotelAddress : BaseEntity<int>
    {
        public string Address { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public virtual Motel Motel { get; set; }
    }
}
