using System.ComponentModel.DataAnnotations;

namespace games.api.Models.Game
{
    /// <summary>
    /// ViewModel to input game in the system
    /// </summary>
    public class GameViewModelInput
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The game's name must have from 3 to 100 characters")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "The producer's name must have from 3 to 100 characters")]
        public string Producer { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "The price must be at least 1 reais and at most 1000 reais")]
        public double Price { get; set; }
    }
}