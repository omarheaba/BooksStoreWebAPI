using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksWebAPI.Models
{
    public class BookModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [MaxLength(100)]
        public string? BookTitle { get; set; }


        public int AuthorId { get; set; }
        public virtual AuthorModel? Author { get; set; }
    }
}
