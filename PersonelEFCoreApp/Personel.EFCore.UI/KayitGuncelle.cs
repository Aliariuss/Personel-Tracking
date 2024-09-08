using Personel.EFCore.BAL;
using Personel.EFCore.DAL;
using Personel.EFCore.Domain;


namespace Personel.EFCore.UI
{
    public partial class KayitGuncelle : Form
    {
        private readonly PersonelService _personelService;
        private readonly int _personelId;
        private readonly DataGridView _dataGridView;

        public event EventHandler RecordUpdated;

        public KayitGuncelle(int personelId, DataGridView dataGridView)
        {
            InitializeComponent();
            _personelService = new PersonelService(new AppDbContext());
            _personelId = personelId;
            _dataGridView = dataGridView;
            this.FormClosing += KayitGuncelle_FormClosing;
        }

        private void KayitGuncelle_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
            LoadPersonelBilgisi();
        }

        private void KayitGuncelle_FormClosing(object sender, FormClosingEventArgs e)
        {
            RecordUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void LoadComboBoxData()
        {
            cmbDepartmanGuncelle.DataSource = _personelService.GetAllDepartments();
            cmbDepartmanGuncelle.DisplayMember = "DepartmentName";
            cmbDepartmanGuncelle.ValueMember = "DepartmentID";

            comboBox1Guncelle.DataSource = _personelService.GetAllGenders();
            comboBox1Guncelle.DisplayMember = "GenderName";
            comboBox1Guncelle.ValueMember = "GenderID";
        }

        private void LoadPersonelBilgisi()
        {
            var personel = _personelService.GetPersonelById(_personelId);

            if (personel == null)
            {
                MessageBox.Show("Personel kaydı bulunamadı.");
                Close();
                return;
            }

            txtAdGuncelle.Text = personel.FirstName;
            txtSoyadGuncelle.Text = personel.LastName;
            dtpDogumTarihiGuncelle.Value = personel.BirthDate;
            txtTcGuncelle.Text = personel.IdentityNumber;
            comboBox1Guncelle.SelectedValue = personel.Gender.GenderID;
            cmbDepartmanGuncelle.SelectedValue = personel.Department.DepartmentID;

            var detay = personel.PersonelDetail;
            if (detay != null)
            {
                txtEmailGuncelle.Text = detay.Email;
                txtTelefonGuncelle.Text = detay.Phone;

                var adres = detay.Addresses.FirstOrDefault();
                if (adres != null)
                {
                    txtSehirGuncelle.Text = adres.City;
                    txtPostaKodGuncelle.Text = adres.PostalCode;
                    txtUlkeGuncelle.Text = adres.Country;
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var personel = _personelService.GetPersonelById(_personelId);
            if (personel == null)
            {
                MessageBox.Show("Kayıt bulunamadı.");
                return;
            }

            bool isModified = UpdatePersonelData(personel);

            if (isModified)
            {
                try
                {
                    _personelService.UpdatePersonel(personel);
                    MessageBox.Show("Kayıt başarıyla güncellendi.");
                    RecordUpdated?.Invoke(this, EventArgs.Empty);
                    UpdateDataGridView(personel);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Güncelleme işlemi sırasında hata oluştu: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Güncellenecek bir değişiklik bulunamadı.");
            }
        }

        private bool UpdatePersonelData(Personels personel)
        {
            bool isModified = false;

            if (personel.FirstName != txtAdGuncelle.Text)
            {
                personel.FirstName = txtAdGuncelle.Text;
                isModified = true;
            }
            if (personel.LastName != txtSoyadGuncelle.Text)
            {
                personel.LastName = txtSoyadGuncelle.Text;
                isModified = true;
            }
            if (personel.BirthDate != dtpDogumTarihiGuncelle.Value)
            {
                personel.BirthDate = dtpDogumTarihiGuncelle.Value;
                isModified = true;
            }
            if (personel.IdentityNumber != txtTcGuncelle.Text)
            {
                personel.IdentityNumber = txtTcGuncelle.Text;
                isModified = true;
            }
            if (personel.GenderID != (int)comboBox1Guncelle.SelectedValue)
            {
                personel.GenderID = (int)comboBox1Guncelle.SelectedValue;
                isModified = true;
            }
            if (personel.DepartmentID != (int)cmbDepartmanGuncelle.SelectedValue)
            {
                personel.DepartmentID = (int)cmbDepartmanGuncelle.SelectedValue;
                isModified = true;
            }

            var detay = personel.PersonelDetail;
            if (detay != null)
            {
                if (detay.Email != txtEmailGuncelle.Text)
                {
                    detay.Email = txtEmailGuncelle.Text;
                    isModified = true;
                }
                if (detay.Phone != txtTelefonGuncelle.Text)
                {
                    detay.Phone = txtTelefonGuncelle.Text;
                    isModified = true;
                }

                var adres = detay.Addresses.FirstOrDefault();
                if (adres != null)
                {
                    if (adres.City != txtSehirGuncelle.Text)
                    {
                        adres.City = txtSehirGuncelle.Text;
                        isModified = true;
                    }
                    if (adres.PostalCode != txtPostaKodGuncelle.Text)
                    {
                        adres.PostalCode = txtPostaKodGuncelle.Text;
                        isModified = true;
                    }
                    if (adres.Country != txtUlkeGuncelle.Text)
                    {
                        adres.Country = txtUlkeGuncelle.Text;
                        isModified = true;
                    }
                }
            }

            return isModified;
        }

        private void UpdateDataGridView(Personels personel)
        {
            if (_dataGridView != null)
            {
                var row = _dataGridView.Rows.Cast<DataGridViewRow>()
                    .FirstOrDefault(r => (int)r.Cells["PersonelID"].Value == personel.PersonelID);

                if (row != null)
                {
                    
                    row.Cells["BirthDate"].Value = personel.BirthDate;
                    row.Cells["IdentityNumber"].Value = personel.IdentityNumber;
                    row.Cells["FirstName"].Value = personel.FirstName;
                    row.Cells["LastName"].Value = personel.LastName;
                    row.Cells["Department"].Value = personel.Department.DepartmentName;
                    row.Cells["Gender"].Value = personel.Gender.GenderName;
                }
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
