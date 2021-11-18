using System;

namespace Entities.Concrete
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long IdentificationNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
