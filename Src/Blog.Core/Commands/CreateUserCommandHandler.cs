using Blog.Core.Interfaces;
using Blog.Core.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Core.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        public IMediator Mediator { get; set; }
        public IUserFactory UserFactory { get; }

        public CreateUserCommandHandler(IMediator mediator, IUserFactory userFactory)
        {
            Mediator = mediator;
            UserFactory = userFactory;
        }

        public Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = UserFactory.Create();
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;

            Mediator.Publish(new CreateUserNotification
            {
                Id = user.Id,
                Name = request.FirstName
            });

            return Task.FromResult(true);
        }
    }
}