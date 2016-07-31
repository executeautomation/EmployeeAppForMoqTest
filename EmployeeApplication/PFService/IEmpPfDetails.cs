using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PFService
{
    [ServiceContract]
    public interface IEmpPfDetails
    {
        [OperationContract]
        bool IsPfEligible(int empId);

        [OperationContract]
        double? GetPfEmployerControlSofar(int empId);

        [OperationContract]
        double? GetPfEmployeeControlSofar(int empId);
    }
}
