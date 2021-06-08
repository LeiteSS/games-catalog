using System;

namespace games.api.Exceptions
{
    public class GameNotFoundException : Exception
    {
        public GameNotFoundException() :base("Game Not Found")
        {
            
        }
    }
}