using System;

namespace Middleware.Web.Exceptions
{
    public sealed class ForbiddenException : Exception
    {
        public ForbiddenException() : base("You are not authorized to perform this action")
        {
        }
    }
}