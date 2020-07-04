using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly CodenationContext _context;
        public SubmissionService(CodenationContext context)
        {
            _context = context;
        }
        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId) //corr��o de erros
        {
            return _context.Candidates.Where(x => x.AccelerationId == accelerationId)
                                      .Select(x => x.User)
                                      .SelectMany(x => x.Submissions)
                                      .Where(x => x.ChallengeId == challengeId).Distinct().ToList();

        }
        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            return _context.Submissions
                        .Where(x => x.ChallengeId == challengeId)
                        .OrderByDescending(x => x.Score)
                        .FirstOrDefault()
                        .Score;
        }
        public Submission Save(Submission submission)
        {
            if (!(_context.Submissions.Any(x => x.UserId == submission.UserId && x.ChallengeId == submission.ChallengeId))) //not exist 
            {
                _context.Submissions.Add(submission);
                _context.SaveChanges();
                return _context.Submissions.Last();
            }
            else
            {
                var update = _context.Submissions
                             .Where(x => x.UserId == submission.UserId && x.ChallengeId == submission.ChallengeId)
                             .SingleOrDefault();
                update = submission;
                _context.SaveChanges();
                return update;
            }
        }
    }
}