namespace Personel.EFCore.UI
{
    partial class PersonelListele
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgwPersonelList = new DataGridView();
            btnKayitEkle = new Button();
            btnGuncelle = new Button();
            btnSil = new Button();
            txtAra = new TextBox();
            btnAra = new Button();
            mthCalendar = new MonthCalendar();
            btnDepartmanForm = new Button();
            ((System.ComponentModel.ISupportInitialize)dgwPersonelList).BeginInit();
            SuspendLayout();
            // 
            // dgwPersonelList
            // 
            dgwPersonelList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwPersonelList.Location = new Point(12, 177);
            dgwPersonelList.Name = "dgwPersonelList";
            dgwPersonelList.Size = new Size(1245, 331);
            dgwPersonelList.TabIndex = 0;
            dgwPersonelList.CellContentDoubleClick += dgwPersonelList_CellDoubleClick;
            // 
            // btnKayitEkle
            // 
            btnKayitEkle.BackColor = Color.LightGreen;
            btnKayitEkle.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnKayitEkle.Location = new Point(1032, 514);
            btnKayitEkle.Name = "btnKayitEkle";
            btnKayitEkle.Size = new Size(100, 40);
            btnKayitEkle.TabIndex = 3;
            btnKayitEkle.Text = "Kayıt Ekle";
            btnKayitEkle.UseVisualStyleBackColor = false;
            btnKayitEkle.Click += btnKayitEkle_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.BackColor = Color.LightBlue;
            btnGuncelle.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnGuncelle.Location = new Point(926, 514);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(100, 40);
            btnGuncelle.TabIndex = 4;
            btnGuncelle.Text = "Kayıt Güncelle";
            btnGuncelle.UseVisualStyleBackColor = false;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.LightCoral;
            btnSil.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnSil.Location = new Point(810, 514);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(100, 40);
            btnSil.TabIndex = 5;
            btnSil.Text = "Kayıt Sil";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // txtAra
            // 
            txtAra.Font = new Font("Arial", 10F);
            txtAra.Location = new Point(810, 123);
            txtAra.Multiline = true;
            txtAra.Name = "txtAra";
            txtAra.Size = new Size(216, 31);
            txtAra.TabIndex = 1;
            txtAra.TextChanged += txtAra_TextChanged;
            // 
            // btnAra
            // 
            btnAra.BackColor = Color.LightYellow;
            btnAra.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnAra.Location = new Point(1032, 123);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(100, 31);
            btnAra.TabIndex = 2;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = false;
            btnAra.Click += btnAra_Click;
            // 
            // mthCalendar
            // 
            mthCalendar.Location = new Point(18, 3);
            mthCalendar.Name = "mthCalendar";
            mthCalendar.TabIndex = 6;
            mthCalendar.TrailingForeColor = SystemColors.ControlLight;
            // 
            // btnDepartmanForm
            // 
            btnDepartmanForm.BackColor = Color.LightGoldenrodYellow;
            btnDepartmanForm.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnDepartmanForm.Location = new Point(12, 514);
            btnDepartmanForm.Name = "btnDepartmanForm";
            btnDepartmanForm.Size = new Size(150, 40);
            btnDepartmanForm.TabIndex = 7;
            btnDepartmanForm.Text = "Departman İşlemleri";
            btnDepartmanForm.UseVisualStyleBackColor = false;
            btnDepartmanForm.Click += btnDepartmanForm_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1278, 579);
            Controls.Add(btnDepartmanForm);
            Controls.Add(mthCalendar);
            Controls.Add(btnAra);
            Controls.Add(txtAra);
            Controls.Add(btnSil);
            Controls.Add(btnGuncelle);
            Controls.Add(btnKayitEkle);
            Controls.Add(dgwPersonelList);
            Name = "Form1";
            Text = "Personel Listesi";
            Load += PersonelListele_Load;
            ((System.ComponentModel.ISupportInitialize)dgwPersonelList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgwPersonelList;
        private System.Windows.Forms.Button btnKayitEkle;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.MonthCalendar mthCalendar;
        private System.Windows.Forms.Button btnDepartmanForm;
    }
}
