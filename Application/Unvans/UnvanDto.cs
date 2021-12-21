using Application.Calisans;

namespace Application.Unvans
{
    public class UnvanDto
    {
        public int UnvanID { get; set; }
        public string UnvanAdi { get; set; }
        public ICollection<CalisanDto> Calisanlar { get; set; }
    }
}