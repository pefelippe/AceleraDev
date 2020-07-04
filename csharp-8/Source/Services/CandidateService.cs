using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        CodenationContext _context;
        public CandidateService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            var CandidateList = _context.Candidates
                                .Where(X => X.AccelerationId == accelerationId)
                                .ToList();

            return CandidateList;
        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {
            var CandidateList = _context.Candidates
                                .Where(x => x.CompanyId == companyId)
                                .ToList();

            return CandidateList;
        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            var Candidate = _context.Candidates
                            .Where(x => x.UserId == userId && x.AccelerationId == accelerationId && x.CompanyId == companyId)
                            .First();

            return Candidate;
        }

        public Candidate Save(Candidate candidate)
        {
            var CandidateBD = _context.Candidates
                        .Where(x => x.UserId == candidate.UserId &&
                                    x.AccelerationId == candidate.AccelerationId &&
                                    x.CompanyId == candidate.CompanyId)
                        .First();
            
            if (CandidateBD != null) // => alterar candidato
            {
                CandidateBD = candidate;
            }
            else // => add candidato 
            {
                _context.Candidates.Add(candidate);
            }

            _context.SaveChanges();
            return candidate;
        }
    }
}
