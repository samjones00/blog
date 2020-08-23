using Blog.Web.Models;
using System.Threading.Tasks;

namespace Blog.Web.Interfaces
{
    public interface IRestService
    {
        Task<ApiResponse<T>> GetAsync<T>(string url);
        Task<ApiResponse<T>> PostAsync<T>(string url, object data);
    }
}
