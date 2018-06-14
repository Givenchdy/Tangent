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

        public void FetchFilteredEmployeeListFromCloudSdk(string filter)
        {
            EmployeeCollection employeeCollection = EmployeeCollection.FetchEmployeeListFromApi(filter);
            employeeList.Clear();
            foreach (KeyValuePair<int, Employee> item in employeeCollection.employeeList.ToList())
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel();
                employeeViewModel.EmployeeID = item.Value.user.id;
                employeeViewModel.EmployeeLevel = item.Value.position.level;
                employeeViewModel.FirstName = item.Value.user.FirstName;
                employeeViewModel.LastName = item.Value.user.LastName;
                employeeViewModel.PositionName = item.Value.position.name;
                employeeViewModel.EmailAddress = item.Value.EmailAddress;
                employeeViewModel.PhoneNumber = item.Value.PhoneNumber;
                employeeViewModel.GitUsername = item.Value.GitUsername;
                employeeViewModel.BirthDate = item.Value.BornDate;
                employeeViewModel.GenderName = item.Value.Gender;
                employeeViewModel.Race = item.Value.Race;
                employeeList.AddLast(employeeViewModel);
            }

        }



    }
}
