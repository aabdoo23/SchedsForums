using FluentValidation;
using SchedsForums.Application.Interfaces.Repositories;

namespace SchedsForums.Application.Commands.Majors.Create
{
    public class CreateMajorValidator : AbstractValidator<CreateMajorCommand>
    {
        private readonly IFacultyRepository _facultyRepository;

        public CreateMajorValidator(IFacultyRepository facultyRepository)
        {
            Console.WriteLine("Validating Create Major");
            _facultyRepository = facultyRepository;

            RuleFor(x => x.ShortName)
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.FacultyId)
                .NotEmpty()
                .MustAsync(FacultyExistsAsync)
                .WithMessage("The specified FacultyId does not exist.");
        }

        private async Task<bool> FacultyExistsAsync(string facultyId, CancellationToken cancellationToken)
        {
            return await _facultyRepository.ExistsAsync(facultyId);
        }
    }
}
