using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PFService
{
     public class EmpPfDetails : IEmpPfDetails
    {
        public double? GetPfEmployeeControlSofar(int empId)
        {
            double? salary;
            int? totalDuration;

            using (var employeeEntity = new EmployeeEntity())
            {
                salary = employeeEntity.Employees.Where(x => x.EmpId == empId).Select(x => x.Salary).FirstOrDefault();
                totalDuration = employeeEntity.Employees.Where(x => x.EmpId == empId).Select(x => x.DurationWorked).FirstOrDefault();
            }

            //Salary * 18% of basic (considering basic as 30% of salary)

            //Basic salary
            var basic = (salary * 30) / 100;

            //12% of basic
            var contribution = (basic * 18) / 100;

            return (contribution * totalDuration);


        }

        public double? GetPfEmployerControlSofar(int empId)
        {
            double? salary;
            int? totalDuration;
            using (var employeeEntity = new EmployeeEntity())
            {
                salary = employeeEntity.Employees.Where(x => x.EmpId == empId).Select(x => x.Salary).FirstOrDefault();
                totalDuration = employeeEntity.Employees.Where(x => x.EmpId == empId).Select(x => x.DurationWorked).FirstOrDefault();
            }

            //Salary * 12% of basic (considering basic as 30% of salary)

            //Basic salary
            var basic = (salary * 30) / 100;

            //12% of basic
            var contribution = (basic * 12) / 100;

            return (contribution * totalDuration);
        }

        public bool IsPfEligible(int empId)
        {
            double? salary;
            using (var employeeEntity = new EmployeeEntity())
            {
                salary = employeeEntity.Employees.Where(x => x.EmpId == empId).Select(x => x.Salary).FirstOrDefault();
            }

            if (salary >= 4000)
                return true;
            else
                return false;
        }
    }
}
