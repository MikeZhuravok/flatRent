using FlatRent.Entities;
using FlatRent.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace FlatRent.Web.Concrete
{
    public static class ApiContacter
    {
        // not nullable, in all cases check was already done
        public static async System.Threading.Tasks.Task<Flat> GetFlat(int? id)
        {
            Flat flat;
            using (var client = new HttpClient())
            {
                var uri = new Uri(StaticData.ApiLink + "api/Flats/" + id);

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                flat = System.Web.Helpers.Json.Decode<Flat>(textResult);
            }
            return flat;
        }



        public static async System.Threading.Tasks.Task<IEnumerable<Flat>> GetFlats()
        {
            IEnumerable<Flat> model;
            using (var client = new HttpClient())
            {
                var uri = new Uri(StaticData.ApiLink + "api/Flats");

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                model = System.Web.Helpers.Json.Decode<IEnumerable<Flat>>(textResult);
            }
            return model;
        }

        public static async System.Threading.Tasks.Task<IEnumerable<Facility>> GetFacilities()
        {
            IEnumerable<Facility> model;
            using (var client = new HttpClient())
            {
                var uri = new Uri(StaticData.ApiLink + "api/Facilities");

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                model = System.Web.Helpers.Json.Decode<IEnumerable<Facility>>(textResult);

            }
            return model;
        }


        public static async System.Threading.Tasks.Task<Facility> GetFacility(int? id)
        {
            Facility model;
            using (var client = new HttpClient())
            {
                var uri = new Uri(StaticData.ApiLink + "api/Facilities/" + id);

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                model = System.Web.Helpers.Json.Decode<Facility>(textResult);

            }
            return model;
        }

        public static async System.Threading.Tasks.Task<IEnumerable<Rent>> GetRents(string userEmail)
        {
            IEnumerable<Rent> model;
            using (var client = new HttpClient())
            {
                var uri = new Uri(StaticData.ApiLink + "api/Rents/" + userEmail);

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                model = System.Web.Helpers.Json.Decode<IEnumerable<Rent>>(textResult);

            }
            return model;
        }

        public static async System.Threading.Tasks.Task<IEnumerable<Picture>> GetPictures()
        {
            IEnumerable<Picture> model;
            using (var client = new HttpClient())
            {
                var uri = new Uri(StaticData.ApiLink + "api/Pictures/");

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                model = System.Web.Helpers.Json.Decode<IEnumerable<Picture>>(textResult);
            }
            return model;
        }
    }
}