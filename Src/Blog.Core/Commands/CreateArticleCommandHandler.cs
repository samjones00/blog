using Blog.Core.Interfaces.Factories;
using Blog.Core.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Core.Commands
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, bool>
    {
        public IMediator Mediator { get; set; }
        public IArticleFactory ArticleFactory { get; }

        public CreateArticleCommandHandler(IMediator mediator, IArticleFactory articleFactory)
        {
            Mediator = mediator;
            ArticleFactory = articleFactory;
        }

        public Task<bool> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = ArticleFactory.Create();
            article.Subject = request.Subject;
            article.Body = request.Body;
            article.UserId = request.UserId;

            Mediator.Publish(new CreateArticleNotification
            {
                Id = article.Id,
                Subject = article.Subject
            });

            return Task.FromResult(true);
        }
    }
}