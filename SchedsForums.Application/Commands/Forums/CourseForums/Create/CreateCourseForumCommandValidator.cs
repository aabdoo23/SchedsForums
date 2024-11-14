using FluentValidation;
using SchedsForums.Application.Commands.Forums.Common;

namespace SchedsForums.Application.Commands.Forums.CourseForums.Create
{
    public class CreateCourseForumCommandValidator : CreateForumBaseCommandValidator<CreateCourseForumCommand, CreateCourseForumCommandResponseDTO>
    {
        public CreateCourseForumCommandValidator()
        {
            RuleFor(x => x.CourseId).NotEmpty();
        }
    }
}
