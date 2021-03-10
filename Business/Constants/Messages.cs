using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductDeleted = "Ürün silindi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Bakım süresi içindesiniz";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductDetail = "Ürün listelendi";
        public static string ProductCountOfCategoryError = "Kategoriye eklediğiniz ürün sayısı 10 u geçmiştir";
        public static string ProductExist = "Aynı isimde ürün bulunmaktadır";
        public static string CategoryLimitExceeded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied = "Yetkiniz yoktur";
        public static string UserRegistered = "Kullanıcı kaydı yapıldı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Başarılı kullanıcı girişi";
        public static string UserAlreadyExists = "Kullanıcı daha önceden kayıtlı";
        public static string AccessTokenCreated = "Access Token oluşturuldu";
    }
}
