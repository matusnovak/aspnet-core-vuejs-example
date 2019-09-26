using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;
using Example.Api.Models;

namespace Example.IntegrationTests.Controllers
{
    public class TodoControllerTests 
        : IClassFixture<WebApplicationFactory<Example.Startup>>
    {
        private readonly HttpClient client;

        public TodoControllerTests(WebApplicationFactory<Example.Startup> factory)
        {
            this.client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateAndGetTask()
        {
            // Create a new task
            Todo item = new Todo() { Title = "Hello", Body = "Lorem Ipsum Donor" };
            var response = await client.PostAsync("/api/todo", AsJson(item));

            // Assert
            response.EnsureSuccessStatusCode();
            Todo created = await FromJson<Todo>(response);
            Assert.True(created.Id > 0);
            Assert.Equal(item.Title, created.Title);
            Assert.Equal(item.Body, created.Body);

            // Fetch the created task
            response = await client.GetAsync("/api/todo/" + created.Id);
            response.EnsureSuccessStatusCode();

            // Assert
            item = await FromJson<Todo>(response);
            Assert.Equal(item.Id, created.Id);
            Assert.Equal(item.Title, created.Title);
            Assert.Equal(item.Body, created.Body);
        }

        private static StringContent AsJson<T>(T entity)
        {
            return new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, MediaTypeNames.Application.Json);
        }

        private static async Task<T> FromJson<T>(HttpResponseMessage response)
        {
            string body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<T>(body);
        }
    }
}
