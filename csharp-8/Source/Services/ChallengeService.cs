using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        CodenationContext _context;

        public ChallengeService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId) // ret uma lista de desafios
        {
            return _context.Candidates
                .Where(x => x.UserId == userId && x.AccelerationId == accelerationId)
                .Select(x => x.Acceleration)
                .Select(x => x.Challenge)
                .Distinct()
                .ToList();

        }
        public Models.Challenge Save(Models.Challenge challenge)
        {
            if (challenge.Id == 0)
            {
                _context.Challenges.Add(challenge);
                _context.SaveChanges();
                return _context.Challenges.Last();
            }
            else
            {
                var update = _context.Challenges.Where(x => x.Id == challenge.Id).SingleOrDefault();
                update = challenge;
                _context.SaveChanges();
                return update;
            }
        }
    }
}