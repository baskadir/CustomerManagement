using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class CustomerCreateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long IdentificationNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int CompanyId { get; set; }
        public SelectList Companies { get; set; }
    }
}
