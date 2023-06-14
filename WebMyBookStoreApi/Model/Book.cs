using System.ComponentModel.DataAnnotations;

namespace WebMyBookStoreApi.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public virtual Author Author { get; set; }
    }
}
