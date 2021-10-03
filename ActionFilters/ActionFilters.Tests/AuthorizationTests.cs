using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ActionFilters.Web;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace ActionFilters.Tests
{
    public sealed class AuthorizationTests
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public AuthorizationTests()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [Theory]
        [InlineData("/catalog/search")]
        [InlineData("/catalog/itemdetails")]
        public async Task AllowsAnonymous(string path)
        {
            using var client = _factory.CreateClient();

            var response = await client.GetAsync(path);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/cart/get")]
        [InlineData("/cart/add/thing")]
        [InlineData("/inventory/level/some-item")]
        public async Task RequiresAuthentication(string path)
        {
            using var client = _factory.CreateClient();

            var response = await client.GetAsync(path);

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Theory]
        [InlineData("/cart/get")]
        [InlineData("/cart/add/thing")]
        [InlineData("/cart/clear")]
        [InlineData("/inventory/validatecart")]
        public async Task AllowsCustomer(string path)
        {
            using var client = _factory.CreateClient();

            client.DefaultRequestHeaders.Add("X-Custom-Auth", "something");
            var response = await client.GetAsync(path);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("/fulfillment/pick")]
        [InlineData("/inventory/restock/thing")]
        public async Task AllowsAdmin(string path)
        {
            using var client = _factory.CreateClient();

            client.DefaultRequestHeaders.Add("X-Custom-Auth", "Admin");
            var response = await client.GetAsync(path);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
