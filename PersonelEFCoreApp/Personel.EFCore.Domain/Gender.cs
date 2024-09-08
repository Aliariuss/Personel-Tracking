namespace Personel.EFCore.Domain
{

    public class Gender
    {
        public int GenderID { get; set; }
        public string GenderName { get; set; }
        public bool State { get; set; }
        public ICollection<Personels> Personels { get; set; }
    }




}
