namespace DocPatient.Models
{
    public class AllergiesViewModel
    {
        public int AId { get; set; }

        public int PId { get; set; }

        public string AllergySeverity { get; set; }

        public string AllergyType { get; set; }

        public string Notes { get; set; }

        public string PName { get; set; }

        public DateTime DOB { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public string BloodGroup { get; set; }
    }

    public class MedicationViewModel
    {
        public int MId { get; set; }

        public int PId { get; set; }

        public int DId { get; set; }

        public string DIN { get; set; }

        public string MedType { get; set; }

        public string BloodWorkRequest { get; set; }

        public string PName { get; set; }

        public string DName { get; set; }

        public DateTime DOB { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public string BloodGroup { get; set; }
    }
}
