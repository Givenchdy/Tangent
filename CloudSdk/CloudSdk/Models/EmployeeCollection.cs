﻿using CloudSdk.ApiInterface;
using CloudSdk.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSdk.Models
{
    public class EmployeeCollection
    {
        [JsonProperty(PropertyName = "employees")]
        public Dictionary<Int16, Employee> employeeList = new Dictionary<Int16, Employee>();

        public EmployeeCollection() { }

        /*
         * Fetch employee list from the api
         */ 
        public static EmployeeCollection FetchEmployeeListFromApi()
        {
            ApiAdapter apiAdapter = new ApiAdapter();
            EmployeeCollection employeeCollection = apiAdapter.FetchEmployees();
            return employeeCollection;
        }

        


    }
}
