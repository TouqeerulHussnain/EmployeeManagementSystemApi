using EmployeeManagementSystemApi.Core.Domain.Model;
using FluentValidation;
using System.Text.RegularExpressions;

namespace EmployeeManagementSystemApi.Core.Domain.Validator
{
    public class EmailValidator:AbstractValidator<Employee>
    {

        public EmailValidator()
        {
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Name).MaximumLength(50);
            RuleFor(u => u.Name).MinimumLength(2);
        }
    }
}
