using CloudSdk.Enums;
using CloudSdk.Model;
using CloudSdk.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public EmployeeCollection FetchEmployees(string filter)
        {

            //provide url and package authorisation token
            WebClient client = new WebClient();
            String uri = null;

            if (filter == null)
              uri = ApiSettings.BASE_URL + ApiSettings.GET_EMPLOYEES_URL;
            else
                uri = ApiSettings.BASE_URL + ApiSettings.GET_EMPLOYEES_URL + "?" + filter;

            client.Headers.Add("Authorization", ApiSettings.AUTH_TOKEN);
            client.Headers.Add("Content-Type", "Application/Json");

            //send request
            Stream myStream = client.OpenRead(uri);
            StreamReader sr = new StreamReader(myStream);
            var content = sr.ReadToEnd();

            System.Console.Out.WriteLine(content);

            //Process response
            EmployeeCollection employeeCollection = new EmployeeCollection();
            List<Object> jsonArrayString = JsonConvert.DeserializeObject<List<Object>>(content);

            for(int i= 0; i < jsonArrayString.Count; i++)
            {
                String jsonString = jsonArrayString.ElementAt(i).ToString();
                Employee em1 = JsonConvert.DeserializeObject<Employee>(jsonString);

                employeeCollection.employeeList.Add(i, em1);
            }

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

            //provide url and package authorisation token
            WebClient client = new WebClient();
            String uri = ApiSettings.AUTHENTICATE_USER_URL;
            client.Headers.Add("password", password);
            client.Headers.Add("username", email);
            
            System.Collections.Specialized.NameValueCollection formData = new System.Collections.Specialized.NameValueCollection();
            formData["username"] = email;
            formData["password"] = password;

            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            //UploadData implicitly sets HTTP POST as the request method.
            byte[] responseArray = client.UploadValues(uri, formData);

            //Get response in json form to work with
            JObject jsonObject = JObject.Parse(Encoding.ASCII.GetString(responseArray));

            //Process response
            JToken token = jsonObject["token"];

            return token.ToString();
        }

        public string CreateFilter(Dictionary<string, EmployeeFilter> filters)
        {

            foreach(KeyValuePair<string, EmployeeFilter> filter in filters)
            {
                ReturnFilterString(filter.Value, filter.Key);
            }
  
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
