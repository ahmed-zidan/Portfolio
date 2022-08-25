namespace Core.Models
{
    public class Address : EntityBase
    {
        public string Street { set; get; }
        public string City { set; get; }
        public int Number { get; set; }
    }

}
