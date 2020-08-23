using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Web.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Blog.Web.Pages
{
    public class ArticlesModel : PageModel
    {
        public IEnumerable<ArticleModel> Articles;
        private readonly ILogger<IndexModel> _logger;
        private readonly IRestService _restService;

        public ArticlesModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _restService = new RestService();
        }

        public async Task OnGet()
        {
            var articleResponse = await _restService.GetAsync<IEnumerable<ArticleModel>>("https://blog.api/articles");

            Articles = articleResponse.Data;
        }
    }
}