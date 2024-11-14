using FluentValidation;
using SchedsForums.Application.Commands.Forums.Common;

namespace SchedsForums.Application.Commands.Forums.FacultyForums.Create
{
    public class CreateFacultyForumCommandValidator : CreateForumBaseCommandValidator<CreateFacultyForumCommand, CreateFacultyForumCommandResponseDTO>
    {
        public CreateFacultyForumCommandValidator()
        {
            RuleFor(x => x.FacultyId).NotEmpty();
        }
    }
}
