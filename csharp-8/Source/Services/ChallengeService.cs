using System.Collections.Generic;
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

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            throw new System.NotImplementedException();
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            throw new System.NotImplementedException();
        }
    }
}