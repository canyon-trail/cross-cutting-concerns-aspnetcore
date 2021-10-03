using System.Linq;
using System.Threading.Tasks;
using ControllerBaseClass.Web;
using ControllerBaseClass.Web.Controllers.Fruits;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace ControllerBaseClass.Tests
{
    public sealed class FruitSaladHeaderTests
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private const string FruitSaladHeader = "X-Fruit-Salad-Compatible";

        public FruitSaladHeaderTests()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [Fact]
        public async Task AppleHasHeader()
        {
            using var client = _factory.CreateClient();

            var response = await client.GetAsync("/apple");

            response.Headers.Should().ContainKey(FruitSaladHeader);
        }

        [Fact]
        public async Task EggDoesNotHaveHeader()
        {
            using var client = _factory.CreateClient();

            var response = await client.GetAsync("/egg");

            response.Headers.Should().NotContainKey(FruitSaladHeader);
        }

        [Fact]
        public async Task CeleryHasHeader()
        {
            using var client = _factory.CreateClient();

            var response = await client.GetAsync("/celery");

            response.Headers.Should().ContainKey(FruitSaladHeader);
        }

        [Fact]
        public async Task WalnutHasHeader()
        {
            using var client = _factory.CreateClient();

            var response = await client.GetAsync("/walnut");

            response.Headers.Should().ContainKey(FruitSaladHeader);
        }

        [Fact]
        public void AllControllersInFruitNamespaceUseBaseClass()
        {
            var baseClass = typeof(FruitControllerBase);

            var controllersInFruitNamespace = baseClass.Assembly.GetTypes()
                .Where(x => x.IsClass)
                .Where(x => !x.IsAbstract)
                .Where(x => x.Namespace == baseClass.Namespace)
                .Where(x => typeof(ControllerBase).IsAssignableFrom(x))
                .ToArray();

            var nonCompliantClasses = controllersInFruitNamespace
                .Where(x => !baseClass.IsAssignableFrom(x));

            nonCompliantClasses.Should().BeEmpty();
        }
    }
}
