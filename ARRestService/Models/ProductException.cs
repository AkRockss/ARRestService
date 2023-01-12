using System;

namespace ARRestService.Models
{
    public class ProductException : Exception
    {

        public ProductException(string message) : base(message)
        {

        }
    }
}
