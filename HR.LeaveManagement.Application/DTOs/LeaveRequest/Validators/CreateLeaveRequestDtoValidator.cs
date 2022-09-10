using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    internal class CreateLeaveRequestDtoValidator:AbstractValidator<LeaveRequestDto>
    {
        public CreateLeaveRequestDtoValidator()
        {
            RuleFor(q => q.StartDate)
                .LessThan(q => q.EndDate)
                .WithMessage("{PropertyValue} should be before {ValueComparison}");
        }
    }
}
