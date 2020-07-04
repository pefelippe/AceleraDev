using System.Collections.Generic;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        CodenationContext _context;
        public SubmissionService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            throw new System.NotImplementedException();
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            throw new System.NotImplementedException();
        }

        public Submission Save(Submission submission)
        {
            throw new System.NotImplementedException();
        }
    }
}
