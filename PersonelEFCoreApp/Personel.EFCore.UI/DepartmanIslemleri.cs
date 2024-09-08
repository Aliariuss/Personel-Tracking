using Personel.EFCore.BAL;
using Personel.EFCore.DAL;
using Personel.EFCore.Domain;

namespace Personel.EFCore.UI
{
    public partial class DepartmanIslemleri : Form
    {
        public event EventHandler DepartmentUpdated;
        private readonly DepartmentService _departmentService;

        public DepartmanIslemleri()
        {
            InitializeComponent();
            _departmentService = new DepartmentService(new AppDbContext());
            InitializeEventHandlers();
        }

        private void InitializeEventHandlers()
        {
            this.Load += DepartmanIslemleri_Load;
            btnDepartmanKaydet.Click += btnDepartmanKaydet_Click;
            btnDepartmanGuncelle.Click += btnDepartmanGuncelle_Click;
            btnDepartmanSil.Click += btnDepartmanSil_Click;
            listView1.DoubleClick += listView1_DoubleClick;
        }

        private void DepartmanIslemleri_Load(object sender, EventArgs e)
        {
            ShowDatabaseConnectionStatus();
            LoadDepartments();
        }

        private void ShowDatabaseConnectionStatus()
        {
            var departmentExists = _departmentService.GetAllDepartments().Any();
            MessageBox.Show(departmentExists ? "Veritabanı bağlantısı başarılı" : "Veritabanında kayıt bulunamadı.");
        }

        private void LoadDepartments()
        {
            var departments = _departmentService.GetAllDepartments();
            listView1.Items.Clear();

            foreach (var department in departments)
            {
                var item = new ListViewItem(department.DepartmentID.ToString());
                item.SubItems.Add(department.DepartmentName);
                listView1.Items.Add(item);
            }
        }

        private void btnDepartmanKaydet_Click(object sender, EventArgs e)
        {
            var newDepartment = new Department
            {
                DepartmentName = txtDepartmanEkle.Text
            };

            _departmentService.AddDepartment(newDepartment);
            RefreshDepartments();
        }

        private void btnDepartmanGuncelle_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int departmentId = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                var department = _departmentService.GetDepartmentById(departmentId);

                if (department != null)
                {
                    department.DepartmentName = txtDepartmanEkle.Text;
                    _departmentService.UpdateDepartment(department);
                    MessageBox.Show("Departman başarıyla güncellendi.");
                    DepartmentUpdated?.Invoke(this, EventArgs.Empty);
                    RefreshDepartments();
                }
            }
        }

        private void btnDepartmanSil_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int departmentId = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                _departmentService.DeleteDepartment(departmentId);
                MessageBox.Show("Departman başarıyla silindi.");
                RefreshDepartments();
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                txtDepartmanEkle.Text = selectedItem.SubItems[1].Text;
            }
        }

        private void RefreshDepartments()
        {
            LoadDepartments();
            txtDepartmanEkle.Clear();
        }
    }
}
