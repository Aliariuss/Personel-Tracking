Personnel Management System

This project is a software solution developed for Personnel Management System. It supports core operations such as recording, updating, deleting, and listing personnel information. Additionally, it manages related data such as department and gender information. The project is built using Entity Framework Core and follows a layered architecture.

# Project Structure

1. Domain Layer:

Personels: Contains personnel information (First Name, Last Name, Identity Number, Birth Date, etc.)

Department: Contains department information (Department Name, etc.)

Gender: Contains gender information (Gender Name, Status, etc.)

PersonelDetail: Contains additional personnel details (Email, Phone, etc.)

Address: Contains personnel address information (City, Country, Postal Code, etc.)

3. DAL (Data Access Layer):
Manages data access operations using Entity Framework Core.
Mapping classes configure the structure of database tables.

4. BAL (Business Access Layer):
PersonelService: Manages operations related to personnel (Add, Delete, Update).
DepartmentService: Manages department operations.

5. UI Layer:
The Windows Forms interface allows users to manage personnel and department information.

Technologies Used

.NET Framework

Entity Framework Core

Windows Forms

Microsoft SQL Server

Setup and Usage

1. Database Connection String
The database connection string is configured in the AppDbContext class within the OnConfiguring method. You can update this string with your own SQL Server settings as shown below:

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlServer("Data Source=MSI;Initial Catalog=PersonelDB;User ID=TestUser;Password=admin123;TrustServerCertificate=true");
}

Modify this string to suit your SQL Server configuration.

2. Database Migration
Before running the project for the first time, you will need to create the database tables by performing a migration.

Steps:

Open the Package Manager Console (from Visual Studio menu: Tools > NuGet Package Manager > Package Manager Console).

Create an initial migration by entering the following command:

Add-Migration InitialCreate

Apply the migration to the database with the following command:

Update-Database

This process will create the necessary tables and add the initial seed data (departments, genders, and personnel) to the database.

3. Windows Forms UI
Personnel addition, update, deletion, and search operations can be performed through the Windows Forms interface. Additionally, department and gender information can also be managed through the interface.

Features

Add, Delete, Update Personnel

Department Management

Gender Management

Address Management

Personnel Detail Viewing and Searching

Database Integration

************************************************************************************************************************

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
