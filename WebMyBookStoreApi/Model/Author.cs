using System.ComponentModel.DataAnnotations;

namespace WebMyBookStoreApi.Model
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
