using Microsoft.EntityFrameworkCore;
using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data.Repository
{ 
    public class ApplicantRepo : IApplicantRepository
    {
        private readonly DataContext context;
        public ApplicantRepo(DataContext context)
        {
            this.context = context;
        }

        // GET all applicants
        public async Task<IList<Applicant>> All()
        {
            var applicants = await context.Applicants
                                  .Include(s => s.Skills)
                                  .AsNoTracking()
                                  .ToListAsync();

            return applicants.Select(a => new Applicant
            {
                Id = a.Id,
                Name = a.Name,
                Skills = a.Skills.Select(s => new Skill
                {
                    Id = s.Id,
                    Name = s.Name,
                    ApplicantId = s.ApplicantId
                }).ToList()
            }).ToList();
        }

        // SINGLE applicant
        public async Task<Applicant> Single(int id)
        {
            var applicant = await context.Applicants
                                 .Include(s => s.Skills)
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(t => t.Id == id);

            if (applicant == null)
                return null;

            return new Applicant
            {
                Id = applicant.Id,
                Name = applicant.Name,
                Skills = applicant.Skills.Select(s => new Skill
                {
                    Id = s.Id,
                    Name = s.Name,
                    ApplicantId = s.ApplicantId
                }).ToList()
            };
        }

        // ADD applicant
        public async Task Add(Applicant applicant)
        {
            context.ChangeTracker.Clear();
            await context.Applicants.AddAsync(applicant);
            await context.SaveChangesAsync();
        }

        // UPDATE applicant
        public async Task Update(int id, Applicant applicant)
        {
            context.ChangeTracker.Clear();
            if (context.Applicants.Any(t => t.Id == id))
            {
                await Task.Run(() => context.Applicants.Update(applicant));
            }
            await context.SaveChangesAsync();
        }

        // REMOVE applicant
        public async Task Remove(int id)
        {
            var response = await context.Applicants.SingleAsync(t => t.Id == id);
            context.ChangeTracker.Clear();
            context.Remove(response);
            await context.SaveChangesAsync();
        }
    }
}
