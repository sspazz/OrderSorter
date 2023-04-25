namespace Core.Models
{
    public class Order : BaseEntityModel
    {
        public string ContactName { get; set; }
        public Address Address { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
