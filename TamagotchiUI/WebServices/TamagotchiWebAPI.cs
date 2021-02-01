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

        public async Task<List<PetDTO>> AnimalList()
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

        public async Task<string> GetStatus(int id)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.url}/GetPetStatus?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    string status = JsonSerializer.Deserialize<string>(content, options);
                    return status;
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
        public async void ChangePass(string n)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.url}/ChangePass?pass={n}");
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    throw new Exception("Could not update your password");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
        public async void ChangeUserName(string n)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.url}/ChangeUserName?userName={n}");
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    throw new Exception("Could not update your username");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
        public async void ChangeEmail(string n)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.url}/ChangeUserName?email={n}");
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
                else
                {
                    throw new Exception("Could not update your email");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}
