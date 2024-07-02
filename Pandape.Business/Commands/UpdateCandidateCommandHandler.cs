using Pandape.Business.Interfaces;
using Pandape.Data.Command;
using Pandape.Data.Entities;
using Pandape.Data.Repository;

namespace Pandape.Business.Commands
{
    public class UpdateCandidateCommandHandler : ICommandHandler<UpdateCandidateCommand, int>
    {
        private readonly ICandidateRepository _candidateContext;

        public UpdateCandidateCommandHandler(ICandidateRepository dataContext)
        {
            _candidateContext = dataContext;
        }

        public async Task<int> Handle(UpdateCandidateCommand command)
        {
            Candidate oldCandidate = new()
            {
                Name = command.Name,
                Surname = command.Surname,
                Birthday = command.Birthday,
                Email = command.Email,
                ModifyDate = DateTime.Now
            };

            command.Experiences.ForEach(x => oldCandidate.Experiences.Add(new CandidateExperience
            {
                Company = x.Company,
                Job = x.Job,
                Description = x.Description,
                Salary = x.Salary,
                BeginDate = x.BeginDate,
                EndDate = x.EndDate,
                ModifyDate = DateTime.Now
            }));

            await _candidateContext.UpdateCandidate(oldCandidate);

            return oldCandidate.IdCandidate;
        }
    }
}
