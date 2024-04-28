using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIProjectAssessment.Models
{
    [Table("Tbl_Address")]
    public class AddressLocationModel
    {
        [Key]
        public int AddressID { get; set; }
        public string? Name { get; set; }
        public int? ParentID { get; set; }

    }
}
