namespace Personel.EFCore.Domain
{
    public class PersonelDetail
    {
        public int PersonelDetailID { get; set; }
        public int PersonelID { get; set; }
        public Personels Personel { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}


