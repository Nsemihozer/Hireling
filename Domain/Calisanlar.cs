using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Calisanlar
    {
         [Key]
        public int CalisanID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public  string TcNo { get; set; }
        public  string SSkNo { get; set; }
        public DateTime DogumTarihi { get; set; }
        public DateTime IseGirisTarihi { get; set; }
        public int FirmaID { get; set; }
        public int BirimID { get; set; }
        public int UnvanID { get; set; }
        public byte Cinsiyet { get; set; }
        public byte Medeni { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Telefon { get; set; }
        public decimal BrutMaas { get; set; }
        public decimal NetMaas { get; set; }
        public decimal IzinSaat { get; set; }
        public decimal KullanilanIzinSaat { get; set; }
        public decimal IzinGun { get; set; }
        public decimal KullanilanIzinGun { get; set; }
        


    }
}