using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public IList<User> FindByAccelerationName(string name) // retornar uma lista de usuários
        {
            return _context.Accelerations
                 .Where(x => x.Name == name)
                 .SelectMany(x => x.Candidates)
                 .Select(x => x.User)
                 .ToList();
         }

        public IList<User> FindByCompanyId(int companyId) // retornar uma lista de usuários
        {
            return _context.Candidates
                   .Where(x => x.CompanyId == companyId)
                   .Select(x => x.User)
                   .Distinct()
                   .ToList();
        }

        public User FindById(int id) // retornar um usuário 
        {
            return _context.Users
                        .Where(x => x.Id == id)
                        .First();
 
        }

        public User Save(User user)
        {
            if (user.Id == 0)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return _context.Users.Last();
            }
            else
            {
                var update = _context.Users.Where(x => x.Id == user.Id).First();
                update = user;
                _context.SaveChanges();
                return update;
            }
        }
    }
}
