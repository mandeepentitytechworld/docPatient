using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocPatient.Models.DBModel
{
    [Table("appointment")]
    public class Appointment
    {
        [Key]
        public int AppId { get; set; }

        public int PId { get; set; }

        public int DocId { get; set; }

        public DateTime Date { get; set; }

        public string PreNotes { get; set; }

        public string Location { get; set; }

        public string Status { get; set; }

        public DateTime BookingDate { get; set; }
    }
}
