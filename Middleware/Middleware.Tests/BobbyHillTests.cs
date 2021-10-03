using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Middleware.Web;
using Xunit;

namespace Middleware.Tests
{
    public sealed class BobbyHillTests
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public BobbyHillTests()
        {
            _factory = new WebApplicationFactory<Startup>();
        }
        
        [Fact]
        public async Task BobbyHillAssertsHimself()
        {
            using var client = _factory.CreateClient();

            var response = await client.GetAsync("/bobbyhill");

            response.StatusCode.Should().Be((HttpStatusCode)418);

            var responseText = await response.Content.ReadAsStringAsync();

            responseText.Should().Contain("That's my purse!");
            responseText.Should().Contain("I don't know you!");
        }
    }
}