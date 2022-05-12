using Bibliotek.Models;
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
    }
}
