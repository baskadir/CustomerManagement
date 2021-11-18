using Business.Abstract;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : BaseCustomerService
    {
        public CustomerManager(IRepository<Customer> customerRepository):base(customerRepository)
        {
        }
    }
}
