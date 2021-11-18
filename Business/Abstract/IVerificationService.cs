using Entities.Concrete;

namespace Business.Abstract
{
    public interface IVerificationService
    {
        bool VerifyCustomer(Customer customer);
    }
}
