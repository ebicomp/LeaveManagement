using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    class CreateLeaveRequestCommand:IRequest<BaseCommandResponse>
    {
        public LeaveRequestDto LeaveRequestDto { get; set; }
    }
}
