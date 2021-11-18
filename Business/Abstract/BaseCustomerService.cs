using DataAccess.Repositories.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public abstract class BaseCustomerService : ICustomerService
    {
        private IRepository<Customer> _customerRepository;
        protected BaseCustomerService(IRepository<Customer> customerReposittory)
        {
            _customerRepository = customerReposittory;
        }

        public virtual async Task<Customer> AddAsync(Customer entity)
        {
            await _customerRepository.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<bool> AnyAsync(long identificationNumber)
        {
            return await _customerRepository.AnyAsync(x => x.IdentificationNumber == identificationNumber);
        }
    }
}
