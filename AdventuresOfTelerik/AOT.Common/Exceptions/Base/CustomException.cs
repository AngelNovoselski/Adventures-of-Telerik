using System;

namespace AOT.Common.Exceptions.Base
{
    public abstract class CustomException : Exception
    {
        public CustomException(string msg) : base(msg)
        {

        } 
    }
}
