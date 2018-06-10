using CloudSdk.Model;
using CloudSdk.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSdk.ApiInterface
{
    class ApiAdapter
    {

        public EmployeeCollection FetchEmployees()
        {

            var client = new RestClient(ApiSettings.BASE_URL);       
            var request = new RestRequest(ApiSettings.GET_EMPLOYEES_URL, Method.GET);
            request.AddParameter("Authorisation", ApiSettings.AUTH_TOKEN);
            IRestResponse response = client.Execute(request);

            //process results logic here...       

            return null;
        }

        public Employee FetchMyProfile(int userID)
        {
            var client = new RestClient(ApiSettings.BASE_URL);
            var request = new RestRequest(ApiSettings.GET_MY_PROFILE, Method.GET);
            request.AddParameter("Authorisation", ApiSettings.AUTH_TOKEN);
            IRestResponse response = client.Execute(request);

            //process results logic here...


            return null;
        }

        public string AuthenticateUser(string email, string password)
        {

            var client = new RestClient();
            var request = new RestRequest(ApiSettings.AUTHENTICATE_USER_URL, Method.GET);
            request.AddParameter("Authorisation", ApiSettings.AUTH_TOKEN);
            IRestResponse response = client.Execute(request);

            //process results logic here...

            return null;
        }

    }
}
