using System;
using Newtonsoft.Json;
using CloudSdk.ApiInterface;

namespace CloudSdk.Model
{
    public class Employee : User
    {

        [JsonProperty(PropertyName = "id")]
        public int id;

        [JsonProperty(PropertyName = "name")]
        private string _positionName;

        [JsonProperty(PropertyName = "level")]
        public string level;

        [JsonProperty(PropertyName = "sort")]
        private int _sort;

        [JsonProperty(PropertyName = "email")]
        private string _emailAddress;

        [JsonProperty(PropertyName = "phone")]
        private string _phoneNumber;

        [JsonProperty(PropertyName = "gituser")]
        private string _gitusername;

        [JsonProperty(PropertyName = "birthdate")]
        private string _bornday;

        public Employee()
        {
        }

        public string GitUsername
        {
            get => _gitusername;
            set => _gitusername = value;
        }

        public string BornDate
        {
            get => _bornday;
            set => _bornday = value;
        }

        public string EmailAddress
        {
            get => _emailAddress;
            set => _emailAddress = value;
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value;
        }

        public int EmployeeID
        {
            get => id;
            set => id = value;
        }

        public string PositionName
        {
            get => _positionName;
            set => _positionName = value;
        }

        public string EmployeeLevel
        {
            get => level;
            set => level = value;
        }

        public int Sort
        {
            get => _sort;
            set => _sort = value;
        }

        public static Employee FetchEmployeeData()
        {
            ApiAdapter apiAdapter = new ApiAdapter();
            Employee employee = apiAdapter.FetchMyProfile();

            return employee;
        }

        public static bool AuthenticateUser(string email, string password)
        {
            ApiAdapter apiAdapter = new ApiAdapter();
            string token = apiAdapter.AuthenticateUser(email, password);

            if (token.Equals(ApiSettings.AUTH_TOKEN))
                return true;
            else
                return false;        
        }

    }
}
