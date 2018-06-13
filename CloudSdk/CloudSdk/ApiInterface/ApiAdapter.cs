using CloudSdk.Enums;
using CloudSdk.Model;
using CloudSdk.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CloudSdk.ApiInterface
{
    class ApiAdapter
    {

        public EmployeeCollection FetchEmployees()
        {

            //provide url and package authorisation token
            WebClient client = new WebClient();
            String uri = ApiSettings.BASE_URL + ApiSettings.GET_EMPLOYEES_URL;
            client.Headers.Add("Authorization", ApiSettings.AUTH_TOKEN);
            client.Headers.Add("Content-Type", "Application/Json");

            //send request
            Stream myStream = client.OpenRead(uri);
            StreamReader sr = new StreamReader(myStream);
            var content = sr.ReadToEnd();

            //System.Console.Out.WriteLine(content);
           // content.ToString();

            //Process response
            EmployeeCollection employeeCollection = new EmployeeCollection();
            // JsonConvert.PopulateObject(content, employeeCollection);

            List<Employee> items = JsonConvert.DeserializeObject<List<Employee>>(content);
            //System.Console.Out.WriteLine("johhhh" + items.ElementAt(0).first_name);

            //int count = 1;
            //foreach(Employee item in items)
            //{
            //    try
            //    {
            //        employeeCollection.employeeList.Add((Int16)count, item);
            //        System.Console.Out.WriteLine("Item Key: " + count + "--" + item.FirstName + "--" + item.EmployeeLevel);
            //        count++;

            //    }
            //    catch (Exception ex)
            //    {
            //        System.Console.Out.WriteLine(ex.Message);
            //    }
            //}

            myStream.Close();

            return employeeCollection;
        }

        public EmployeeCollection FetchFilteredEmployees()
        {

            return null;
        }

        public Employee FetchMyProfile()
        {
            //provide url and package authorisation token
            WebClient client = new WebClient();
            String uri = ApiSettings.BASE_URL + ApiSettings.GET_MY_PROFILE;
            client.Headers.Add("Authorization", ApiSettings.AUTH_TOKEN);
            client.Headers.Add("Content-Type", "Application/Json");

            //send request
            Stream myStream = client.OpenRead(uri);
            StreamReader sr = new StreamReader(myStream);
            var content = sr.ReadToEnd();

            //Process response
            Employee employee = new Employee();
            JsonConvert.PopulateObject(content, employee);
            myStream.Close();

            return employee;
        }

        public string AuthenticateUser(string email, string password)
        {

            //var client = new RestClient();
            //var request = new RestRequest(ApiSettings.AUTHENTICATE_USER_URL, Method.GET);
            //request.AddParameter("Authorisation", ApiSettings.AUTH_TOKEN);
            //IRestResponse response = client.Execute(request);

            //process results logic here...

            return null;
        }

        public string CreateFilter(Dictionary<string, EmployeeFilter> filters)
        {

            foreach(KeyValuePair<string, EmployeeFilter> filter in filters)
            {
                ReturnFilterString(filter.Value, filter.Key);
            }
            /// api / employee /? race = C & position = 2 & 
            //start_date_range = 4 & user = 12 & gender = M & 
            //birth_date_range = 4 & email__contains = prav

            return null;
        }

        private string ReturnFilterString(EmployeeFilter filter, string filterText)
        {
            string compiledText = "&";

            switch(filter)
            {
                case EmployeeFilter.Gender:
                    compiledText += "gender=" + filterText;
                    break;
                case EmployeeFilter.Race:
                    compiledText += "race=" + filterText;
                    break;
                case EmployeeFilter.MonthlyBirthDays:
                    compiledText += "birth_date_range=" + filterText;
                    break;
                case EmployeeFilter.Email:
                    compiledText += "email__contains=" + filterText;
                    break;
            }

            return compiledText;
        }


    }
}
