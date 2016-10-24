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

namespace ACMEsoftApp.ViewModels
{
    class MainViewModel : BaseViewModel
    {        
        PeopleController peopleController = new PeopleController();
        EmployeesController employeesController = new EmployeesController();

        public MainViewModel()
        {            
            People = peopleController.db.People.ToList();
            Employees = employeesController.db.Employees.ToList();
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
    }
}
