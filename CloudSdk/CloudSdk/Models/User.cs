using System;
using Newtonsoft.Json;

namespace CloudSdk.Model
{
    [Newtonsoft.Json.JsonObject(Title = "user")]
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public int id;


        [JsonProperty(PropertyName = "username")]
        public string _username;


        public string first_name;


        [JsonProperty(PropertyName = "last_name")]
        private string lastName;


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


        public string FirstName
        {
            get => first_name;
            set => first_name = value;
        }


        public string LastName
        {
            get => lastName;
            set => lastName = value;
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
