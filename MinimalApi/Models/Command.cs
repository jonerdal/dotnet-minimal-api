using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Models
{
    public class Command {
        public Guid Id { get; set; }

        [Required]
        public string? HowTo { get; set; }
        
        [Required]
        [MaxLength(5)]
        public string? Platform { get; set; }
        
        [Required]
        public string? CommandLine { get; set; }
    }
}