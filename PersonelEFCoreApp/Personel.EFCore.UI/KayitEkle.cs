using Personel.EFCore.BAL;
using Personel.EFCore.DAL;
using Personel.EFCore.Domain;

namespace Personel.EFCore.UI
{
    public partial class KayitEkle : Form
    {
        public event EventHandler NewRecordAdded;

        private readonly PersonelService _personelService;

        public KayitEkle()
        {
            InitializeComponent();
            _personelService = new PersonelService(new AppDbContext());
            LoadComboBoxGendersData();
            LoadComboBoxDepartmansData();
        }

        private void LoadComboBoxDepartmansData()
        {
            try
            {
                var data = _personelService.GetAllDepartments();
                cmbDepartman.DisplayMember = "DepartmentName";
                cmbDepartman.ValueMember = "DepartmentID";
                cmbDepartman.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Departman verileri yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void cmbDepartman_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void LoadComboBoxGendersData()
        {
            try
            {
                var data = _personelService.GetAllGenders();
                comboBox1.DisplayMember = "GenderName";
                comboBox1.ValueMember = "GenderID";
                comboBox1.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cinsiyet verileri yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnKayitEt_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(comboBox1.SelectedItem is Gender selectedGender))
                {
                    MessageBox.Show("Geçersiz cinsiyet seçimi.");
                    return;
                }

                if (!(cmbDepartman.SelectedItem is Department selectedDepartman))
                {
                    MessageBox.Show("Geçersiz departman seçimi.");
                    return;
                }

                var newWorker = new Personels
                {
                    FirstName = txtAd.Text,
                    LastName = txtSoyad.Text,
                    BirthDate = dtpDogumTarihi.Value,
                    Gender = selectedGender,
                    IdentityNumber = txtTc.Text,
                    Department = selectedDepartman
                };

                var newPersonelDetail = new PersonelDetail
                {
                    Email = txtEmail.Text,
                    Phone = txtTelefon.Text,
                    Addresses = new System.Collections.Generic.List<Address>
                    {
                        new Address
                        {
                            City = txtSehir.Text,
                            PostalCode = txtPostaKod.Text,
                            Country = txtUlke.Text,
                        }
                    }
                };

                newPersonelDetail.Personel = newWorker;
                _personelService.AddPersonel(newWorker, newPersonelDetail);

                MessageBox.Show("Kayıt başarıyla eklendi.");
                NewRecordAdded?.Invoke(this, EventArgs.Empty);

                ClearFields();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt eklenirken hata oluştu: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            txtAd.Text = "";
            txtSoyad.Text = "";
            dtpDogumTarihi.Value = DateTime.Today;
            txtTc.Text = "";
            txtEmail.Text = "";
            txtTelefon.Text = "";
            txtSehir.Text = "";
            txtPostaKod.Text = "";
            txtUlke.Text = "";

            comboBox1.SelectedItem = null;
            cmbDepartman.SelectedItem = null;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
