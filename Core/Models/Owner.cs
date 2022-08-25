namespace Core.Models
{
    public class Owner : EntityBase
    {
        public string FullName { get; set; }
        public string Profile { get; set; }
        public string Avatar { set; get; }

        public Address Address { get; set; }

    }

}
