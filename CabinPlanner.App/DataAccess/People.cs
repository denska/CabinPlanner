
using CabinPlanner.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CabinPlanner.App.DataAccess
{
    public class People
    {
        readonly HttpClient _httpClient = new HttpClient();
        static readonly Uri peopleBaseUri = new Uri("http://localhost:52981/api/people");

        public async Task<Person[]> GetPeopleAsync()
        {
            HttpResponseMessage result = await _httpClient.GetAsync(peopleBaseUri);
            string json = await result.Content.ReadAsStringAsync();
            Person[] people = JsonConvert.DeserializeObject<Person[]>(json);

            return people;
        }

        internal async Task<Person> GetPersonAsync(Person person)
        {
            HttpResponseMessage result = await _httpClient.GetAsync(new Uri(peopleBaseUri, "people/" + person.PersonId.ToString() + "?WithAll=true" ));
            string json = await result.Content.ReadAsStringAsync();
            Person dbPerson = JsonConvert.DeserializeObject<Person>(json);
            return dbPerson;
        }

        internal async Task<Cabin[]> GetPersonCabinsAsync(Person person)
        {
            HttpResponseMessage result = await _httpClient.GetAsync(new Uri(peopleBaseUri, "people/" + person.PersonId.ToString() + "/cabins"));
            string json = await result.Content.ReadAsStringAsync();
            Cabin[] cabins = JsonConvert.DeserializeObject<Cabin[]>(json);

            return cabins;
        }

        internal async Task<Person> GetPersonAsync(int personId)
        {
            HttpResponseMessage result = await _httpClient.GetAsync(new Uri(peopleBaseUri, "people/" + personId.ToString()));
            string json = await result.Content.ReadAsStringAsync();
            Person dbPerson = JsonConvert.DeserializeObject<Person>(json);

            return dbPerson;
        }


        internal async Task<bool> AddPersonAsync(Person person)
        {
            string json = JsonConvert.SerializeObject(person);
            HttpResponseMessage result = await _httpClient.PostAsync(peopleBaseUri, new StringContent(json, Encoding.UTF8, "application/json"));

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

        internal async Task<bool> PutPersonAsync(Person person)
        {
            string json = JsonConvert.SerializeObject(person);
            HttpResponseMessage result = await _httpClient.PutAsync(new Uri(peopleBaseUri, "people/" + person.PersonId.ToString()), new StringContent(json, Encoding.UTF8, "application/json"));
            return result.IsSuccessStatusCode;
        }

        internal async Task<bool> DeletePersonAsync(Person person)
        {
            HttpResponseMessage result = await _httpClient.DeleteAsync(new Uri(peopleBaseUri, "people/" + person.PersonId.ToString()));
            return result.IsSuccessStatusCode;
        }
    }
}
