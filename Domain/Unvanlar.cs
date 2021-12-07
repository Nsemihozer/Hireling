using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Unvanlar
    {
        [Key]
        public int UnvanID { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string UnvanAdi { get; set; }
 
    }
}