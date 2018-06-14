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

        public string IdNumber
        {
            get => id_number;
            set => id_number = value;
        }

        private string id_number;

        private string physical_address;
        public string PhysicalAddress
        {
            get => physical_address;
            set => physical_address = value;
        }

        private string personal_email;
        public string PersonalEmail
        {
            get => personal_email;
            set => personal_email = value;
        }

        private string birth_date;
        public string BirthDate
        {
            get => birth_date;
            set => birth_date = value;
        }

        private string start_date;
        public string StartDate
        {
            get => start_date;
            set => start_date = value;
        }

        private bool is_employed;
        public bool IsEmployed
        {
            get => is_employed;
            set => is_employed = value;
        }

        private bool is_foreigner;
        public bool IsForeigner
        {
            get => is_foreigner;
            set => is_foreigner = value;
        }

        private int years_worked;
        public int YearsWorked
        {
            get => years_worked;
            set => years_worked = value;
        }

        private string next_review;
        public string NextReview
        {
            get => next_review;
            set => next_review = value;
        }

        private int leave_remaining;
        public int LeaveRemaining
        {
            get => leave_remaining;
            set => leave_remaining = value;
        }


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

        private int age;

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
