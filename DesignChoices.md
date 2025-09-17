# E-Commerce Microservice - Design Choices

## 1. Architecture

Bu proje **N Katmanl� mimari (N Layered Architecture)** kullan�larak tasarlanm��t�r:

- **Core**: Entity s�n�flar� ve repository aray�zleri. Uygulaman�n domain modeli burada yer al�r.
- **Application**: Business logic ve servisler (ProductService, CategoryService). Validasyon ve i� kurallar� burada i�lenir.
- **Infrastructure**: DbContext ve repository implementasyonlar� (EF Core). Data access burada izole edilmi�tir.
- **API**: ASP.NET Core Web API. Controller�lar, endpoint�ler ve dependency injection burada yap�land�r�lm��t�r.

## 2. Design Patterns

Projede kullan�lan baz� design pattern�ler:

- **Repository Pattern**: Data access layer (Infrastructure) ile Application katman� aras�ndaki ba�� soyutlar.
- **Dependency Injection**: Controller ve servisler aras� ba��ml�l�klar� y�netir. Test edilebilirli�i art�r�r.
- **DTO / ViewModel Pattern**: API�den gelen ve giden veri tiplerini entity�den ay�r�r. Validation ve serile�tirme i�in kullan�l�r.
- **FluentValidation**: Validation kurallar�n� ayr� s�n�flarda tan�mlayarak Single Responsibility Principle�� destekler.
- **Middleware Pattern**: Global error handling ve logging i�in kullan�l�r.

## 3. Logging & Error Handling

- **Serilog** kullan�ld�. T�m hatalar ve request/response loglar� merkezi bir �ekilde y�netilir.
- Exception middleware ile global hata y�netimi sa�land�.

## 4. Database & Migration

- EF Core Code-First yakla��m�yla database olu�turuldu.
- Seed data ile ba�lang�� verileri sa�land�.