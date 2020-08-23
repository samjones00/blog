using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Blog.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages
{
    public class CreateArticleModel : PageModel
    {
        [BindProperty]
        [Required]
        public string Subject { get; set; }

        [BindProperty]
        [Required]
        public string Body { get; set; }

        private readonly IRestService _restService;

        public CreateArticleModel()
        {
            _restService = new RestService();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await _restService.PostAsync<bool>("https://blog.api/articles", new { Subject, Body });

            if(!response.Success)
            {
                return Page();
            }

            return RedirectToPage("./Articles");
        }
    }
}