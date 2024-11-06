using FluentValidation;

namespace SchedsForums.Application.Commands.Admins.CreateCourse
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator() {
            RuleFor(x => x.CourseCode)
                .NotEmpty().WithMessage("Course code is required.")
                .MaximumLength(20).WithMessage("Course code must not exceed 20 characters.");
            RuleFor(x => x.CourseName)
                .NotEmpty().WithMessage("Course name is required.");
        }
    }
}
