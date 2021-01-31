using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TamagotchiUI.DTO;


namespace TamagotchiUI.WebServices
{
    class TamagotchiWebAPI
    {
        HttpClient client;
        string url;

        public TamagotchiWebAPI(string url)
        {
            //Set client handler to support cookies!!
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new System.Net.CookieContainer();

            //Create client with the handler!
            this.client = new HttpClient(handler, true);
            this.url = url;
        }

        public async Task<PlayerDTO> Login(string uName, string uPass)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.url}/Login?userName={uName}&pass={uPass}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    PlayerDTO p = JsonSerializer.Deserialize<PlayerDTO>(content, options);
                    return p;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<List<PetDTO>> AnimalList(PlayerDTO p)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.url}/GetAnimalList");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<PetDTO> list = JsonSerializer.Deserialize<List<PetDTO>>(content, options);
                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
