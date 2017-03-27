namespace Moteling.DATA.Entities
{
    public class BaseEntity<K> where K : struct
    {
        public K Id { get; set; }
    }
}
