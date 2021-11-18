using Business.Abstract;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ValidateCustomerManager : BaseCustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IVerificationService _verificationService;
        public ValidateCustomerManager(IRepository<Customer> customerRepository, IVerificationService verificationService) : base(customerRepository)
        {
            _customerRepository = customerRepository;
            _verificationService = verificationService;
        }

        public override async Task<Customer> AddAsync(Customer entity)
        {
            if (_verificationService.VerifyCustomer(entity))
            {
                return await base.AddAsync(entity);
            }
            return null;
        }
    }
}
