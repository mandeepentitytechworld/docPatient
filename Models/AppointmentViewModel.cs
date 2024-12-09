namespace DocPatient.Models
{
    public class DocPatientAppointments
    {
        public List<AppointmentViewModel> AppointmentViewModels { get; set; }
        public List<DocsViewModel> DocsViewModels { get; set; }
        public List<PViewModel> PatientViewModels { get; set; }

        public int DocId { get; set; }

        public int PId { get; set; }
    }

    public class AppointmentViewModel
    {
        public int AppId { get; set; }

        public int PId { get; set; }

        public string PatientName { get; set; }

        public int DocId { get; set; }

        public string DocName { get; set; }

        public DateTime Date { get; set; }

        public string PreNotes { get; set; }

        public string Location { get; set; }

        public string Status { get; set; }

        public DateTime BookingDate { get; set; }
    }

    public class DocsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class PViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
