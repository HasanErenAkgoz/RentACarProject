using Core.Entities.Concrete;
using Entity.Concrate;
using System;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ItemAdded = "Bilgiler Sisteme Eklendi!";
        public static string ItemAddFailed = "Bilgiler Sisteme Eklenemedi!";
        public static string ItemUpdated = "Bilgiler Güncellendi!";
        public static string ItemUpdateFailed = "Bilgiler Güncellenemedi!";
        public static string ItemDeleted = "Veriler Sistemden Kaldırıldı!";
        public static string ItemDeleteFailed = "Veriler Sistemden Kaldırılamadı!";
        public static string CarNameInvalid = "Girilen Araç Adı Geçersizdir!";
        public static string maxFindexScore = "Aracın Findex Puanı Maximum 1900 Olmalıdır";
        public static string minFindexScore = "Aracın Findex Puanı Minimum 0 Olmalıdır";
        public static string CarPriceInvalid = "Araç Fiyat Bilgisi 0 ve ya -(Eksi) Değer Alamaz";
        public static string ItemsListed = "Bilgiler Listelendi";
        public static string MaintenanceTime = "Sistem Bakımdadır.";
        public static string ItemsListFailed = "Bilgiler Listelenemedi";
        public static string RentalInvalid = "Araç Kiralanamaz";
        public static string ImageLimitExceeded = "Araç Fotoğraf Sayısı 5 Adetten Fazla Olamaz.";
        public static string AuthorizationDenied = "Erişim Reddedildi!";
        public static string ErrorNullData = "Lütfen Boş Veri Bırakmayınız.!";
        public static string CarCountOfPlateError = "Araç Limiti Aşıldı Maalesef Araç Ekleme İşlemi Yapamıyoruz";
        public static string CarNameAlreadyExist = "Bu Arac Daha Önce Kaydedilmiş";
        public static string CarCheckImageLimited = "Limit Doldu Daha Fazla Ekleme Yapamıyoruz";
        public static string CarImageAdded = "Resim Ekleme İşlemi Başarılı";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string UserRegistered = "Kayıt İşlemi Tamamlandı";
        public static string PasswordError = "Hatalı veya eksik şifre girdiniz";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string AccessTokenCreated = "Giriş Başarılı! Hoş Geldiniz.";
        public static string UserAlreadyExists = "Kullanıcı Mevcut";
        public static string RentalAddedError = "Seçtiğiniz Tarihlerde Bu Araç Müsait Değildir";
        public static string RentalNotDelivered = "Araç Kiralanamadı";
        public static string FindeksError = "Findeks Puanı Yetersiz";
        public static string FindeksSuccess = "Findeks Puanı Yeterli";
        public static string CreditCardAdded = "Kredi Kartınız Sisteme Eklendi";
        public static string PaymentError = "Ödeme İşlemi Tamamlanamadı";
        public static string PaymentSuccess = "Ödeme İşlemi Başarıyla Tamamlandı. İyi Yolculuklar";
        public static string CustomerListed = "Müşteriler Listelendi";
        public static string CarIsntAvailable = "Araç Mevcut Değil";
        public static string OperationClaimAdded = "Claim Eklenme Başarılı";
        public static string OperationClaimDeleted = "Claim Silme Başarılı";
        public static string OperationClaimUpdated = "Claim Güncelleme Başarılı";
        public static string UserOperationClaimUpdated = "Kullanıcı Claim Güncelleme Başarılı";
        public static string UserOperationClaimAdded = "Kullanıcı Claim Ekleme Başarılı";
        public static string UserOperationClaimDeleted = "Kullanıcı Claim Silme Başarılı";
        public static string CarAdd = "Araç Ekleme İşlemi Başarılı";
        public static string CarListed = "Araç Listeleme Başarılı";
    }
}