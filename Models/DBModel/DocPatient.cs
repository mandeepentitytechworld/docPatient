using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocPatient.Models.DBModel
{
    [Table("docpatient")]
    public class DocPatients
    {
        [ForeignKey("docdetail")]
        public int DocId { get; set; }

        [Key]
        public int PId { get; set; }
    }

    [Table("patientdetail")]
    public class PatientDetail
    {
        [Key]
        public int PId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime DOB { get; set; }

        public decimal Weight { get; set; }

        public decimal Height { get; set; }

        public string BloodGroup { get; set; }
    }
}
