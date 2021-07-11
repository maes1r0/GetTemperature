using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace _5
{
    class Program
    {
        public async Task<List<string>> GetCurrentTemperature()
        {
            List<string> temperature = new List<string>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://goweather.herokuapp.com/weather/Kyiv");
                JObject data = JObject.Parse(await response.Content.ReadAsStringAsync());
                temperature.Add(data.SelectToken("$.temperature").ToString());

                response = await client.GetAsync("https://goweather.herokuapp.com/weather/Odesa");
                data = JObject.Parse(await response.Content.ReadAsStringAsync());
                temperature.Add(data.SelectToken("$.temperature").ToString());
            }
            return temperature;
        }
    }
}
