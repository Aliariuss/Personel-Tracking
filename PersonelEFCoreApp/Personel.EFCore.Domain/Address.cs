namespace Personel.EFCore.Domain
{
    public class Address
    {
        public int AddressID { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
        public int PersonelDetailID { get; set; }
        public PersonelDetail PersonelDetail { get; set; }
    }
}
