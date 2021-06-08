using System;

namespace games.api.Models.Game
{
    /// <summary>
    /// ViewModel to output games in the system
    /// </summary>
    public class GameViewModelOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public double Price { get; set; }
    }
}