using Blog.Core.Models;

namespace Blog.Core.Interfaces.Factories
{
    public interface IArticleFactory
    {
        ArticleDto Create();
    }
}
