namespace Personel.EFCore.UI
{
    partial class DepartmanIslemleri
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnDepartmanKaydet;
        private System.Windows.Forms.Button btnDepartmanGuncelle;
        private System.Windows.Forms.Button btnDepartmanSil;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox txtDepartmanEkle;
        private System.Windows.Forms.Label lblDepartmanEkle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnDepartmanKaydet = new System.Windows.Forms.Button();
            this.btnDepartmanGuncelle = new System.Windows.Forms.Button();
            this.btnDepartmanSil = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.txtDepartmanEkle = new System.Windows.Forms.TextBox();
            this.lblDepartmanEkle = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // 
            // lblDepartmanEkle
            // 
            this.lblDepartmanEkle.AutoSize = true;
            this.lblDepartmanEkle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblDepartmanEkle.Location = new System.Drawing.Point(30, 20);
            this.lblDepartmanEkle.Name = "lblDepartmanEkle";
            this.lblDepartmanEkle.Size = new System.Drawing.Size(138, 19);
            this.lblDepartmanEkle.TabIndex = 0;
            this.lblDepartmanEkle.Text = "Departman Ekle:";
            // 
            // txtDepartmanEkle
            // 
            this.txtDepartmanEkle.Font = new System.Drawing.Font("Arial", 10F);
            this.txtDepartmanEkle.Location = new System.Drawing.Point(30, 50);
            this.txtDepartmanEkle.Name = "txtDepartmanEkle";
            this.txtDepartmanEkle.Size = new System.Drawing.Size(300, 27);
            this.txtDepartmanEkle.TabIndex = 1;
            // 
            // btnDepartmanKaydet
            // 
            this.btnDepartmanKaydet.BackColor = System.Drawing.Color.LightGreen;
            this.btnDepartmanKaydet.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnDepartmanKaydet.Location = new System.Drawing.Point(30, 90);
            this.btnDepartmanKaydet.Name = "btnDepartmanKaydet";
            this.btnDepartmanKaydet.Size = new System.Drawing.Size(100, 40);
            this.btnDepartmanKaydet.TabIndex = 2;
            this.btnDepartmanKaydet.Text = "Kaydet";
            this.btnDepartmanKaydet.UseVisualStyleBackColor = false;
            this.btnDepartmanKaydet.Click += new System.EventHandler(this.btnDepartmanKaydet_Click);
            // 
            // btnDepartmanGuncelle
            // 
            this.btnDepartmanGuncelle.BackColor = System.Drawing.Color.LightBlue;
            this.btnDepartmanGuncelle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnDepartmanGuncelle.Location = new System.Drawing.Point(140, 90);
            this.btnDepartmanGuncelle.Name = "btnDepartmanGuncelle";
            this.btnDepartmanGuncelle.Size = new System.Drawing.Size(100, 40);
            this.btnDepartmanGuncelle.TabIndex = 3;
            this.btnDepartmanGuncelle.Text = "Güncelle";
            this.btnDepartmanGuncelle.UseVisualStyleBackColor = false;
            this.btnDepartmanGuncelle.Click += new System.EventHandler(this.btnDepartmanGuncelle_Click);
            // 
            // btnDepartmanSil
            // 
            this.btnDepartmanSil.BackColor = System.Drawing.Color.LightCoral;
            this.btnDepartmanSil.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnDepartmanSil.Location = new System.Drawing.Point(250, 90);
            this.btnDepartmanSil.Name = "btnDepartmanSil";
            this.btnDepartmanSil.Size = new System.Drawing.Size(100, 40);
            this.btnDepartmanSil.TabIndex = 4;
            this.btnDepartmanSil.Text = "Sil";
            this.btnDepartmanSil.UseVisualStyleBackColor = false;
            this.btnDepartmanSil.Click += new System.EventHandler(this.btnDepartmanSil_Click);
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Arial", 10F);
            this.listView1.Location = new System.Drawing.Point(30, 150);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(320, 200);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Columns.Add("ID", -2, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Departman Adı", -2, HorizontalAlignment.Left);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);

            // 
            // DepartmanIslemleri
            // 
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.lblDepartmanEkle);
            this.Controls.Add(this.txtDepartmanEkle);
            this.Controls.Add(this.btnDepartmanKaydet);
            this.Controls.Add(this.btnDepartmanGuncelle);
            this.Controls.Add(this.btnDepartmanSil);
            this.Controls.Add(this.listView1);
            this.Name = "DepartmanIslemleri";
            this.Text = "Departman İşlemleri";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}
