﻿using Newtonsoft.Json;

// repurposed from https://github.com/chris-dev-at/AddressDistanceCalculator

namespace Libraries.DistanceAddressCalculator
{
    /// <summary>
    /// Get Coordinates for Adresses and calculate air/car distance in km
    /// </summary>
    public class Address
    {
        [JsonProperty("osm_id")] //used for DeserializeObject Function 
        public long ID;
        [JsonProperty("lat")]
        public double Latitude;
        [JsonProperty("lon")]
        public double Longitude;
        [JsonProperty("display_name")]
        public string Name;

        public Address(long ID, double Latitude, double Longitude, string Name)
        {
            this.ID = ID;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            this.Name = Name;
        }

        /* Todo
        public Address(int osm_id, bool spider_information = false)
        {
            
        }

        private void Spider_Infos()
        {

        }
        */

        public override string ToString()
        {
            return this.Name.Replace(',', ' ');
        }

        #region static Methods    
        /// <summary>
        /// Find all Addresses by the given name (Coordinates, OSM_ID, Full Name)
        /// </summary>
        /// <param name="name">The name of the Address you want to find</param>
        /// <returns></returns>
        public static Address[] FindAddresses(string name)
        {
            List<Address> addresses = new List<Address>();
            string url = $"https://nominatim.openstreetmap.org/search?format=jsonv2&q={name}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "NOT NULL");
            string rawdata = client.GetStringAsync(url).Result;

            addresses = JsonConvert.DeserializeObject<List<Address>>(rawdata);

            return addresses.ToArray();
        }

        /// <summary>
        /// Calculates the Air Distance between 2 Points
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double CalcDistance(Address a, Address b)
        {
            return DistanceTo(a.Latitude, a.Longitude, b.Latitude, b.Longitude);
        }
        /// <summary>
        /// Calculates Air Distance between two Coordinates
        /// </summary>
        /// <param name="lat1">Latitude of Point 1</param>
        /// <param name="lon1">Longitude of Point 1</param>
        /// <param name="lat2">Latitude of Point 2</param>
        /// <param name="lon2">Longitude of Point 2</param>
        /// <param name="unit">Specify in which unit you want your answer to be. K=Kilometers(default) N=Nautical Miles M=Miles</param>
        /// <returns></returns>
        private static double DistanceTo(double lat1, double lon1, double lat2, double lon2, char unit = 'K')
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            switch (unit)
            {
                case 'K': //Kilometers -> default
                    return dist * 1.609344;
                case 'N': //Nautical Miles 
                    return dist * 0.8684;
                case 'M': //Miles
                    return dist;
            }

            return dist;
        }

        /// <summary>
        /// Sends a WebRequest to a given URL and returns the website content as string
        /// </summary>
        /// <param name="url">URL of the website</param>
        /// <returns></returns>
        private static string RequestWebString(string url)
        {
            List<Address> addresses = new List<Address>();
            Console.WriteLine(url);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "NOT NULL"); // needed for 2. Api since it wont allow acces without User-Agent
            return client.GetStringAsync(url).Result;
        }
        #endregion
    }
}