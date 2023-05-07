using System;

namespace TranslationManagement.Api.Services.Interfaces.Exceptions
{
    public class SystemException : Exception
    {
        public SystemException(string text) : base(text)
        {
            
        }
    }
}