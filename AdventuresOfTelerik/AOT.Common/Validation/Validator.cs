using System;

namespace AOT.Common.Validation
{
    public class Validator : IValidator
    {
        public void ValidateObjectForNull(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentException($"Invalid {nameof(obj)}");
            }
        }
    }
}
