# E-Commerce Microservice

## Overview

Bu proje, ASP.NET Core Web API ile geliştirilmiş, Entity Framework Core kullanılarak veri yönetimi yapılan bir E-Commerce mikroservis örneğidir.  

Proje, **katmanlı mimari** ile tasarlanmıştır:

- **Core**: Entity sınıfları ve repository arayüzleri.
- **Application**: Business logic ve servisler (ProductService, CategoryService), DTO ve validation.
- **Infrastructure**: EF Core DbContext ve repository implementasyonları.
- **API**: Controller’lar, endpoint’ler, middleware, dependency injection ve Swagger/OpenAPI.

---

## Prerequisites

- .NET 8 SDK
- SQL Server (localdb)
- IDE: Visual Studio 2022 veya VS Code

---

## Packages Used

| Paket | Kullanım Alanı | Açıklama |
|-------|----------------|----------|
| `Microsoft.EntityFrameworkCore` | Infrastructure | EF Core ORM, veritabanı işlemleri için |
| `Microsoft.EntityFrameworkCore.SqlServer` | Infrastructure | SQL Server provider |
| `Microsoft.EntityFrameworkCore.Tools` | Infrastructure | Migration ve update komutları için |
| `FluentValidation.AspNetCore` | Application/API | DTO ve entity validasyonu için |
| `Swashbuckle.AspNetCore` | API | Swagger/OpenAPI entegrasyonu |
| `Serilog.AspNetCore` | API | Centralized logging ve hata yönetimi |
| `Serilog.Sinks.Console` | API | Console loglama |
| `Serilog.Sinks.File` | API | Logları dosyaya yazmak için |

---

## Database

- **Veritabanı**: SQL Server (localdb varsayılan)
- **Yaklaşım**: EF Core Code-First
- **DbContext**: `ECommerceDbContext` (Infrastructure katmanı)
- **Seed Data**: Category ve Product tabloları için başlangıç verileri oluşturulmuştur
