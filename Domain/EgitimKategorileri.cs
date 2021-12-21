namespace Domain
{
    public class EgitimKategorileri
    {
         public int EgitimKategoriID { get; set; }
        public string KategoriAdi { get; set; }
        public ICollection<Egitimler> Egitimler { get; set; }

    }
}