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
                   string content = await response.Content.ReadAsStringAsync();
                    return content;
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

        public async Task<string> GetCleanLevel(int id)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.url}/GetCleanLevel?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return content;
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

        public async Task<string> GetJoyLevel(int id)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.url}/GetJoyLevel?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return content;
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

        public async Task<string> GetHungerLevel(int id)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.url}/GetHungerLevel?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return content;
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

        public async Task<string> ChangePass(string n)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.url}/ChangePass?newVal={n}");
                if (response.IsSuccessStatusCode)
                {
                    return"Password changed successfully! Press any key to go back"; 
                }
                else
                {

                    return "Could not update your password";
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Could not update your password";
            }
        }
        public async Task<string> ChangeUserName(string n)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.url}/ChangeUserName?newVal={n}");
                if (response.IsSuccessStatusCode)
                {
                    return"Username changed successfully! Press any key to go back";
                }
                else
                {
                    return "Could not update your username";
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Could not update your username";

            }
        }
        public async Task<string> ChangeEmail(string n)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.url}/ChangeEmail?newVal={n}");
                if (response.IsSuccessStatusCode)
                {
                    return "Email changed successfully! Press any key to go back";
                }
                else
                {
                    throw new Exception("Could not update your email");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Could not update your email";

            }
        }

        public async Task<List<FoodDTO>> PrintFood()
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.url}/PrintFood");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<FoodDTO> list = JsonSerializer.Deserialize<List<FoodDTO>>(content, options);
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


       
        public async Task<string> Feed(int id)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.url}/Feed?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    return "Yummy! Feeding was completed successfully";
                }
                else
                {
                    throw new Exception("Could not feed your pet");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Could not feed your pet";

            }
        }

        public async Task<PlayerDTO> GetPlayer()
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.url}/GetPlayer");
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

        public async Task<List<ActivityDTO>> CleanlList()
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.url}/GetCleanList");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<ActivityDTO> list = JsonSerializer.Deserialize<List<ActivityDTO>>(content, options);
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

        public async Task<string> UpdateClean(int cleanId)
        {

            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.url}/UpdateCleanLevel?cleanId={cleanId}");
                if (response.IsSuccessStatusCode)
                {
                    return "Thanks for cleaning me! Cleaning was completed successfully";
                }
                else
                {
                    throw new Exception("Could not clean your pet");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Could not clean your pet";

            }
        }

    }
}
    

