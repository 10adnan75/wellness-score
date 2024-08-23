using Wellness_Score_API.DataContext;
using Wellness_Score_API.Interfaces;
using Wellness_Score_API.Models;

namespace Wellness_Score_API.Repository
{
    public class DiagnosisRepository : IDiagnosisRepository
    {
        private readonly ApplicationDbContext _context;

        public DiagnosisRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool AddDiagnosis(Diagnosis diagnosis)
        {
            _context.Diagnoses.Add(diagnosis);
            return save();
        }

        public bool DeleteDiagnosis(int id)
        {
            Diagnosis diagnosis = GetDiagnosis(id);

            _context.Diagnoses.Remove(diagnosis);
            return save();


        }

        public bool DiagnosisExists(int id)
        {
            return _context.Diagnoses.Any(x => x.Id == id);
        }

        public bool EditDiagnosis(Diagnosis diagnosis)
        {
            _context.Diagnoses.Update(diagnosis);
            return save();
        }

        public Diagnosis GetDiagnosis(int id)
        {
            return _context.Diagnoses.FirstOrDefault(x => x.Id == id);
        }

        public bool save()
        {
            var s = _context.SaveChanges();
            return s > 0 ? true : false;
        }
    }
}