# OrderSystem

# OrderSystemMicroservices

Bu proje, .NET 8 ile geliştirilmiş, mikroservis mimarisini temel alan örnek bir sistemdir. JWT Authentication, Authorization, Kafka, Angular gibi modern teknolojilerle donatılmıştır. Hem backend hem frontend açısından kurumsal bir yapıyı simüle eder.

## ✨ Kullanılan Teknolojiler

- ✅ ASP.NET Core 8 (Web API)
- ✅ Entity Framework Core 8 (Code-First)
- ✅ Angular (Admin panel - frontend)
- ✅ MSSQL Server (veritabanı)
- ✅ JWT Authentication & Authorization
- ✅ Docker & Kafka (ilerleyen aşamada)
- ✅ AutoMapper, Serilog, FluentValidation (planlı)

## 📦 Servisler

### 🔐 AuthService
- Kullanıcı giriş sistemi
- JWT Token üretimi
- Token süresi ve içerik yönetimi

### 📦 ProductService
- Ürün listeleme, ekleme
- `[Authorize]` ile koruma
- Token doğrulama

## 🧪 Test Araçları

- **Postman** ile token alımı ve korunan endpoint'lere erişim
- **Swagger UI** (varsayılan API test aracı)

## 🚀 Projeyi Çalıştırmak İçin

> Her servisi Visual Studio ile ayrı ayrı çalıştırınız:

1. `AuthService` → Login ile JWT al
2. `ProductService` → Token ile ürün işlemlerini gerçekleştir

### Örnek Login İsteği (POST /api/auth/login)

```json
{
  "username": "testuser",
  "password": "1234"
}
