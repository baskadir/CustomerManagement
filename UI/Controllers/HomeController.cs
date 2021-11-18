using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEnumerable<ICustomerService> _customerServices;
        private readonly ICustomerService _customerService;
        private readonly ICompanyService _companyService;
        public HomeController(IEnumerable<ICustomerService> customerServices, ICompanyService companyService, ICustomerService customerService)
        {
            _customerServices = customerServices;
            _companyService = companyService;
            _customerService = customerService;
        }

        public async Task<IActionResult> Create()
        {
            CustomerCreateModel model = new();
            await AddCompaniesToModel(model);
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateModel model)
        {
            if (model.CompanyId == 1)
            {
                var validateCustomerService = _customerServices.SingleOrDefault(x => x.GetType() == typeof(ValidateCustomerManager));
                if (await validateCustomerService.AnyAsync(model.IdentificationNumber))
                {
                    ModelState.AddModelError("DuplicateCustomer","Müşteri zaten kayıtlı");
                    await AddCompaniesToModel(model);
                    return View(model);
                }
                var data = await validateCustomerService.AddAsync(MapToEntity(model));
                if (data == null)
                    ModelState.AddModelError("IdentityVerificationError", "Müşteri bilgileri hatalı.");
                await AddCompaniesToModel(model);
                return data != null ? RedirectToAction("Success") : View(model);
            }

            if (model.CompanyId == 2)
            {
                var customerService = _customerServices.SingleOrDefault(x => x.GetType() == typeof(CustomerManager));
                if (await customerService.AnyAsync(model.IdentificationNumber))
                {
                    ModelState.AddModelError("DuplicateCustomer", "Müşteri zaten kayıtlı");
                    await AddCompaniesToModel(model);
                    return View(model);
                }
                await customerService.AddAsync(MapToEntity(model));
                return RedirectToAction("Success");
            }

            await AddCompaniesToModel(model);
            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }

        private async Task AddCompaniesToModel(CustomerCreateModel model)
        {
            var companies = await _companyService.GetAllAsync();
            model.Companies = new SelectList(companies, "Id", "CompanyName");
        }

        private static Customer MapToEntity(CustomerCreateModel model)
        {
            return new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                IdentificationNumber = model.IdentificationNumber,
                BirthDate = model.BirthDate,
                CompanyId = model.CompanyId
            };
        }
    }
}
