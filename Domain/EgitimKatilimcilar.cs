namespace Domain
{
    public class EgitimKatilimcilar
    {
        public int CalisanID { get; set; }
        public Calisanlar Calisan { get; set; }
        public Guid EgitimID { get; set; }
        public Egitimler Activity { get; set; }
        public bool IsEgitici { get; set; }
    }
}