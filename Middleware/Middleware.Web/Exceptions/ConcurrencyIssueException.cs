using System;

namespace Middleware.Web.Exceptions
{
    public sealed class ConcurrencyIssueException : Exception
    {
        public ConcurrencyIssueException() : base("Someone else has edited the resource you are attempting to access")
        {
        }
    }
}