Merhabalar;

Proje ASP.NET 5(vNext) ile oluşturuldu.
Database için ORM Entity Framework kullanıldı ve 
Code First yaklaşımı ile codlama yapıldı.
Front-end kısmı ise halihazırda Microsoft tarafından sağlanan
bootstrap ve jquery ile yazılmıştır.

Code First yaklaşımında projeyi kendi bilgisayarınızda çalıştırmanız 
için bazı ayarları yapmanız gerekiyor.

*Connection bilgisi ve table classları Models klasörü altında yer alıyor
Models->Context->MechSoftContext.cs
Buradaki connection stringin çalıştırılacak bilgisayardaki 
sql server ayarlarına göre değiştirilmesi gerekiyor.

*Ayrıca proje client tarafından gönderilen çağrıları Web API 2 ile işliyor.
Ancak buradaki sorun server local olduğu için port numarası sizin bilgisayarınızda
değişkenlik gösterebilir.
Bu noktada Controller->HomeController.cs içerisindeki statik değişken olan
"portNumber" değişkeni kullanılacak bilgisayar server portuna değiştirilmelidir.

-Bu 2 yıldızlı maddeden sonra proje sorunsuz çalışacaktır.
Proje build edildikten sonra veritabanının oluşması için;
Visual Studio->Tools->Nuget Package Manager->Package Manager Console
kısmına sırasıyla;
"add-migration" 
"update-database" 
komutları yazılmalıdır.

Sonrasında tarayıcıda görüntüleyebilirsiniz.

-Dummy içerik için HomeController'da kurucu metod kısmında kodları yorum satırı şeklinde
yazdım,dilerseniz onları da kullanabilirsiniz,daha hızlı sonuç almak için.

İyi çalışmalar dilerim.

Onur TÜRKÖLMEZ
