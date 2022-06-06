﻿using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

//how to run: run the program in visual studio
//in terminal navigate to project root/biblitekTests
//run the command: dotnet test


//note added a id at <table class=table>
//https://docs.abp.io/en/abp/latest/UI/AspNetCore/Testing inspiration
// ladda ner xunit och htmlAglilitypack nuget paket

namespace BibliotekTests
{
    public class UnitTestLogin
    {
        [Fact]
        public async Task LoginUserName()
        {
            var baseAdress = new Uri("https://localhost:7119");
            using var client = new HttpClient() { BaseAddress = baseAdress };

            var message = new HttpRequestMessage(HttpMethod.Get, "/login");
            var response = await client.SendAsync(message);

            var content = await response.Content.ReadAsStringAsync();

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(content);

            var elem = htmlDoc.GetElementbyId("username");
            Assert.NotNull(elem);
        }

        [Fact]
        public async Task LoginPassword()
        {
            var baseAdress = new Uri("https://localhost:7119");
            using var client = new HttpClient() { BaseAddress = baseAdress };

            var message = new HttpRequestMessage(HttpMethod.Get, "/login");
            var response = await client.SendAsync(message);

            var content = await response.Content.ReadAsStringAsync();

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(content);

            var elem = htmlDoc.GetElementbyId("password");
            Assert.NotNull(elem);
        }
    }
}
