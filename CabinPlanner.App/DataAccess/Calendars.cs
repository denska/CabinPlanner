using CabinPlanner.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CabinPlanner.App.DataAccess
{
    public class Calendars
    {
        readonly HttpClient _httpClient = new HttpClient();
        public static readonly Uri calendarBaseUri = new Uri("http://localhost:52981/api/calendars");

        public async Task<Calendar[]> GetCalendarsAsync()
        {
            HttpResponseMessage result = await _httpClient.GetAsync(calendarBaseUri);
            string json = await result.Content.ReadAsStringAsync();
            Calendar[] calendars = JsonConvert.DeserializeObject<Calendar[]>(json);

            return calendars;
        }

        internal async Task<Calendar> GetCalendarAsync(Calendar calendar)
        {
            HttpResponseMessage result = await _httpClient.GetAsync(new Uri(calendarBaseUri, "calendars/" + calendar.CalendarId.ToString()));
            string json = await result.Content.ReadAsStringAsync();
            Calendar dbCalendar = JsonConvert.DeserializeObject<Calendar>(json);
            return dbCalendar;
        }

        internal async Task<Calendar> GetCalendarAsync(int calendarId)
        {
            HttpResponseMessage result = await _httpClient.GetAsync(new Uri(calendarBaseUri, "calendars/" + calendarId.ToString()));
            string json = await result.Content.ReadAsStringAsync();
            Calendar dbCalendar = JsonConvert.DeserializeObject<Calendar>(json);
            return dbCalendar;
        }

        internal async Task<PlannedTrip[]> GetCalendarTripsAsync(Calendar calendar)
        {
            HttpResponseMessage result = await _httpClient.GetAsync(new Uri(calendarBaseUri, "calendars/" + calendar.CalendarId.ToString() + "/trips"));
            string json = await result.Content.ReadAsStringAsync();
            PlannedTrip[] plannedTrips = JsonConvert.DeserializeObject<PlannedTrip[]>(json);
            return plannedTrips;
        }


        internal async Task<bool> AddCalendarAsync(Calendar calendar)
        {
            //string json = JsonConvert.SerializeObject(cabin);
            //HttpResponseMessage result = await _httpClient.PostAsync(cabinsBaseUri, new StringContent(json, Encoding.UTF8, "application/json"));

            var json = JsonConvert.SerializeObject(calendar);

            var result = await _httpClient.PostAsync(calendarBaseUri, new StringContent(json, Encoding.UTF8, "application/json"));

            if (result.IsSuccessStatusCode)
            {
                json = await result.Content.ReadAsStringAsync();
                var returnedCalendar = JsonConvert.DeserializeObject<Calendar>(json);
                calendar.CalendarId = returnedCalendar.CalendarId;
                return true;
            }
            else
                return false;
        }

        internal async Task<bool> PutCalendarAsync(Calendar calendar)
        {
            string json = JsonConvert.SerializeObject(calendar);
            HttpResponseMessage result = await _httpClient.PutAsync(new Uri(calendarBaseUri, "calendars/" + calendar.CalendarId.ToString()), new StringContent(json, Encoding.UTF8, "application/json"));
            return result.IsSuccessStatusCode;
        }

        internal async Task<bool> PutCalendarTripAsync(Calendar calendar, PlannedTrip trip)
        {
            string json = JsonConvert.SerializeObject(trip);
            HttpResponseMessage result = await _httpClient.PutAsync(new Uri(calendarBaseUri, "calendars/" + calendar.CalendarId.ToString()) + "/trips", new StringContent(json, Encoding.UTF8, "application/json"));
            return result.IsSuccessStatusCode;
        }

        internal async Task<bool> PutCalendarTripAsync(Calendar calendar, int tripId)
        {
            string json = JsonConvert.SerializeObject(calendar);
            HttpResponseMessage result = await _httpClient.PutAsync(new Uri(calendarBaseUri, "calendars/" + calendar.CalendarId.ToString()) + "/trips/" + tripId.ToString(), new StringContent(json, Encoding.UTF8, "application/json"));
            return result.IsSuccessStatusCode;
        }

        internal async Task<bool> DeleteCalendarAsync(Calendar calendar)
        {
            HttpResponseMessage result = await _httpClient.DeleteAsync(new Uri(calendarBaseUri, "calendars/" + calendar.CalendarId.ToString()));
            return result.IsSuccessStatusCode;
        }
    }
}
