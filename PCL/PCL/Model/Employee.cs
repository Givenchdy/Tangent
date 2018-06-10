using System;
using Newtonsoft.Json;

namespace PCL.Model
{
    public class Employee : User
    {

        [JsonProperty(PropertyName = "id")]
        private int _employeeId;

        [JsonProperty(PropertyName = "name")]
        private string _positionName;

        [JsonProperty(PropertyName = "level")]
        private string _employeeLevel;

        [JsonProperty(PropertyName = "sort")]
        private int _sort;


        public Employee()
        {
        }

        public int EmployeeID
        {
            get => _employeeId;
            set => _employeeId = value;
        }

        public string PositionName
        {
            get => _positionName;
            set => _positionName = value;
        }

        public string EmployeeLevel
        {
            get => _employeeLevel;
            set => _employeeLevel = value;
        }

        public int Sort
        {
            get => _sort;
            set => _sort = value;
        }

    }
}
