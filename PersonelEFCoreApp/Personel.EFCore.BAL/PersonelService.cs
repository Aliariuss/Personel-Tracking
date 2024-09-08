using Microsoft.EntityFrameworkCore;
using Personel.EFCore.DAL;
using Personel.EFCore.Domain;

namespace Personel.EFCore.BAL
{
    public class PersonelService
    {
        private readonly AppDbContext _context;

        public PersonelService(AppDbContext context)
        {
            _context = context;
        }

        public List<dynamic> GetAllPersonels()
        {
            return _context.PersonelDetails
                .Include(detail => detail.Personel)
                .ThenInclude(personel => personel.Gender)
                .Include(detail => detail.Personel)
                .ThenInclude(personel => personel.Department)
                .Include(detail => detail.Addresses)
                .Select(detail => new
                {
                    detail.Personel.PersonelID,
                    detail.Personel.FirstName,
                    detail.Personel.LastName,
                    detail.Personel.IdentityNumber,
                    detail.Personel.BirthDate,
                    Gender = detail.Personel.Gender.GenderName,
                    Department = detail.Personel.Department.DepartmentName,
                    detail.Email,
                    detail.Phone,
                    Addresses = string.Join(", ", detail.Addresses.Select(a => $"{a.City}, {a.Country}, {a.Region} {a.PostalCode}"))
                })
                .ToList<dynamic>();
        }

        public void AddPersonel(Personels personel, PersonelDetail personelDetail)
        {
            _context.Workers.Add(personel);
            _context.PersonelDetails.Add(personelDetail);
            _context.SaveChanges();
        }

        public void UpdatePersonel(Personels personel)
        {
            _context.Workers.Update(personel);
            _context.SaveChanges();
        }

        public void DeletePersonel(int personelId)
        {
            var personel = _context.Workers
                .Include(p => p.PersonelDetail)
                .ThenInclude(pd => pd.Addresses)
                .FirstOrDefault(p => p.PersonelID == personelId);

            if (personel != null)
            {
                _context.Workers.Remove(personel);
                _context.SaveChanges();
            }
        }

        public List<dynamic> SearchPersonels(string searchText)
        {
            searchText = searchText.ToLower();
            return _context.PersonelDetails
                .Include(detail => detail.Personel)
                .ThenInclude(personel => personel.Gender)
                .Include(detail => detail.Personel)
                .ThenInclude(personel => personel.Department)
                .Include(detail => detail.Addresses)
                .Where(detail => detail.Personel.FirstName.ToLower().Contains(searchText) ||
                                 detail.Personel.LastName.ToLower().Contains(searchText) ||
                                 detail.Personel.IdentityNumber.Contains(searchText) ||
                                 detail.Phone.Contains(searchText) ||
                                 detail.Email.ToLower().Contains(searchText) ||
                                 detail.Personel.Gender.GenderName.ToLower().Contains(searchText) ||
                                 detail.Personel.Department.DepartmentName.ToLower().Contains(searchText) ||
                                 detail.Addresses.Any(a => a.City.ToLower().Contains(searchText)))
                .Select(detail => new
                {
                    detail.Personel.PersonelID,
                    detail.Personel.FirstName,
                    detail.Personel.LastName,
                    detail.Personel.IdentityNumber,
                    detail.Phone,
                    detail.Email,
                    detail.Personel.BirthDate,
                    Gender = detail.Personel.Gender.GenderName,
                    Department = detail.Personel.Department.DepartmentName,
                    Address = string.Join(", ", detail.Addresses.Select(a => a.City))
                })
                .OrderBy(p => p.FirstName)
                .ToList<dynamic>();
        }

        public List<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public List<Gender> GetAllGenders()
        {
            return _context.Genders.ToList();
        }

        public Personels GetPersonelById(int personelId)
        {
            return _context.Workers
                .Include(p => p.Gender)
                .Include(p => p.Department)
                .Include(p => p.PersonelDetail)
                .ThenInclude(pd => pd.Addresses)
                .FirstOrDefault(p => p.PersonelID == personelId);
        }
    }

    public class DepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }

        public List<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public void DeleteDepartment(int departmentId)
        {
            var department = _context.Departments.Find(departmentId);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }

        public Department GetDepartmentById(int departmentId)
        {
            return _context.Departments.Find(departmentId);
        }
    }
}
