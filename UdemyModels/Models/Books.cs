using System.ComponentModel.DataAnnotations;

namespace UdemyModels.Models
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        public bool Taken { get; set; }
    }
}   