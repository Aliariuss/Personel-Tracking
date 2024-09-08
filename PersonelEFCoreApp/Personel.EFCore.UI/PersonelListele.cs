using Personel.EFCore.BAL;
using Personel.EFCore.DAL;

namespace Personel.EFCore.UI
{
    public partial class PersonelListele : Form
    {
        private PersonelService _personelService;

        public PersonelListele()
        {
            InitializeComponent();
            _personelService = new PersonelService(new AppDbContext());
            this.Load += PersonelListele_Load;
            dgwPersonelList.CellDoubleClick += dgwPersonelList_CellDoubleClick;
        }

        private void PersonelListele_Load(object sender, EventArgs e)
        {
            RefreshDgw();
        }

        private void btnKayitEkle_Click(object sender, EventArgs e)
        {
            using (var kayitEkleForm = new KayitEkle())
            {
                kayitEkleForm.NewRecordAdded += KayitEkleForm_RecordAdded;
                kayitEkleForm.ShowDialog();
            }
        }

        private void KayitEkleForm_RecordAdded(object sender, EventArgs e)
        {
            RefreshDgw();
        }

        private void RefreshDgw()
        {
            try
            {
                var combinedData = _personelService.GetAllPersonels();
                dgwPersonelList.DataSource = combinedData ?? throw new Exception("Veri bulunamadý.");

                dgwPersonelList.Columns["PersonelID"].HeaderText = "Personel No";
                dgwPersonelList.Columns["FirstName"].HeaderText = "Ad";
                dgwPersonelList.Columns["LastName"].HeaderText = "Soyad";
                dgwPersonelList.Columns["IdentityNumber"].HeaderText = "Kimlik Numarasý";
                dgwPersonelList.Columns["BirthDate"].HeaderText = "Doðum Tarihi";
                dgwPersonelList.Columns["Gender"].HeaderText = "Cinsiyet";
                dgwPersonelList.Columns["Department"].HeaderText = "Departman";
                dgwPersonelList.Columns["Email"].HeaderText = "E-posta";
                dgwPersonelList.Columns["Phone"].HeaderText = "Telefon";
                dgwPersonelList.Columns["Addresses"].HeaderText = "Adresler";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken hata oluþtu: " + ex.Message);
            }
        }


        private void btnDepartmanForm_Click(object sender, EventArgs e)
        {
            using (var departmanForm = new DepartmanIslemleri())
            {
                departmanForm.DepartmentUpdated += (s, ev) => RefreshDgw();
                departmanForm.ShowDialog();
            }
        }

        private void dgwPersonelList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var personelId = (int)dgwPersonelList.Rows[e.RowIndex].Cells["PersonelID"].Value;
                OpenUpdateForm(personelId);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgwPersonelList.SelectedRows.Count > 0)
            {
                var personelId = (int)dgwPersonelList.SelectedRows[0].Cells["PersonelID"].Value;
                OpenUpdateForm(personelId);
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediðiniz kaydý seçin.");
            }
        }

        private void OpenUpdateForm(int personelId)
        {
            using (var updateForm = new KayitGuncelle(personelId, dgwPersonelList))
            {
                updateForm.RecordUpdated += (s, ev) => RefreshDgw();
                updateForm.ShowDialog();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgwPersonelList.SelectedRows.Count > 0)
            {
                var personelId = (int)dgwPersonelList.SelectedRows[0].Cells["PersonelID"].Value;
                _personelService.DeletePersonel(personelId);
                RefreshDgw();
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediðiniz kaydý seçin.");
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SearchPersonels();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            SearchPersonels();
        }

        private void SearchPersonels()
        {
            var combinedData = _personelService.SearchPersonels(txtAra.Text.ToLower());
            dgwPersonelList.DataSource = combinedData;
        }
    }
}
