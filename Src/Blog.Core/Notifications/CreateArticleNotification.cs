using MediatR;
using System;

namespace Blog.Core.Notifications
{
    public class CreateArticleNotification : INotification
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
    }
}