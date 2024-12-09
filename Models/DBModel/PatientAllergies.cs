using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocPatient.Models.DBModel
{
    [Table("allergies")]
    public class PatientAllergies
    {
        [Key]
        public int AId { get; set; }

        public int PId { get; set; }

        public string AllergySeverity { get; set; }

        public string AllergyType { get; set; }

        public string Notes { get; set; }
    }
}
