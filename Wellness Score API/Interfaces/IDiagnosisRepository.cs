using Wellness_Score_API.Models;

namespace Wellness_Score_API.Interfaces
{
    public interface IDiagnosisRepository
    {
        bool AddDiagnosis(Diagnosis diagnosis);
        bool EditDiagnosis(Diagnosis diagnosis);
        Diagnosis GetDiagnosis(int id);
        bool DeleteDiagnosis(int id);
        bool DiagnosisExists(int id);   
        bool save();
    }
}