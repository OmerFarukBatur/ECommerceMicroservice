# E-Commerce Microservice - Design Choices

## 1. Architecture

Bu proje **N Katmanlý mimari (N Layered Architecture)** kullanýlarak tasarlanmýþtýr:

- **Core**: Entity sýnýflarý ve repository arayüzleri. Uygulamanýn domain modeli burada yer alýr.
- **Application**: Business logic ve servisler (ProductService, CategoryService). Validasyon ve iþ kurallarý burada iþlenir.
- **Infrastructure**: DbContext ve repository implementasyonlarý (EF Core). Data access burada izole edilmiþtir.
- **API**: ASP.NET Core Web API. Controller’lar, endpoint’ler ve dependency injection burada yapýlandýrýlmýþtýr.

## 2. Design Patterns

Projede kullanýlan bazý design pattern’ler:

- **Repository Pattern**: Data access layer (Infrastructure) ile Application katmaný arasýndaki baðý soyutlar.
- **Dependency Injection**: Controller ve servisler arasý baðýmlýlýklarý yönetir. Test edilebilirliði artýrýr.
- **DTO / ViewModel Pattern**: API’den gelen ve giden veri tiplerini entity’den ayýrýr. Validation ve serileþtirme için kullanýlýr.
- **FluentValidation**: Validation kurallarýný ayrý sýnýflarda tanýmlayarak Single Responsibility Principle’ý destekler.
- **Middleware Pattern**: Global error handling ve logging için kullanýlýr.

## 3. Logging & Error Handling

- **Serilog** kullanýldý. Tüm hatalar ve request/response loglarý merkezi bir þekilde yönetilir.
- Exception middleware ile global hata yönetimi saðlandý.

## 4. Database & Migration

- EF Core Code-First yaklaþýmýyla database oluþturuldu.
- Seed data ile baþlangýç verileri saðlandý.