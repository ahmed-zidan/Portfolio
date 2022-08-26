namespace Core.Models
{
    public class Address : EntityBase
    {
        public string Country { set; get; }
        public string City { set; get; }
        public string Street { get; set; }
    }

}
