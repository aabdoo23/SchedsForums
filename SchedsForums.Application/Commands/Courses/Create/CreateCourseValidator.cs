using FluentValidation;
using SchedsForums.Application.Interfaces.Repositories;

namespace SchedsForums.Application.Commands.Courses.Create
{
    public class CreateCourseValidator : AbstractValidator<CreateCourseCommand>
    {
        private readonly ICourseRepository _courseRepository;

        public CreateCourseValidator(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));

            RuleFor(x => x.CourseCode)
                .NotEmpty()
                .MaximumLength(10)
                .MustAsync(IsCourseCodeUnique).WithMessage("A course already exists with the same course code.");
            RuleFor(x => x.CourseName)
                .NotEmpty()
                .MaximumLength(100);
        }

        public async Task<bool> IsCourseCodeUnique(string courseCode, CancellationToken cancellationToken)
        {
            return await _courseRepository.IsCourseCodeUnique(courseCode);
        }
    }
}
