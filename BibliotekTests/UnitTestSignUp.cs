using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

//how to run: run the program in visual studio
//in terminal navigate to project root/biblitekTests. To find the correct file path hover over the file name located on the "top" of the screen.
//example of how I would use the navigation command to find the correct file location of the project: "cd source/repos/Biblioteket/Bibliotek/BibliotekTests"
//run the command: "dotnet test"


//note added a id at <table class=table>
//https://docs.abp.io/en/abp/latest/UI/AspNetCore/Testing inspiration
// ladda ner xunit och htmlAglilitypack nuget paket
namespace BibliotekTests
{
    public class UnitTestSignUp
    {
        [Fact]
        public async Task UsernameTest()
        {
            var baseAdress = new Uri("https://localhost:7119");
            using var client = new HttpClient() { BaseAddress = baseAdress };

            var message = new HttpRequestMessage(HttpMethod.Get, "/SignUp");
            var response = await client.SendAsync(message);

            var content = await response.Content.ReadAsStringAsync();

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(content);

            var elem = htmlDoc.GetElementbyId("username");
            Assert.NotNull(elem);
        }

        [Fact]
        public async Task EmailTest()
        {
            var baseAdress = new Uri("https://localhost:7119");
            using var client = new HttpClient() { BaseAddress = baseAdress };

            var message = new HttpRequestMessage(HttpMethod.Get, "/SignUp");
            var response = await client.SendAsync(message);

            var content = await response.Content.ReadAsStringAsync();

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(content);

            var elem = htmlDoc.GetElementbyId("email");
            Assert.NotNull(elem);
        }

        [Fact]
        public async Task PasswordTest()
        {
            var baseAdress = new Uri("https://localhost:7119");
            using var client = new HttpClient() { BaseAddress = baseAdress };

            var message = new HttpRequestMessage(HttpMethod.Get, "/SignUp");
            var response = await client.SendAsync(message);

            var content = await response.Content.ReadAsStringAsync();

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(content);

            var elem = htmlDoc.GetElementbyId("password");
            Assert.NotNull(elem);
        }

        [Fact]
        public async Task RePasswordTest()
        {
            var baseAdress = new Uri("https://localhost:7119");
            using var client = new HttpClient() { BaseAddress = baseAdress };

            var message = new HttpRequestMessage(HttpMethod.Get, "/SignUp");
            var response = await client.SendAsync(message);

            var content = await response.Content.ReadAsStringAsync();

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(content);

            var elem = htmlDoc.GetElementbyId("re-password");
            Assert.NotNull(elem);
        }
    }
}
