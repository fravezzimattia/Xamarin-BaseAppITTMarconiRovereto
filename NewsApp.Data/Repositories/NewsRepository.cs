using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NewsApp.Data.Interfaces;
using NewsApp.Model;
using Newtonsoft.Json;

namespace NewsApp.Data.Repositories
{
    public interface INewsRepository : IRepository
    {
        Task<List<News>> Get();
    }

    public class NewsRepository : Repository, INewsRepository
    {
        public async Task<List<News>> Get()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");
                    var result = await client.GetAsync("posts");

                    if (result.IsSuccessStatusCode && result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var json = await result.Content.ReadAsStringAsync();
                        var lista = JsonConvert.DeserializeObject<List<News>>(json);
                        return lista;
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ERR::" + e.Message);
            }
            return new List<News>();
        }
    }
}