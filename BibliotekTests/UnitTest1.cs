using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

//how to run: run the program in visual studio
//in terminal navigate to project root/biblitekTests
//run the command: dotnet test


//note added a id at <table class=table>
//https://docs.abp.io/en/abp/latest/UI/AspNetCore/Testing inspiration
namespace BibliotekTests
{ // ladda ner xunit och htmlAglilitypack nuget paket
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var baseAdress = new Uri("https://localhost:7119");
            using var client = new HttpClient() { BaseAddress = baseAdress };

            var message = new HttpRequestMessage(HttpMethod.Get, "/search");
            var response = await client.SendAsync(message);

            var content = await response.Content.ReadAsStringAsync();
            
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(content);

            var tableElem = htmlDoc.GetElementbyId("tableId");
            Assert.NotNull(tableElem);

            var trNodes = tableElem.SelectNodes("//tbody/tr");
            Console.WriteLine(trNodes);
            
        }
    }
}