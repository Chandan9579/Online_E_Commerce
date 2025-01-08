using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UdemyModels.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(20)]
    
        public string Name { get; set; }
        [DisplayName("Display order")]
        
        [Range(1, 100)]
        public int DisplayOrder { get; set; }
    }
}   