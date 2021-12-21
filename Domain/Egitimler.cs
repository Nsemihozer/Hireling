namespace Domain
{
    public class Egitimler
    {
        public Guid EgitimID { get; set; }
        public string EgitimAdi { get; set; }
        public DateTime BaslamaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Aciklama { get; set; }
        public string Kategori { get; set; }
        public bool Iptal { get; set; }
       // public ICollection<EgitimKatilimcilar> Katilimcilar { get; set; } = new List<EgitimKatilimcilar>();
    }
}