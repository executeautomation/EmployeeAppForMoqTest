using System.ServiceModel;

namespace PFService
{
    /// <summary>
    /// Author : Karthik KK
    /// Company : ExecuteAutomation.com
    /// </summary>
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
