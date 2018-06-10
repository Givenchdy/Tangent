using System;
using Newtonsoft.Json;

namespace CloudSdk.Model
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        private int _userId;


        [JsonProperty(PropertyName = "username")]
        private string _username;


        [JsonProperty(PropertyName = "email")]
        private string _emailAddress;


        [JsonProperty(PropertyName = "first_name")]
        private string _firstName;


        [JsonProperty(PropertyName = "last_name")]
        private string _lastName;


        [JsonProperty(PropertyName = "is_active")]
        private bool _isActive;


        [JsonProperty(PropertyName = "is_staff")]
        private bool _isStaff;

        [JsonProperty(PropertyName = "is_superuser")]
        private bool _isAdmin;


        public User()
        {
        }

        public string UserName
        {
            get => _username;
            set => _username = value;
        }


        public string EmailAddress
        {
            get => _emailAddress;
            set => _emailAddress = value;
        }


        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }


        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }


        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }


        public bool IsStaff
        {
            get => _isStaff;
            set => _isStaff = value;
        }

        public bool IsAdmin
        {
            get => _isAdmin;
            set => _isAdmin = value;
        }

    }
}
