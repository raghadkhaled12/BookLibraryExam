using System.ComponentModel.DataAnnotations;

namespace BookLibraryExam.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Book Title is required.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author Name is required.")]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "ISBN is required.")]
        [RegularExpression(@"^\d{3}-\d{10}$", ErrorMessage = "Invalid ISBN format, must be in the format 978-0123456789.")]
        public string ISBN { get; set; } = string.Empty;

        [Range(1800, 2025, ErrorMessage = "Publication Year must be between 1800 and 2025.")]
        public int PublicationYear { get; set; }
    }
}
