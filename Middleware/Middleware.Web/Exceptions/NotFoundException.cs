using System;

namespace Middleware.Web.Exceptions
{
    public sealed class NotFoundException : Exception
    {
        public NotFoundException() : base("The requested resource was not found")
        {
        }
    }
}