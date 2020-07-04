using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        CodenationContext _context;
        public AccelerationService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            return _context.Candidates
                   .Where(X => X.CompanyId == companyId)
                   .Select(X => X.Acceleration)
                   .Distinct()
                   .ToList();
        }

        public Acceleration FindById(int id)
        {
            return _context.Accelerations.First(a => a.Id == id);
        }

        public Acceleration Save(Acceleration acceleration)
        {

            if (acceleration.Id == 0)
            {
                _context.Accelerations.Add(acceleration);
            }

            else
            {
                var accelerationResult = _context.Accelerations
                                         .Where(x => x.Id == acceleration.Id)
                                         .First();

                accelerationResult = acceleration;
            }

            _context.SaveChanges();

            return acceleration;
        }
    }
}
