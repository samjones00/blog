using Blog.Core.Commands;
using Blog.Core.Factories;
using Blog.Core.Providers;
using MediatR;
using NSubstitute;
using System;
using Xunit;
using System.Threading.Tasks;

namespace Blog.Core.Tests
{
    public class CreateUserCommandTests
    {
        [Fact]
        public async Task CreateUserCommandHandler_GivenValidData_ShouldReturnTrue()
        {
            var dateTimeProvider = Substitute.For<IDateTimeProvider>();
            var mediator = Substitute.For<IMediator>();

            dateTimeProvider.UtcNow.Returns(new DateTime(2000, 01, 01));

            var userFactory = new UserFactory(dateTimeProvider);

            CreateUserCommand command = new CreateUserCommand("Tom", "Jerry");
            CreateUserCommandHandler handler = new CreateUserCommandHandler(mediator, userFactory);

            var result = await handler.Handle(command, new System.Threading.CancellationToken());

            Assert.True(result);
        }
    }
}