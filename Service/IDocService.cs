using DocPatient.Models;
using DocPatient.Models.DBModel;
using System;
using System.Security.Cryptography;

namespace DocPatient.Service
{
    public interface IDocService
    {
        Task<List<DocDetail>> GetDocs();

        Task<List<PatientDetail>> GetDocsPatients(int docId);

        Task<List<AllergiesViewModel>> GetPatientAllergies(int pId);

        Task<List<MedicationViewModel>> GetPatientMedications(int pId);

        Task<DocPatientAppointments> GetAppointments(int pId, int dId);
    }
}
