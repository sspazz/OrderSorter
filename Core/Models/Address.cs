namespace Core.Models
{
    public class Address : BaseEntityModel
    {
        public string AddressName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
