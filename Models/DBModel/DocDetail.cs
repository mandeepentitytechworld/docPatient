using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocPatient.Models.DBModel
{
    [Table("docdetail")]
    public class DocDetail
    {
        [Key]
        public int DocId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Specialization { get; set; }
    }
}
