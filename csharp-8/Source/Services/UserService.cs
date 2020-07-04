using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        CodenationContext _context;
        public UserService(CodenationContext context)
        {
            _context = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {
            throw new System.NotImplementedException();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            throw new System.NotImplementedException();
        }

        public User FindById(int id)
        {
            var user = _context.Users
                        .Where(x => x.Id == id)
                        .First();

            return user;
        }

        public User Save(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
