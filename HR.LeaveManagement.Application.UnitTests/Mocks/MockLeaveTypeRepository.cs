using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Mocks
{
    public static class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes =

            new List<LeaveType>
            {
                new LeaveType
                {
                    Id =1,
                Name ="Vacation",
                DefaultDays = 10
            },
            new LeaveType
            {
                Id = 2,
                Name = "Sick",
                DefaultDays = 12
            }
            };

            var mockRepo = new Mock<ILeaveTypeRepository>();
            mockRepo.Setup(q => q.GetAll()).ReturnsAsync(leaveTypes);

            mockRepo.Setup(q => q.Add(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) =>
            {
                leaveTypes.Add(leaveType);
                return leaveType;
            });

            return mockRepo;


        }
        
    }
}
