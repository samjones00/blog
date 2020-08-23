using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Entity
{
    [Table("Article")]
    public class ArticleEntity
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
