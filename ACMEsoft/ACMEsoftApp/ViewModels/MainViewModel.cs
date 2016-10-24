using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Text;
using System.Threading.Tasks;
using ACMEsoft.Model;
using ACMEsoft.Controllers;
using System.Data;
using Newtonsoft.Json;

namespace ACMEsoftApp.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        HttpClient client;
        string url;
        PeopleController peopleController = new PeopleController();
        EmployeesController employeesController = new EmployeesController();

        public MainViewModel()
        {
            //Initialize HTTP Client
            client = new HttpClient();
            url = APIAddress + @"/api/EmployeeApi";
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Employees = GetEmployees().Result;
        }

        private List<Person> people;

        public List<Person> People
        {
            get
            {
                return people;
            }
            set
            {
                if (people != value)
                {
                    people = value;
                    NotifyPropertyChanged("People");
                }
            }
        }

        private List<Employee> employees;

        public List<Employee> Employees
        {
            get
            {
                return employees;
            }
            set
            {
                if (employees != value)
                {
                    employees = value;
                    NotifyPropertyChanged("Employees");
                }
            }
        }

        /// <summary>
        /// GET: from api
        /// </summary>
        /// <returns>List of contacts</returns>
        async private Task<List<Employee>> GetEmployees()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            if (!responseMessage.IsSuccessStatusCode)
            {
                //Do not leave the app in an incorrect state, that can not be recovered from.
                throw new DataException("Could not GET from web api");
            }

            string responseData = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<Employee>>(responseData);
        }
    }
}
