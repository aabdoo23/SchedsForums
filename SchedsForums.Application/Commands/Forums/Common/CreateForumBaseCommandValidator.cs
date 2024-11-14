using FluentValidation;

namespace SchedsForums.Application.Commands.Forums.Common
{
    public class CreateForumBaseCommandValidator<TCommand, TResponse> : AbstractValidator<TCommand>
                where TCommand : CreateForumBaseCommand<TResponse>
                where TResponse : CreateForumBaseResponseDTO
    {
        public CreateForumBaseCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        }
    }
}
