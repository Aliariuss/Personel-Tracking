Personel Yönetim Sistemi
Bu proje, Personel Yönetim Sistemi için geliştirilen bir yazılım çözümüdür. Proje, personel bilgilerini kaydetme, güncelleme, silme ve listeleme gibi temel işlemleri destekler. Ayrıca departman ve cinsiyet bilgileri gibi ilgili verileri de yönetir. Proje, Entity Framework Core kullanılarak geliştirilmiştir ve katmanlı mimari yapısına sahiptir.

# Proje Yapısı

1. Domain Katmanı:

Personels: Personel bilgilerini içerir (Ad, Soyad, Kimlik Numarası, Doğum Tarihi, vb.)

Department: Departman bilgilerini içerir (Departman adı, vb.)

Gender: Cinsiyet bilgilerini içerir (Cinsiyet adı, Durum bilgisi, vb.)

PersonelDetail: Personel ile ilgili ek detay bilgileri içerir (E-posta, Telefon, vb.)

Address: Personelin adres bilgilerini içerir (Şehir, Ülke, Posta Kodu, vb.)

2. DAL (Data Access Layer) Katmanı:
Entity Framework Core kullanılarak veri erişim işlemleri yönetilir.
Mapping sınıflarıyla veritabanı tablolarının yapılandırılması gerçekleştirilir.

4. BAL (Business Access Layer) Katmanı:
PersonelService: Personel ile ilgili işlemler (Ekleme, Silme, Güncelleme) burada gerçekleştirilir.
DepartmentService: Departman işlemlerini yönetir.

5. UI Katmanı:
Windows Forms arayüzü ile kullanıcılar, personel ve departman bilgilerini yönetebilirler.

Kullanılan Teknolojiler
.NET Framework
Entity Framework Core
Windows Forms
Microsoft SQL Server
Kurulum ve Kullanım

1. Veritabanı Bağlantı Dizisi (Connection String)
2.Projedeki veritabanı bağlantı dizesi, AppDbContext sınıfı içerisinde OnConfiguring metodunda yapılandırılmıştır. Aşağıdaki kodda gösterildiği gibi, kendi SQL Server bağlantı bilgilerinizi kullanarak bu dizeyi güncelleyebilirsiniz:

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlServer("Data Source=MSI;Initial Catalog=PersonelDB;User ID=TestUser;Password=admin123;TrustServerCertificate=true");
}

Bu kodu, SQL Server ayarlarınıza uygun şekilde güncelleyin.

2. Veritabanı Migrasyonu (Migration)
3. İlk kez çalıştırmadan önce veritabanı tablolarını oluşturmak için migrasyon işlemini gerçekleştirmeniz gerekecek.

Adımlar:

Paket Yöneticisi Konsolunu açın (Visual Studio menüsünden Tools > NuGet Package Manager > Package Manager Console).
Aşağıdaki komutu girerek bir başlangıç migrasyonu oluşturun:

Add-Migration InitialCreate

Veritabanına Migrasyonu Uygulamak İçin şu komutu çalıştırın:

Update-Database

Bu işlem, gerekli tabloları oluşturacak ve tanımlanan başlangıç verilerini (departmanlar, cinsiyetler ve personel) veritabanına ekleyecektir.

3. Windows Forms Kullanıcı Arayüzü
Personel ekleme, güncelleme, silme ve arama işlemleri, Windows Forms arayüzü üzerinden yapılabilir. Arayüzde aynı zamanda departman ve cinsiyet bilgileri yönetilebilir.

Özellikler

Personel Ekleme, Silme, Güncelleme
Departman Yönetimi
Cinsiyet Yönetimi
Adres Bilgileri Yönetimi
Personel Detay Görüntüleme ve Arama
Veritabanı ile entegrasyon
