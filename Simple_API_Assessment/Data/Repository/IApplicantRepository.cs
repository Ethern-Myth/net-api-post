using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data.Repository
{
    /** NOTES:
     * Generic Repository for flexibility
    public interface IApplicantRepository<T>
    {
        public Task<IList<T>> All();
        public Task<T> Single(dynamic id);
        public Task Add<T>(T t);
        public Task Update<T>(dynamic id, T t);
        public Task Remove(dynamic id);
    }
    **/

    public interface IApplicantRepository
    {
        public Task<IList<Applicant>> All();
        public Task<Applicant> Single(int id);
        public Task Add(Applicant applicant);
        public Task Update(int id, Applicant applicant);
        public Task Remove(int id);
    }
}
