﻿using Bibliotek.Models;
using Newtonsoft.Json;

namespace Bibliotek.Data
{
    public class ApiManager
    {

       // private static readonly HttpClient client = new HttpClient();

        private string baseURL = "https://localhost:7119/api/";

        ///////////////////////////////
        //----------- USER ----------//  
        public async Task<List<UserModel>> GetUsers()
        {
            using (HttpClient client = new())
            {
                var response = await client.GetFromJsonAsync<List<UserModel>>(baseURL + "User");
                return response;
            }

            return null;
        }
        public async Task<UserModel> GetUser(int id)
        {
            using (HttpClient client = new())
            {
                var response = await client.GetFromJsonAsync<UserModel>(baseURL + "User/" + id);
                return response;
            }

            return null;
        }
        //---------------------------------------------------------------------------------//
        public async Task<UserModel> PostUser(UserModel User)
        {
            using (HttpClient client = new())
            {
                using (var response = await client.PostAsJsonAsync<UserModel>(baseURL + "User", User))
                {
                    var strResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<UserModel>(strResponse);
                }
            }

            return null;
        }

        ////////////////////////////////
        //----------- Books ----------//  
        public async Task<List<BookModel>> GetBooks()
        {
            using (HttpClient client = new())
            {
                var response = await client.GetFromJsonAsync<List<BookModel>>(baseURL + "Book");
                return response;
            }

            return null;
        }

        ////////////////////////////////
        //----------- Movies ----------//  
        public async Task<List<MovieModel>> GetMovies()
        {
            using (HttpClient client = new())
            {
                var response = await client.GetFromJsonAsync<List<MovieModel>>(baseURL + "Movie");
                return response;
            }

            return null;
        }
        ////////////////////////////////
        //----------- Ebooks ----------//  
        public async Task<List<EBookModel>> GetEbooks()
        {
            using (HttpClient client = new())
            {
                var response = await client.GetFromJsonAsync<List<EBookModel>>(baseURL + "Ebook");
                return response;
            }

            return null;
        }

        ////////////////////////////////
        //----------- ALL products ----------//  
        public async Task<List<ProductModel>> GetProducts()
        {
            using (HttpClient client = new())
            {
                var response = await client.GetFromJsonAsync<List<ProductModel>>(baseURL + "Product");
                return response;
            }

            return null;
        }

        ////////////////////////////////
        //----------- Releases ----------//  
        public async Task<List<ReleaseModel>> GetReleases()
        {
            using (HttpClient client = new())
            {
                var response = await client.GetFromJsonAsync<List<ReleaseModel>>(baseURL + "Release");
                return response;
            }

            return null;
        }
    }
}
