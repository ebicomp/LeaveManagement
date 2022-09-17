using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HR.LeaveManagement.Application.Profiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.LeaveTypes.Queries
{
    public class GetLeaveTypeListRequestHandlerTest
    {
        private readonly Mock<ILeaveTypeRepository> _mockRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeListRequestHandlerTest()
        {
            _mockRepository = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
        }
        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var hanler = new GetLeaveTypeListRequestHandler(_mockRepository.Object, _mapper);
            var result = await hanler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);
            result.ShouldBeOfType<List<LeaveTypeDto>>();
            result.Count.ShouldBe(2);
        }
    }
}
