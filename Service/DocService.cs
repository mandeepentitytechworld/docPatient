using DocPatient.Context;
using DocPatient.Models;
using DocPatient.Models.DBModel;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DocPatient.Service
{
    public class DocService : IDocService
    {
        private readonly EFDbContext eFDbContext;

        public DocService(EFDbContext eFDbContext)
        {
            this.eFDbContext = eFDbContext;
        }

        public async Task<List<DocDetail>> GetDocs()
        {
            var result = new List<DocDetail>();

            result = await eFDbContext.DocDetail.Select(c => c).ToListAsync();

            return result;
        }

        public async Task<List<PatientDetail>> GetDocsPatients(int docId)
        {
            var result = new List<PatientDetail>();

            var pds = await eFDbContext.DocPatients.Where(c => c.DocId == docId).Select(c => c).ToListAsync();

            foreach (var pd in pds)
            {
                var p = await eFDbContext.PatientDetails.Where(c => c.PId == pd.PId).Select(c => c).FirstOrDefaultAsync();
                var d = await eFDbContext.DocDetail.Where(c => c.DocId == pd.DocId).Select(c => c).FirstOrDefaultAsync();

                var pdModel = new PatientDetail
                {
                    PId = pd.PId,
                    Address = p.Address,
                    BloodGroup = p.BloodGroup,
                    DOB = p.DOB,
                    Email = p.Email,
                    Height = p.Height,
                    Name = p.Name,
                    PhoneNumber = p.PhoneNumber,
                    RegistrationDate = p.RegistrationDate,
                    Weight = p.Weight,
                };

                result.Add(pdModel);
            }

            return result;
        }

        public async Task<List<AllergiesViewModel>> GetPatientAllergies(int pId)
        {
            var pa = await eFDbContext.PatientAllergies.Where(c => c.PId == pId).Select(c => c).ToListAsync();

            var result = new List<AllergiesViewModel>();

            foreach (var a in pa)
            {
                var p = await eFDbContext.PatientDetails.Where(c => c.PId == pId).Select(c => c).FirstOrDefaultAsync();

                var data = new AllergiesViewModel
                {
                    PId = a.PId,
                    AId = a.AId,
                    AllergySeverity = a.AllergySeverity,
                    AllergyType = a.AllergyType,
                    Notes = a.Notes,

                    PName = p.Name,
                    BloodGroup = p.BloodGroup,
                    DOB = p.DOB,
                    Height = p.Height,
                    Weight = p.Weight,
                };

                result.Add(data);
            }

            return result;
        }

        public async Task<List<MedicationViewModel>> GetPatientMedications(int pId)
        {
            var pa = await eFDbContext.PatientMedications.Where(c => c.PId == pId).Select(c => c).ToListAsync();

            var result = new List<MedicationViewModel>();

            foreach (var a in pa)
            {
                var p = await eFDbContext.PatientDetails.Where(c => c.PId == pId).Select(c => c).FirstOrDefaultAsync();
                var d = await eFDbContext.DocDetail.Where(c => c.DocId == a.DocId).Select(c => c).FirstOrDefaultAsync();

                var data = new MedicationViewModel
                {
                    MId = a.MId,
                    BloodWorkRequest = a.BloodWorkRequest,
                    DIN = a.DIN,
                    MedType = a.MedType,

                    DName = d.Name,

                    PName = p.Name,
                    BloodGroup = p.BloodGroup,
                    DOB = p.DOB,
                    Height = p.Height,
                    Weight = p.Weight,
                };

                result.Add(data);
            }

            return result;
        }

        public async Task<DocPatientAppointments> GetAppointments(int pId, int dId)
        {
            var result = new DocPatientAppointments();
            result.DocId = dId;
            result.PId = pId;

            result.AppointmentViewModels = new List<AppointmentViewModel>();
            result.DocsViewModels = new List<DocsViewModel>();
            result.PatientViewModels = new List<PViewModel>();

            var allDocs = await eFDbContext.DocDetail.ToListAsync();

            foreach (var adoc in allDocs)
            {
                var doc = new DocsViewModel
                {
                    Id = adoc.DocId,
                    Name = adoc.Name,
                };

                result.DocsViewModels.Add(doc);
            }

            var allps = await eFDbContext.PatientDetails.ToListAsync();

            foreach (var aps in allps)
            {
                var ap = new PViewModel
                {
                    Id = aps.PId,
                    Name = aps.Name,
                };

                result.PatientViewModels.Add(ap);
            }

            var app = new List<Appointment>();

            if (pId > 0)
            {
                app = await eFDbContext.Appointments.Where(c => c.PId == pId).Select(c => c).ToListAsync();
            }

            if (dId > 0)
            {
                app = await eFDbContext.Appointments.Where(c => c.DocId == dId).Select(c => c).ToListAsync();
            }

            foreach (var item in app)
            {
                var p = await eFDbContext.PatientDetails.Where(c => c.PId == item.PId).Select(c => c).FirstOrDefaultAsync();
                var d = await eFDbContext.DocDetail.Where(c => c.DocId == item.DocId).Select(c => c).FirstOrDefaultAsync();

                var data = new AppointmentViewModel
                {
                    PId = item.PId,
                    AppId = item.AppId,
                    BookingDate = item.BookingDate,
                    Date = item.Date,
                    DocId = item.DocId,
                    Location = item.Location,
                    PreNotes = item.PreNotes,
                    Status = item.Status,

                    DocName = d.Name,
                    PatientName = p.Name
                };

                result.AppointmentViewModels.Add(data);
            }

            return result;
        }
    }
}
