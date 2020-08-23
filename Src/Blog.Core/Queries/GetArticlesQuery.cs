using Blog.Core.Models;
using MediatR;
using System.Collections.Generic;

namespace Blog.Core.Queries
{
    public class GetArticlesQuery : IRequest<List<ArticleDto>>
    {
    }
}
