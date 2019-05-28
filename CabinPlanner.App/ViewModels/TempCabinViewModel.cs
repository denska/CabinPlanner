using System;
using System.Collections.Generic;
using CabinPlanner.App.Helpers;
using CabinPlanner.Model;
using Newtonsoft.Json;
using Windows.Web.Http;

namespace CabinPlanner.App.ViewModels
{
    public class TempCabinViewModel : Observable
    {
        static Uri CabinsUri = new Uri("http://localhost:52981/api/cabins");

        HttpClient _httpClient = new HttpClient();

        public TempCabinViewModel()
        {
        }


    }
}
