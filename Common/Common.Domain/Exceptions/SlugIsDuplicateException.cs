using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean_arch.Domain.Shared.Exceptions;

namespace Common.Domain.Exceptions
{
    public class SlugIsDuplicateException : BaseDomainException
    {
        public SlugIsDuplicateException() : base("Slug is duplicate")
        {
            
        }

        public SlugIsDuplicateException(string message):base(message)
        {
            
        }
    }
}