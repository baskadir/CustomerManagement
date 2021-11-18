using Business.Abstract;
using Entities.Concrete;
using MernisServiceReference;
using System;

namespace Business.Concrete
{
    public class VerificationManager : IVerificationService
    {
        public bool VerifyCustomer(Customer customer)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            bool result = client.TCKimlikNoDogrulaAsync(new TCKimlikNoDogrulaRequest(new TCKimlikNoDogrulaRequestBody(customer.IdentificationNumber, customer.FirstName, customer.LastName, customer.BirthDate.Year))).Result.Body.TCKimlikNoDogrulaResult;
            return result;
        }
    }
}
