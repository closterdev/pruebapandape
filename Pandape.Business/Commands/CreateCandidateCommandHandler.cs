using Pandape.Business.Interfaces;
using Pandape.Data.Command;
using Pandape.Data.Entities;
using Pandape.Data.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Pandape.Business.Commands
{
    public class CreateCandidateCommandHandler : ICommandHandler<CreateCandidateCommand, int>
    {
        private readonly ICandidateRepository _candidateContext;

        public CreateCandidateCommandHandler(ICandidateRepository dataContext)
        {
            _candidateContext = dataContext;
        }

        public async Task<int> Handle(CreateCandidateCommand command)
        {
            var newCandidate = new Candidate
            {
                Name = command.Name,
                Surname = command.Surname,
                Birthday = command.Birthday,
                Email = command.Email,
                InsertDate = DateTime.Now
            };

            newCandidate.Experiences = command.Experiences.Select(x => new CandidateExperience
            {
                Company = x.Company,
                Job = x.Job,
                Description = x.Description,
                Salary = x.Salary,
                BeginDate = x.BeginDate,
                EndDate = x.EndDate.HasValue ? x.EndDate : null,
                InsertDate = DateTime.Now,
                Candidate = newCandidate
            }).ToList();

            await _candidateContext.AddCandidate(newCandidate);

            return newCandidate.IdCandidate;
        }
    }
}
