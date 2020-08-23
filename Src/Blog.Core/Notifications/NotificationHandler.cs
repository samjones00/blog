using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Core.Notifications
{
    public class NotificationHandler :
        INotificationHandler<CreateArticleNotification>,
        INotificationHandler<CreateUserNotification>
    {
        public Task Handle(CreateUserNotification notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"User {notification.Name} ({notification.Id}) created");
            return Task.CompletedTask;
        }

        public Task Handle(CreateArticleNotification notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Article {notification.Subject} ({notification.Id}) created");
            return Task.CompletedTask;
        }
    }
}