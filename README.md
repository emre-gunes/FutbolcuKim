# ⚽ Futbolcu Kim?

Futbolseverler için geliştirilen günlük futbolcu tahmin oyunu.

Oyuncuların özelliklerini karşılaştırarak günün futbolcusunu en fazla 6 tahminde bulmaya çalışırsınız.

---

## 🎮 Özellikler

- ⚽ Günlük futbolcu sistemi
- 🔎 Futbolcu arama
- 🎯 6 tahmin hakkı
- 🟢 Doğru özellik
- 🟡 Yakın değer ve yön bilgisi
- 🔴 Yanlış özellik
- 💡 3 farklı ipucu
- ⏱️ Günlük geri sayım
- 🏆 Kazanma ekranı
- 😢 Kaybetme ekranı
- 📊 Tahmin geçmişi
- 📋 Sonucu kopyalama
- 🚫 Aynı futbolcuyu tekrar tahmin etme engeli
- 👤 Kullanıcı kayıt ve giriş sistemi
- 🔐 JWT Authentication
- 🚪 Kullanıcı çıkış sistemi
- 👥 Kullanıcıya özel oyun kayıtları

---

## 🛠️ Kullanılan Teknolojiler

### Backend

- C#
- ASP.NET Core 8 Web API
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- JWT Authentication
- Swagger

### Frontend

- HTML5
- CSS3
- JavaScript

### Development

- Git
- GitHub
- Visual Studio

---

## 🏗️ Proje Mimarisi

Proje frontend ve backend olmak üzere iki ana bölümden oluşmaktadır.

### Backend

ASP.NET Core Web API kullanılarak RESTful API yapısı oluşturulmuştur.

Backend tarafında:

- Kullanıcı işlemleri
- JWT authentication
- Futbolcu işlemleri
- Günlük futbolcu belirleme
- Tahmin işlemleri
- İpucu sistemi
- Kullanıcı oyun kayıtları

yönetilmektedir.

### Frontend

HTML, CSS ve JavaScript kullanılarak geliştirilen frontend uygulaması backend API ile iletişim kurmaktadır.

---

## 🔐 Kullanıcı ve Authentication Sistemi

Kullanıcılar sisteme kayıt olabilir ve hesaplarına giriş yapabilir.

Authentication işlemleri ASP.NET Core Identity ve JWT kullanılarak gerçekleştirilmiştir.

Başarılı giriş sonrasında kullanıcıya JWT token oluşturulur ve korumalı API endpointlerine yapılan isteklerde Bearer Token kullanılır.

Kullanıcı ayrıca sistemden çıkış yapabilir.

---

## ⚽ Oyun Sistemi

Her gün farklı bir futbolcu belirlenmektedir.

Oyuncuyu bulmak için kullanıcıya en fazla **6 tahmin hakkı** verilmektedir.

Her tahminde aşağıdaki özellikler karşılaştırılır:

- 🌍 Ülke
- ⚽ Mevki
- 🎂 Yaş
- 📏 Boy
- 🦶 Tercih edilen ayak
- 🏟️ Güncel kulüp

### Tahmin Sonuçları

| İşaret | Anlam |
|---|---|
| 🟢 | Özellik doğru |
| 🟡 | Değer yakın / yön bilgisi |
| 🔴 | Özellik yanlış |

Yaş ve boy gibi sayısal değerlerde kullanıcının doğru değere hangi yönde yaklaşması gerektiği gösterilmektedir.

---

## 💡 İpucu Sistemi

Oyuncuyu bulmayı kolaylaştırmak için toplam **3 ipucu** bulunmaktadır.

İpuçları:

1. 🌍 Oyuncunun ülkesi
2. 🏟️ Oyuncunun kulübü
3. 📏 Oyuncunun boyu

Her ipucu yalnızca bir kez kullanılabilir.

---

## 🗄️ Veritabanı

Entity Framework Core **Code First** yaklaşımı kullanılmaktadır.

Temel tablolar:

- `Players`
- `DailyGames`
- `AspNetUsers`
- `UserGames`
- `UserGuesses`

Kullanıcıların oyun ve tahmin geçmişleri kullanıcı hesabıyla ilişkilendirilmektedir.

---

## ⏱️ Günlük Futbolcu Sistemi

Oyundaki futbolcu her gün otomatik olarak değişmektedir.

Günlük futbolcu tarih bazlı bir sistem ile belirlenmekte ve yeni gün başladığında farklı bir futbolcu oyuna dahil edilmektedir.

Ayrıca kullanıcıya bir sonraki futbolcunun gelmesine kalan süreyi gösteren geri sayım bulunmaktadır.

---

## 🖥️ Oyun Akışı

1. Kullanıcı kayıt olur veya giriş yapar.
2. Günün futbolcusu belirlenir.
3. Kullanıcı futbolcu arayarak tahmin yapar.
4. Tahmin edilen oyuncunun özellikleri günün futbolcusu ile karşılaştırılır.
5. Kullanıcı doğru oyuncuyu bulana kadar tahminlerine devam eder.
6. En fazla 6 tahmin hakkı bulunmaktadır.
7. Kullanıcı doğru tahmin yaparsa kazanma ekranı gösterilir.
8. 6 tahmin sonunda doğru oyuncu bulunamazsa kaybetme ekranı gösterilir.
9. Sonuç ekranında tahmin geçmişi ve günün futbolcusu gösterilir.

---

## 🚀 Kurulum

### 1. Projeyi klonlayın

```bash
git clone https://github.com/KULLANICI_ADI/FutbolcuKim.git
