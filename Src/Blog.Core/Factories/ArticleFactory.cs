using Blog.Core.Interfaces.Factories;
using Blog.Core.Models;
using Blog.Core.Providers;

namespace Blog.Core.Factories
{
    public class ArticleFactory : IArticleFactory
    {
        public IDateTimeProvider DateTimeProvider { get; }

        public ArticleFactory(IDateTimeProvider dateTimeProvider)
        {
            DateTimeProvider = dateTimeProvider;
        }

        public ArticleDto Create()
        {
            return new ArticleDto()
            {
                DateCreated = DateTimeProvider.UtcNow
            };
        }
    }
}