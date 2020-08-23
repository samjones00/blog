using Blog.Core.Interfaces;
using Blog.Core.Models;
using Blog.Core.Providers;

namespace Blog.Core.Factories
{
    public class UserFactory : IUserFactory
    {
        public IDateTimeProvider DateTimeProvider { get; }

        public UserFactory(IDateTimeProvider dateTimeProvider)
        {
            DateTimeProvider = dateTimeProvider;
        }

        public UserDto Create()
        {
            var result = new UserDto()
            {
                DateCreated = DateTimeProvider.UtcNow
            };

            return result;
        }
    }
}