using FlatRent.Entities;
using FlatRent.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;

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

        internal static async Task<IEnumerable<Rent>> GetRentsByUserEmail(string userEmail)
        {
            IEnumerable<Rent> rents;
            using (var client = new HttpClient())
            {
                var uri = new Uri(StaticData.ApiLink + "api/Rents/" + userEmail);

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                rents = System.Web.Helpers.Json.Decode<IEnumerable<Rent>>(textResult);
            }
            return rents;
        }

        internal static async Task<IEnumerable<Rent>> GetRents()
        {
            IEnumerable<Rent> rents;
            using (var client = new HttpClient())
            {
                var uri = new Uri(StaticData.ApiLink + "api/Rents/");

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                rents = System.Web.Helpers.Json.Decode<IEnumerable<Rent>>(textResult);
            }
            return rents;
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

        public static async System.Threading.Tasks.Task<IEnumerable<Facility>> GetFacilitiesByFlat(int? id)
        {
            List<Facility> facilities;
            using (var client = new HttpClient())
            {
                var uri = new Uri(StaticData.ApiLink + "api/FacilityInFlats/" + id);

                var response = await client.GetAsync(uri);

                string textResult = await response.Content.ReadAsStringAsync();

                facilities = System.Web.Helpers.Json.Decode<List<Facility>>(textResult);
            }
            return facilities;
        }
    }
}