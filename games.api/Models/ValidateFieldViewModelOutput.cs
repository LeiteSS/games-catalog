using System.Collections.Generic;

namespace games.api.Models
{
    /// <summary>
    /// Validate if the fields are filled
    /// </summary>
    public class ValidateFieldViewModelOutput
    {
        public IEnumerable<string> Error { get; private set; }

        public ValidateFieldViewModelOutput(IEnumerable<string> error)
        {
            Error = error;
        }
    }
}