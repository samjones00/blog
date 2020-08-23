using MediatR;

namespace Blog.Core.Commands
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string FirstName { get; }
        public string LastName { get; }

        public CreateUserCommand(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}