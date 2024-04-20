using Microsoft.AspNetCore.Mvc;
using Simple_API_Assessment.Data.Repository;
using Simple_API_Assessment.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Simple_API_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantRepository repository;
        public ApplicantController(IApplicantRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/<ApplicantController>
        [HttpGet]
        public async Task<IEnumerable<Applicant>> Get()
        {
            return await repository.All();
        }

        // GET api/<ApplicantController>/5
        [HttpGet("{id:int}")]
        public async Task<Applicant> Get(int id)
        {
            return await repository.Single(id);
        }

        // POST api/<ApplicantController>
        [HttpPost]
        public async Task<Applicant> Post([FromBody] ApplicantDto applicantDto)
        {
            var applicant = new Applicant()
            {
                Name = applicantDto.Name,
            };
            await repository.Add(applicant);
            return await repository.Single(applicant.Id);
        }

        // PUT api/<ApplicantController>/5
        [HttpPut("{id:int}")]
        public async Task<Applicant> PutAsync(int id, [FromBody] ApplicantDto applicantDto)
        {
            var applicant = new Applicant()
            {
                Id = id,
                Name =  applicantDto.Name
            };
            await repository.Update(id, applicant);
            return await repository.Single(id);
        }

        // DELETE api/<ApplicantController>/5
        [HttpDelete("{id:int}")]
        public async Task<NoContentResult> Delete(int id)
        {
            await repository.Remove(id);
            return NoContent();
        }
    }
}
