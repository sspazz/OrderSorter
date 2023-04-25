namespace Core.Models
{
    public class DeliveryPerson : BaseEntityModel
    {
        public string ContactName { get; set; }
        public Address DefaultAddress { get; set; }
        //public virtual List<Order> Orders { get; set; }
    }
}
