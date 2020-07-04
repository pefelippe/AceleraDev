using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        CodenationContext _context;

        public CompanyService(CodenationContext context)
        {
            _context = context;
        }
        public IList<Company> FindByAccelerationId(int accelerationId) //retornar uma lista de empresas a partir do id 
        {
            return _context.Candidates
                .Where(x => x.AccelerationId == accelerationId)
                .Select(x => x.Company)
                .ToList();
        }

        public Company FindById(int id) // retornar uma empresa
        {
            return _context.Companies
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
        }

        public IList<Company> FindByUserId(int userId) //  retornar uma lista de empresas 
        {
            return _context.Candidates
                .Where(x=> x.UserId == userId)
                .Select(x => x.Company)
                .ToList();
        }

        public Company Save(Company company)
        {
            
            if (FindById(company.Id) == null)
            {
                _context.Companies.Add(company);
                _context.SaveChanges();
                return _context.Companies.Last();
            }

            var update = _context.Companies.Where(x => x.Id == company.Id).SingleOrDefault();
            update = company;
            _context.SaveChanges();
            return update;
        }
    }
}