using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Departmanlar
    {


        [Key]
        public int DepartmanID { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string DepartmanAdi { get; set; }
        public int SorumluId { get; set; }

         public ICollection<Calisanlar> Calisanlar { get; set; }
        public Calisanlar Sorumlu { get; set; }
    }
}