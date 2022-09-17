using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Profiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepository;
        public CreateLeaveTypeCommandHandlerTests()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = config.CreateMapper();

            _mockRepository = MockLeaveTypeRepository.GetLeaveTypeRepository();
        }
        [Fact]
        public async Task CreateLeaveTypeCommandHandlerTest()
        {
            var handler = new CreateLeaveTypeCommandHandler(_mockRepository.Object, _mapper);
            var leavetype = new CreateLeaveTypeDto { DefaultDays = 10, Name = "Test Vacation" };
            var result = await handler.Handle(new CreateLeaveTypeCommand { LeaveTypeDto = leavetype }, CancellationToken.None);

            result.ShouldBeOfType<int>();

            //_mockRepository.Verify(q=>q.Add , Times.Exactly(1));
            var results = await _mockRepository.Object.GetAll();
            results.Count().ShouldBe(3);
            

        }
        [Fact]
        public async Task IsInvalid_LeaveType_Added()
        {
            var handler = new CreateLeaveTypeCommandHandler(_mockRepository.Object, _mapper);
            var leavetype = new CreateLeaveTypeDto { Name = "Test Vacation" };
            var result = await handler.Handle(new CreateLeaveTypeCommand { LeaveTypeDto = leavetype }, CancellationToken.None);

            result.ShouldBeOfType<int>();

            //_mockRepository.Verify(q=>q.Add , Times.Exactly(1));
            var results = await _mockRepository.Object.GetAll();
            results.Count().ShouldBe(3);
        }
    }
}
