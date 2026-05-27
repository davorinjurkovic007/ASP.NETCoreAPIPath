using FluentValidation;
using FreeBlling.Web.Models;

namespace FreeBlling.Web.Validators
{
    public class TimeBillModelValidator : AbstractValidator<TimeBillModel>
    {
        public TimeBillModelValidator()
        {
            RuleFor(m => m.CustomerId).NotEmpty();
            RuleFor(m => m.EmployeeId).NotEmpty();

            RuleFor(m => m.Rate)
                .InclusiveBetween(50.0, 300.0);

            RuleFor(m => m.HoursWorked)
                .InclusiveBetween(.1, 12.0);

            RuleFor(m => m.Work)
                .NotEmpty()
                .MinimumLength(15);
        }
    }
}
