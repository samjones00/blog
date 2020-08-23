using Blog.Core.Models;
using Blog.Core.Queries;
using MediatR;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Blog.Core.Tests
{
    public class GetArticlesQueryTests
    {
        [Fact]
        public async Task GetArticlesQueryHandler_GivenNoArguments_ShouldReturnArticles()
        {
            GetArticlesQuery query = new GetArticlesQuery();
            GetArticlesQueryHandler handler = new GetArticlesQueryHandler();

            var request = await handler.Handle(query, new System.Threading.CancellationToken());

            Assert.IsType<List<ArticleDto>>(request);
        }
    }
}
