
using CabinPlanner.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CabinPlanner.App.DataAccess
{
    public class CabinUsers
    {
        readonly HttpClient _httpClient = new HttpClient();
        static readonly Uri cabinBaseUri = new Uri("http://localhost:52981/api/cabinusers");
        /*
        public async Task<Person[]> GetPeopleAsync()
        {
            HttpResponseMessage result = await _httpClient.GetAsync(cabinBaseUri);
            string json = await result.Content.ReadAsStringAsync();
            Person[] people = JsonConvert.DeserializeObject<Person[]>(json);

            return people;
        }

        internal async Task<Person> GetPersonAsync(Person person)
        {
            HttpResponseMessage result = await _httpClient.GetAsync(new Uri(cabinBaseUri, "people/" + person.PersonId.ToString()));
            string json = await result.Content.ReadAsStringAsync();
            Person dbPerson = JsonConvert.DeserializeObject<Person>(json);
            return dbPerson;
        }

        internal async Task<Cabin[]> GetPersonCabinsAsync(Person person)
        {
            HttpResponseMessage result = await _httpClient.GetAsync(new Uri(cabinBaseUri, "people/" + person.PersonId.ToString() + "/cabins"));
            string json = await result.Content.ReadAsStringAsync();
            Cabin[] cabins = JsonConvert.DeserializeObject<Cabin[]>(json);
            return cabins;
        }

        internal async Task<Person> GetPersonAsync(int personId)
        {
            HttpResponseMessage result = await _httpClient.GetAsync(new Uri(cabinBaseUri, "people/" + personId.ToString()));
            string json = await result.Content.ReadAsStringAsync();
            Person dbPerson = JsonConvert.DeserializeObject<Person>(json);

            return dbPerson;
        }


        internal async Task<bool> AddPersonAsync(Person person)
        {
            string json = JsonConvert.SerializeObject(person);
            HttpResponseMessage result = await _httpClient.PostAsync(cabinBaseUri, new StringContent(json, Encoding.UTF8, "application/json"));

            if (result.IsSuccessStatusCode)
            {
                json = await result.Content.ReadAsStringAsync();
                var returnedActor = JsonConvert.DeserializeObject<Person>(json);
                person.PersonId = returnedActor.PersonId;

                return true;
            }
            else
                return false;
        }

        internal async Task<bool> PutCabinUserAsync(CabinUser cabinUser)
        {
            string json = JsonConvert.SerializeObject(cabinUser);
            HttpResponseMessage result = await _httpClient.PutAsync(new Uri(cabinBaseUri, "cabinusers/" + cabinUser.PersonId.ToString()), new StringContent(json, Encoding.UTF8, "application/json"));
            return result.IsSuccessStatusCode;
        }

        internal async Task<bool> DeleteCabinUserAsync(CabinUser cabinUser)
        {
            HttpResponseMessage result = await _httpClient.DeleteAsync(new Uri(cabinBaseUri, "cabinusers/" + cabinUser.PersonId.ToString()));
            return result.IsSuccessStatusCode;
        }
        */
    }
}
