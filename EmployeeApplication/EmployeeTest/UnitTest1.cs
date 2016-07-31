using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using EmployeeApplication.Entitiy;
using EmployeeApplication.Model;
using Moq;
using NUnit.Framework;


namespace EmployeeTest
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            //Arrange
            var moqEmpPerDetail = new Mock<IEmpPersonalDetails>(MockBehavior.Strict);

            moqEmpPerDetail.Setup(x => x.GetDurationWorked(It.IsAny<int>())).Returns(20);
            moqEmpPerDetail.Setup(x => x.GetEmployeeSalary(It.IsAny<int>())).Returns(20);

            var pfEmpDetail = new EmpPfDetails(moqEmpPerDetail.Object);

            //Act
            pfEmpDetail.GetPfEmployerControlSofar(It.IsAny<int>());

            //Assert
            moqEmpPerDetail.Verify(x => x.GetDurationWorked(It.IsAny<int>()));

        }

    }
}
