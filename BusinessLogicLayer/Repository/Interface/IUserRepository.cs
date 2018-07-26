using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
    public interface IUserRepository
    {
        bool IsUserValid(User objUser);
        int RegisterUser(Registration objRegister);
        int UpdateAddressDetails(AddressDetails objAddress);
        int UpdateCompanyDetails(CompanyDetails objCompany);
    }
}
