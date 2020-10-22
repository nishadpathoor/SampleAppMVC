using Api.Interface;
using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Api.OneSingle
{
    public class OneSingleApp : IGenericApp
    {
        public AppModel CreateApp(AppModel app)
        {
            using (var client = GetHttpClient())
            {
                var body = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("name", app.Name)
        };
                var readTask = client.PostAsync("apps", new FormUrlEncodedContent(body));
                readTask.Wait();
                HttpResponseMessage response = readTask.Result;

                response.EnsureSuccessStatusCode();
                var readTextTask = response.Content.ReadAsStringAsync();
                readTextTask.Wait();
                var responseAsString = readTextTask.Result;
                var resultSet = JsonConvert.DeserializeObject<OneSingleAppModel>(responseAsString);
                return MapToVM(resultSet);
            }
        }

        public bool DeleteApp(string id)
        {
            return true;
        }

        public AppModel UpdateApp(AppModel app)
        {
            using (var client = GetHttpClient())
            {
                var body = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("name", app.Name)
        };
                var readTask = client.PutAsync("apps/" + app.Id, new FormUrlEncodedContent(body));
                readTask.Wait();
                HttpResponseMessage response = readTask.Result;

                response.EnsureSuccessStatusCode();
                var readTextTask = response.Content.ReadAsStringAsync();
                readTextTask.Wait();
                var responseAsString = readTextTask.Result;
                var resultSet = JsonConvert.DeserializeObject<OneSingleAppModel>(responseAsString);
                return MapToVM(resultSet);
            }
        }

        public AppModel ViewApp(string id)
        {
            using (var client = GetHttpClient())
            {
                var readTask = client.GetAsync("apps/" + id);
                readTask.Wait();
                HttpResponseMessage response = readTask.Result;

                response.EnsureSuccessStatusCode();
                var readTextTask = response.Content.ReadAsStringAsync();
                readTextTask.Wait();
                var responseAsString = readTextTask.Result;
                var resultSet = JsonConvert.DeserializeObject<OneSingleAppModel>(responseAsString);
                return MapToVM(resultSet);
            }
        }

        public List<AppModel> ViewApps()
        {
            using (var client = GetHttpClient())
            {
                var readTask = client.GetAsync("apps");
                readTask.Wait();
                HttpResponseMessage response = readTask.Result;

                response.EnsureSuccessStatusCode();
                var readTextTask = response.Content.ReadAsStringAsync();
                readTextTask.Wait();
                var responseAsString = readTextTask.Result;
                var resultSet = JsonConvert.DeserializeObject<List<OneSingleAppModel>>(responseAsString);
                return (from x in resultSet
                        select MapToVM(x)).ToList();
            }
        }

        HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            string baseUrl = "https://onesignal.com/api/v1/";
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Add("Authorization", "Basic MmYwNWQ5MWYtNzE5NS00NzUxLTg4NjAtYjRlODc2ZWUyZjc0");
            return client;
        }

        AppModel MapToVM(OneSingleAppModel x)
        {
            return new AppModel()
            {
                Id = x.id,
                Name = x.name,
                UpdatedOn = Convert.ToDateTime(x.created_at),
                CreatedOn = Convert.ToDateTime(x.updated_at),
            };
        }
    }

    class OneSingleAppModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
