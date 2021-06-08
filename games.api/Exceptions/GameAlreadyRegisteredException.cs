using System;

namespace games.api.Exceptions
{
    public class GameAlreadyRegisteredException : Exception
    {
        public GameAlreadyRegisteredException() : base("This Game is Already Registered")
        {
            
        }
    }
}