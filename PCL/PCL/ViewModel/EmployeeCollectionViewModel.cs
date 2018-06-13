using CloudSdk.Model;
using CloudSdk.Models;
using PCL.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCL.ViewModel
{
    public class EmployeeCollectionViewModel
    {

        public LinkedList<EmployeeViewModel> employeeList = new LinkedList<EmployeeViewModel>();
        static EmployeeCollectionViewModel instance;

        public static EmployeeCollectionViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new EmployeeCollectionViewModel();
                return instance;
            }
        }

        public void FetchFilteredEmployeeListFromCloudSdk(FilterLookup filter)
        {
            EmployeeCollection employeeCollection = EmployeeCollection.FetchEmployeeListFromApi();

            foreach (KeyValuePair<Int16, Employee> item in employeeCollection.employeeList.ToList())
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel();
                employeeViewModel.EmployeeID = item.Value.EmployeeID;
                employeeViewModel.EmployeeLevel = item.Value.EmployeeLevel;
                employeeViewModel.FirstName = item.Value.FirstName;
                employeeViewModel.LastName = item.Value.LastName;
                employeeViewModel.PositionName = item.Value.PositionName;
            }

        }

        public void FetchEmployeesFromCloudSdk()
        {
            EmployeeCollection employeeCollection = EmployeeCollection.FetchEmployeeListFromApi();

            foreach (KeyValuePair<Int16, Employee> item in employeeCollection.employeeList.ToList())
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel();
                employeeViewModel.EmployeeID = item.Value.EmployeeID;
                employeeViewModel.EmployeeLevel = item.Value.EmployeeLevel;
                employeeViewModel.FirstName = item.Value.FirstName;
                employeeViewModel.LastName = item.Value.LastName;
                employeeViewModel.PositionName = item.Value.PositionName;
                employeeViewModel.EmailAddress = item.Value.EmailAddress;
                employeeViewModel.PhoneNumber = item.Value.PhoneNumber;
                employeeViewModel.GitUsername = item.Value.GitUsername;
                employeeViewModel.BirthDate = item.Value.BornDate;

            }

        }


    }
}
