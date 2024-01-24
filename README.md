HesaplamaSayfasi Projesi
Bu proje, öğrencilerin vize ve final notları ile ortalama hesaplamalarını sağlayan bir not hesaplama uygulamasını içerir. Aynı zamanda kullanıcı girişi ve kayıt işlemleri de sunar. Projede ASP.NET Core kullanılmıştır ve veri depolama için Microsoft Access veritabanı kullanılmıştır.

Kurulum
Proje başarıyla çalıştırılmak için aşağıdaki adımları takip edebilirsiniz:

Bu depoyu bilgisayarınıza klonlayın veya ZIP olarak indirin.
Visual Studio veya tercih ettiğiniz bir IDE kullanarak projeyi açın.
Proje içinde bulunan veriler.accdb adlı Access veritabanının yolunu kontrol edin ve gerektiğinde güncelleyin.
Projeyi başlatın.
Kullanılan Teknolojiler
ASP.NET Core: Proje, ASP.NET Core kullanılarak geliştirilmiştir.
Razor Pages: Sayfalar arası geçiş ve sunum için Razor Pages kullanılmıştır.
Microsoft Access (OLE DB): Kullanıcı verilerini depolamak için Microsoft Access veritabanı kullanılmıştır.

Proje Yapısı
Proje içinde aşağıdaki temel dosyalar ve klasörler bulunmaktadır:

_Layout.cshtml: Genel sayfa düzeni ve stil tanımları.
Index.cshtml: Kullanıcı girişi sayfası.
Register.cshtml: Yeni kullanıcı kaydı sayfası.
Hesap.cshtml: Not hesaplama sayfası.
_ViewImports.cshtml: Razor sayfalarındaki ortak kullanılan using direktifleri.
Pages/...: Razor Page modelleri ve sayfaları.


Proje şu temel adımları içerir:

Kullanıcı Girişi: Index sayfasından kullanıcı adı ve şifre ile giriş yapın.
Kayıt Olma: Register sayfasından yeni bir kullanıcı hesabı oluşturun.
Not Hesaplama: Giriş yaptıktan sonra Hesap sayfasından vize ve final notlarınızı girip ortalamanızı hesaplayın.
Veri Yapısı
veriler.accdb: Kullanıcı verilerini depolayan Access veritabanı.

Katılıma Açıklık
Eğer bir hata bulursanız veya katkıda bulunmak istiyorsanız, lütfen bir "issue" açın veya bir "pull request" gönderin. Her türlü katılımınızı bekliyoruz.
