using FluentValidation;
namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    class CreateLeaveTypeDtoValidator:AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidator()
        {
            Include(new ILeaveTypeDtoValidator());
            RuleFor(q => q.DefaultDays).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
