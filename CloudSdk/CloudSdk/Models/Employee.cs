using System;
using Newtonsoft.Json;
using CloudSdk.ApiInterface;
using CloudSdk.Models;

namespace CloudSdk.Model
{
    public class Employee
    {

        public Employee()
        {
        }

        public User user = new User();

        public Position position = new Position();

        [JsonProperty(PropertyName = "email")]
        private string _emailAddress;

        [JsonProperty(PropertyName = "phone")]
        private string _phoneNumber;

        [JsonProperty(PropertyName = "github_user")]
        private string github_user;

        [JsonProperty(PropertyName = "birthdate")]
        private string _bornday;

        private int years_worked;

        private int age;

        private int days_to_birthday;

        public string gender;

        public string race;

        public string Race
        {
            get => race;
            set => race = value;
        }

        public string Gender
        {
            get => gender;
            set => gender = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public int DaysToBirthDay
        {
            get => days_to_birthday;
            set => days_to_birthday = value;
        }


        public int YearsWorked
        {
            get => years_worked;
            set => years_worked = value;
        }

        public string GitUsername
        {
            get => github_user;
            set => github_user = value;
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

        public static Employee FetchEmployeeData()
        {
            ApiAdapter apiAdapter = new ApiAdapter();
            Employee employee = apiAdapter.FetchMyProfile();

            return employee;
        }

        public static string AuthenticateUser(string email, string password)
        {
            ApiAdapter apiAdapter = new ApiAdapter();
            string token = apiAdapter.AuthenticateUser(email, password);

            if (token.Equals(ApiSettings.AUTH_TOKEN))
                return token;
            else
                return null;        
        }

    }
}
