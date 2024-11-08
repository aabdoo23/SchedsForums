using FluentValidation;
using SchedsForums.Application.Commands.Forums.Common;

namespace SchedsForums.Application.Commands.Forums.MajorForums.Create
{
    public class CreateMajorForumCommandValidator : CreateForumBaseCommandValidator<CreateMajorForumCommand, CreateMajorForumCommandResponseDTO>
    {
        public CreateMajorForumCommandValidator()
        {
            RuleFor(x => x.MajorId).NotEmpty();
        }
    }
}
