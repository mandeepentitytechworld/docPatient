using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocPatient.Models.DBModel
{
    [Table("medications")]
    public class PatientMedications
    {
        [Key]
        public int MId { get; set; }

        public int PId { get; set; }

        public int DocId { get; set; }

        public string DIN { get; set; }

        public string MedType { get; set; }

        public string BloodWorkRequest { get; set; }
    }
}
