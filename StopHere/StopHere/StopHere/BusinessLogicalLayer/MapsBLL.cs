using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Responses;
using DataInfrastructure;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class MapsBLL : IMaps
    {
        public SingleResponse<double> GetDistance(double latitude, double longitude, double otherLatitude, double otherLongitude)
        {
            var d1 = latitude * (Math.PI / 180.0);
            var num1 = longitude * (Math.PI / 180.0);
            var d2 = otherLatitude * (Math.PI / 180.0);
            var num2 = otherLongitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            double val = 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
            return FactoryResponse.SuccessSingleResponse<double>(val);
        }


        public async Task<DataResponse<string>> SearchGeolocationAsync(string adress)
        {
            string temp = adress.Replace(" ", "+");
            string request = @"https://maps.googleapis.com/maps/api/geocode/json?address=" + temp + "&key=AIzaSyAGLXT11vHyrybLHkzJSJiR39-2PO_DII4";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(request);
            List<string> resultsList = new List<string>();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string geolocation = await response.Content.ReadAsStringAsync();
                Root root = JsonSerializer.Deserialize<Root>(geolocation);
                try
                {
                    resultsList.Add(root.results[0].geometry.location.lat.ToString().Replace(",", "."));
                    resultsList.Add(root.results[0].geometry.location.lng.ToString().Replace(",", "."));
                }
                catch (Exception ex)
                {
                    return FactoryResponse.FailureDataResponse<string>(ex, "Endereço não encontrado.");
                }
            }
            return FactoryResponse.SuccessDataResponse(resultsList, "Endereço encontrado com sucesso!");
        }

        public async Task<Response> SetGeolocationAsync(Parking parking)
        {
            DataResponse<string> result = await SearchGeolocationAsync($"{parking.Cidade} {parking.UF}, {parking.CEP} {parking.Rua} {parking.Numero}");
            if (result.Success)
            {
                try
                {
                    using (StopHereDBContext db = new StopHereDBContext())
                    {
                        Parking parkingBanco = await db.Parkings.FindAsync(parking.ID);
                        parkingBanco.Latitude = result.Data[0];
                        parkingBanco.Longitude = result.Data[1];
                        await db.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    return FactoryResponse.FailureResponse(ex);
                }
            }

            return FactoryResponse.SuccessResponse("Localização definida com sucesso.");
        }

        public class AddressComponent
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public List<string> types { get; set; }
        }

        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Northeast
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Southwest
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Viewport
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        public class Geometry
        {
            public Location location { get; set; }
            public string location_type { get; set; }
            public Viewport viewport { get; set; }
        }

        public class Result
        {
            public List<AddressComponent> address_components { get; set; }
            public string formatted_address { get; set; }
            public Geometry geometry { get; set; }
            public string place_id { get; set; }
            public List<string> types { get; set; }
        }

        public class Root
        {
            public List<Result> results { get; set; }
            public string status { get; set; }
        }
    }
}
