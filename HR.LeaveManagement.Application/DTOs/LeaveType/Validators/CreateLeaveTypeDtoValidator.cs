using FluentValidation;
namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    class CreateLeaveTypeDtoValidator:AbstractValidator<LeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidator()
        {
            Include(new ILeaveTypeDtoValidator());
            RuleFor(q => q.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
