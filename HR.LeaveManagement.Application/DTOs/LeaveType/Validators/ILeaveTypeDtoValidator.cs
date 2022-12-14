using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    class ILeaveTypeDtoValidator:AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator()
        {
                    RuleFor(q => q.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");


            RuleFor(q => q.DefaultDays)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1")
                .LessThan(100).WithMessage("{PropertyName} must be less than 100");
        }
    }
}
