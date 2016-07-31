using System;
using System.Collections.Generic;
using EmployeeApplication.Entitiy;
using EmployeeApplication.Model;
using Moq;
using NUnit.Framework;


namespace Testing
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void Video1()
        {

            //Video 1
            //Simple Moq
            //Arrange
            //var pfDetails = new EmpPfDetails(new EmpPersonalDetails());

            ////Act
            //var contrib = pfDetails.GetPfEmployerControlSofar(1);

            ////Assert
            //Assert.That(contrib, Is.EqualTo(3455), "Its not expected");


            //Arrange
            var moqpfDetail = new Mock<IEmpPersonalDetails>();

            var pfDetails = new EmpPfDetails(moqpfDetail.Object);

            //Act
            pfDetails.GetPfEmployerControlSofar(It.IsAny<int>());

            //Assert
            moqpfDetail.Verify();




        }

        [Test]
        public void Video2()
        {
            var moqPersonalDetail = new Mock<IEmpPersonalDetails>();
            moqPersonalDetail.Setup(x => x.GetDurationWorked(It.IsAny<int>()))
                .Returns(() => 24);

            //Act
            int duration = moqPersonalDetail.Object.GetDurationWorked(1);

            Assert.That(duration, Is.EqualTo(20));
        }


        [Test]
        public void Video3()
        {
            //Arrange
            //var moqpfDetail = new Mock<IEmpPersonalDetails>();

            //moqpfDetail.Setup(x => x.GetDurationWorked(It.IsAny<int>()));

            //var pfDetails = new EmpPfDetails(moqpfDetail.Object);

            ////Act
            //pfDetails.GetPfEmployerControlSofar(1);


            ////Assert
            //moqpfDetail.Verify(x => x.GetDurationWorked(It.IsAny<int>()),
            //    Times.Exactly(1));


            //Number of times being called
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    EmpId = 5,
                    DurationWorked = 20,
                    Grade = 3,
                    Name = "Steve",
                    Salary = 9000
                },
                new Employee
                {
                    EmpId = 6,
                    DurationWorked = 30,
                    Grade = 4,
                    Name = "Johnson",
                    Salary = 8000
                }

            };


            //Arrange
            var empPersonalDetail = new Mock<IEmpPersonalDetails>();

            var empDetails = new EmployeesDetails(empPersonalDetail.Object);


            empDetails.GetHigherGradeEmployee(employees);

            empPersonalDetail.Verify(x => x.GetEmployeeDetails(It.IsAny<int>()), Times.Exactly(2));


        }
    }
}
