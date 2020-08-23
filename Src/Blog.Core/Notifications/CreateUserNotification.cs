using MediatR;
using System;

namespace Blog.Core.Notifications
{
    public class CreateUserNotification : INotification
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}