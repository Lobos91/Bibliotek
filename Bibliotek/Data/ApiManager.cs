using Bibliotek.Models;
using Newtonsoft.Json;

namespace Bibliotek.Data
{
    public class ApiManager
    {
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
        //----------- PRODUCTS ----------//  
        public async Task<List<ProductModel>> GetProducts()
        {
            using (HttpClient client = new())
            {
                var response = await client.GetFromJsonAsync<List<ProductModel>>(baseURL + "Product");
                return response;
            }

            return null;
        }
        //---------------------------------------------------------------------------------//
        public async Task UpdateProduct(ProductModel product)
        {
            using HttpClient client = new();
            HttpResponseMessage response = await client.PutAsJsonAsync(baseURL + "Product/" + product.Id , product);

            response.EnsureSuccessStatusCode();
        
        }
        //---------------------------------------------------------------------------------//
        public async Task ResetProducts(List<ProductModel> Products)
        {
            using (HttpClient client = new())
            {
                var response = await client.PutAsJsonAsync<List<ProductModel>>(baseURL + "Product", Products);
            }
        }

        ////////////////////////////////
        //----------- Events ----------//  
        public async Task<List<KalenderModel>> GetEvents()
        {
            using (HttpClient client = new())
            {
                var response = await client.GetFromJsonAsync<List<KalenderModel>>(baseURL + "Kalender");
                return response;
            }

            return null;
        }
        //---------------------------------------------------------------------------------//
        public async Task UpdateEvent(KalenderModel EventToUpdate)
        {
            using (HttpClient client = new())
            {
                var response = await client.PutAsJsonAsync(baseURL + "Kalender/" + EventToUpdate.Id , EventToUpdate);
                response.EnsureSuccessStatusCode();
            }
        }
        //---------------------------------------------------------------------------------//
        public async Task<KalenderModel> CreateEvent(KalenderModel NewEvent)
        {
            using (HttpClient client = new())
            {
                using (var response = await client.PostAsJsonAsync<KalenderModel>(baseURL + "Kalender", NewEvent))
                {
                    var strResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<KalenderModel>(strResponse);
                }
            }
            return null;
        }
        //---------------------------------------------------------------------------------//
        public async Task DeleteEvent(int id)
        {
            using (HttpClient client = new())
            {
                var respond = await client.DeleteAsync(baseURL + "Kalender/" + id);
            }
        }
    }
}
