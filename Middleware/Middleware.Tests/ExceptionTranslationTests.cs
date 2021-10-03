using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Middleware.Web;
using Xunit;

namespace Middleware.Tests
{
    public sealed class ExceptionTranslationTests : IDisposable
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ExceptionTranslationTests()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [Fact]
        public async Task NoTranslationOnOk()
        {
            using var client = _factory.CreateClient();

            var response = await client.GetAsync("/ok");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task NotFoundTranslatesTo404()
        {
            using var client = _factory.CreateClient();

            var response = await client.GetAsync("/notfound");

            response.StatusCode.Should().Be((HttpStatusCode)404);
        }

        [Fact]
        public async Task ForbiddenTranslatesTo403()
        {
            using var client = _factory.CreateClient();

            var response = await client.GetAsync("/forbidden");

            response.StatusCode.Should().Be((HttpStatusCode)403);
        }

        [Fact]
        public async Task ConcurrencyIssueTranslatesTo409()
        {
            using var client = _factory.CreateClient();

            var response = await client.GetAsync("/concurrencyissue");

            response.StatusCode.Should().Be((HttpStatusCode)409);
        }

        public void Dispose()
        {
            _factory?.Dispose();
        }
    }
}
