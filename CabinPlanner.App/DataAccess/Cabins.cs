
using CabinPlanner.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CabinPlanner.App.DataAccess
{
    public class Cabins
    {
        readonly HttpClient _httpClient = new HttpClient();
        public static readonly Uri cabinsBaseUri = new Uri("http://localhost:52981/api/cabins");

        public async Task<Cabin[]> GetCabinsAsync()
        {
            HttpResponseMessage result = await _httpClient.GetAsync(cabinsBaseUri);
            string json = await result.Content.ReadAsStringAsync();
            Cabin[] cabins = JsonConvert.DeserializeObject<Cabin[]>(json);

            return cabins;
        }

        internal async Task<Cabin> GetCabinAsync(Cabin cabin)
        {
            HttpResponseMessage result = await _httpClient.GetAsync(new Uri(cabinsBaseUri, "cabins/" + cabin.CabinId.ToString()));
            string json = await result.Content.ReadAsStringAsync();
            Cabin dbCabin = JsonConvert.DeserializeObject<Cabin>(json);
            return dbCabin;
        }

        internal async Task<Person[]> GetCabinUsersAsync(Cabin cabin)
        {
            HttpResponseMessage result = await _httpClient.GetAsync(new Uri(cabinsBaseUri, "cabins/" + cabin.CabinId.ToString() + "/people"));
            string json = await result.Content.ReadAsStringAsync();
            Person[] cabinPeople = JsonConvert.DeserializeObject<Person[]>(json);
            return cabinPeople;
        }

        internal async Task<Cabin> GetCabinAsync(int cabinId)
        {
            HttpResponseMessage result = await _httpClient.GetAsync(new Uri(cabinsBaseUri, "cabins/" + cabinId.ToString()));
            string json = await result.Content.ReadAsStringAsync();
            Cabin dbCabin = JsonConvert.DeserializeObject<Cabin>(json);

            return dbCabin;
        }


        internal async Task<bool> AddCabinAsync(Cabin cabin)
        {
            //string json = JsonConvert.SerializeObject(cabin);
            //HttpResponseMessage result = await _httpClient.PostAsync(cabinsBaseUri, new StringContent(json, Encoding.UTF8, "application/json"));

            var json = JsonConvert.SerializeObject(cabin);

            var result = await _httpClient.PostAsync(cabinsBaseUri, new StringContent(json, Encoding.UTF8, "application/json"));

            if (result.IsSuccessStatusCode)
            {
                json = await result.Content.ReadAsStringAsync();
                var returnedCabin = JsonConvert.DeserializeObject<Cabin>(json);
                cabin.CabinId = returnedCabin.CabinId;

                return true;
            }
            else
                return false;
        }

        internal async Task<bool> PutCabinAsync(Cabin cabin)
        {
            string json = JsonConvert.SerializeObject(cabin);
            HttpResponseMessage result = await _httpClient.PutAsync(new Uri(cabinsBaseUri, "cabins/" + cabin.CabinId.ToString()), new StringContent(json, Encoding.UTF8, "application/json"));
            return result.IsSuccessStatusCode;
        }

        internal async Task<bool> PutCabinPersonAsync(Cabin cabin , Person person)
        {
            string json = JsonConvert.SerializeObject(cabin);
            HttpResponseMessage result = await _httpClient.PutAsync(new Uri(cabinsBaseUri, "cabins/" + cabin.CabinId.ToString()) + "/people/" + person.PersonId.ToString(), new StringContent(json, Encoding.UTF8, "application/json"));
            return result.IsSuccessStatusCode;
        }

        internal async Task<bool> PutCabinOwnerAsync(Cabin cabin, Person person)
        {
            string json = JsonConvert.SerializeObject(cabin);
            HttpResponseMessage result = await _httpClient.PutAsync(new Uri(cabinsBaseUri, "cabins/" + cabin.CabinId.ToString()) + "/owner/" + person.PersonId.ToString(), new StringContent(json, Encoding.UTF8, "application/json"));
            return result.IsSuccessStatusCode;
        }

        internal async Task<bool> DeleteCabinAsync(Cabin cabin)
        {
            HttpResponseMessage result = await _httpClient.DeleteAsync(new Uri(cabinsBaseUri, "cabins/" + cabin.CabinId.ToString()));
            return result.IsSuccessStatusCode;
        }
    }
}
