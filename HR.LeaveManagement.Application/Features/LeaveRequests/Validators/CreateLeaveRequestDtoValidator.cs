using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Validators
{
    public class CreateLeaveRequestDtoValidator:AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            RuleFor(q => q.StartDate)
                .LessThan(q => q.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");


            RuleFor(q => q.EndDate)
                .GreaterThan(q => q.EndDate).WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(q => q.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExist = await _leaveTypeRepository.Exists(id);
                    return !leaveTypeExist;
                });

        }
    }
}
