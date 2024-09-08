namespace Personel.EFCore.Domain
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Personels> Personels { get; set; }
    }
}
