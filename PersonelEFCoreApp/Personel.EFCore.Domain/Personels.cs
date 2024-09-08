namespace Personel.EFCore.Domain
{
    public class Personels
    {
        public int PersonelID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
        public int DepartmentID { get; set; }
        public int GenderID { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public Department Department { get; set; }
        public Gender Gender { get; set; }
        public PersonelDetail PersonelDetail { get; set; }
    }
}