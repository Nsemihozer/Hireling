using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Calisanlar
    {

        [Key]
        public int CalisanID { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Adi { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Soyadi { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string TcNo { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? SSkNo { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public DateTime? IseGirisTarihi { get; set; }
        public int FirmaID { get; set; }
        public byte? Cinsiyet { get; set; }
        public byte? Medeni { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string KullaniciAdi { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Sifre { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Telefon { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? BrutMaas { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? NetMaas { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? IzinSaat { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? KullanilanIzinSaat { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? IzinGun { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? KullanilanIzinGun { get; set; }
        public int? UnvanID { get; set; }
        public int? BirimID { get; set; }




    }
}