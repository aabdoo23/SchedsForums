using MediatR;

namespace SchedsForums.Application.Commands.Common.User
{
    public abstract class UserSignUpCommand<TResponse> : IRequest<TResponse>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}