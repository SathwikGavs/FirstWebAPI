using Microsoft.Graph;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIClientConsole
{
    internal class EmployeeAPIClient
    {

        static Uri uri= new Uri("http://localhost:5126/");
        public static async Task CallGetAllEmployee()
        {
            using(var client = new HttpClient())
            {
                //client.BaseAddress = uri;

                //HttpResponseMessage response = await client.GetAsync("GetAllEmployee");
                //response.EnsureSuccessStatusCode();
                //if(response.IsSuccessStatusCode )
                //{
                //    String x = await response.Content.ReadAsStringAsync();
                //    await Console.Out.WriteLineAsync(x);
                //}


                client.BaseAddress = uri;
                List<Employee> employees = new List<Employee>();
                client.DefaultRequestHeaders
                    .Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));



                //HttpGet:
                HttpResponseMessage response = await client.GetAsync("GetAllEmployees");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    //install Newtonsoft.Json using package installer
                    employees = JsonConvert.DeserializeObject<List<Employee>>(json);
                    foreach (Employee emp in employees)
                    {
                        await Console.Out.WriteLineAsync($"{emp.EmployeeId},{emp.FirstName},{emp.LastName}");
                    }
                }
            }
        }



    }
}
