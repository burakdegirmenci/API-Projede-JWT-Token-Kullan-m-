# 🔒 JWT Token Kullanımı ile API Projesi

Bu proje, JWT (JSON Web Token) kullanarak kimlik doğrulama ve yetkilendirme işlemlerini gerçekleştiren bir API'dir. Proje, kullanıcıların login ve register işlemlerini yapmalarına olanak tanır ve login olan kullanıcıların token ile numaraları alabilmesini sağlar.

## ✨ Özellikler

- **🔐 Kimlik Doğrulama ve Yetkilendirme**: JWT kullanılarak güvenli kimlik doğrulama.
- **📥 Login ve Register İşlemleri**: Kullanıcıların sisteme kayıt olmaları ve giriş yapmaları.
- **🔢 GetNumbers Metodu**: Sadece login olan kullanıcıların erişebileceği bir metod.

## 📦 Kullanılan Paketler

- **EntityFramework Core**: Veritabanı işlemleri için.
- **Identity**: Kullanıcı kimlik doğrulama ve yönetimi için.
- **Sql Server**: Veritabanı yönetim sistemi.
- **AspNetCore.Authentication.JwtBearer**: JWT tabanlı kimlik doğrulama için.

## 📂 Proje Yapısı

### 🛠 Entity Framework Core ve Identity

Projede, Entity Framework Core kullanılarak veritabanı işlemleri gerçekleştirilmiştir. Identity ile kullanıcı yönetimi ve kimlik doğrulama işlemleri yapılmaktadır.

### 🔑 JWT Authentication

`AspNetCore.Authentication.JwtBearer` paketi kullanılarak JWT tabanlı kimlik doğrulama işlemleri yapılmıştır. Kullanıcılar, login olduktan sonra bir JWT token alır ve bu token ile güvenli bir şekilde API'ye istek yapabilirler.

### 🌐 API Metodları

- **🔑 Register**: Kullanıcı kayıt olma işlemi.
- **🔓 Login**: Kullanıcı giriş yapma işlemi ve JWT token alma.
- **🔢 GetNumbers**: Sadece login olan kullanıcıların erişebileceği numaraları getiren metod.

