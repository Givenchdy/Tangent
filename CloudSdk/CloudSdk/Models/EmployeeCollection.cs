using CloudSdk.ApiInterface;
using CloudSdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSdk.Models
{
    class EmployeeCollection
    {

        Dictionary<Int16, Employee> employeeList = new Dictionary<Int16, Employee>();
        private static EmployeeCollection instance;

        private EmployeeCollection() { }

        public EmployeeCollection Instance()
        {
            if (instance == null)
                instance = new EmployeeCollection();

            return instance;
        }

        /*
         * Fetch employee list from the api
         */ 
        public void FetchEmployeeListFromApi()
        {
            ApiAdapter apiAdapter = new ApiAdapter();
            instance = apiAdapter.FetchEmployees();       
        }

        


    }
}
