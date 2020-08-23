using Blog.Core.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Core.Queries
{
    public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, List<ArticleDto>>
    {
        public Task<List<ArticleDto>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<ArticleDto>();

            result.Add(new ArticleDto
            {
                DateCreated = new System.DateTime(2020,01,01,01,02,03,04),
                Subject="Article One",
                Body = "Body here"
            });

            result.Add(new ArticleDto
            {
                DateCreated = new System.DateTime(2020,01,02,03,04,05,06),
                Subject = "Article Two",
                Body = "Body here"
            });

            return Task.FromResult(result);
        }
    }
}