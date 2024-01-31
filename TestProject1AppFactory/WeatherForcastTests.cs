using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace TestProject1AppFactory
{
    public class WeatherForecastTests : IClassFixture<WebApplicationFactory<WebApplicationFactoryAPI.WeatherForecast>>
    {
       readonly HttpClient _client;

        public WeatherForecastTests(WebApplicationFactory<WebApplicationFactoryAPI.WeatherForecast> application)
        {
            _client = application.CreateClient();
        }

        [Fact]
        public async Task GET_weatherforcast()
        {
            //they wanted it to beWebApplicaitonFactory<Api.Startup()>
            //I put the name of my api project, and I didn't have a startup class so we added it
            //in the program.cs class (but I called it program)
            //turns out, putting that in program.cs doesn't actually do anything for us, nor does autopilot recognize it.

            //instead autopilot wanted me to mention the weather forecast class. Idk why, but it worked
            await using var application = new WebApplicationFactory<WebApplicationFactoryAPI.WeatherForecast>();
            using var client = application.CreateClient();

            var response = await client.GetAsync("/weatherforecast");
            //response.StatusCode.Should().Be(HttpStatusCode.OK); //this line from the tutorial didn't work
            response.StatusCode.Equals(HttpStatusCode.OK);
        }
    }
}