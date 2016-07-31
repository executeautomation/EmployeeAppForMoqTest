using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Model
{
    public interface IEmpBenefits
    {

        List<string> GetBasicBenefits(int empId);

        List<string> GetAdditionalBenefits(int empId);

        int GetTotalBenefitsCount(int empId);


    }
}
