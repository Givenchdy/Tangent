using CloudSdk.Model;
using PCL.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCL.ViewModel
{
    public class EmployeeViewModel
    {

        public FilterLookup EmployeeType { get; set; }

        public int EmployeeID { get; set; }

        public string GitUsername { get; set; }

        public string GenderName { get; set; }

        public string BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string PositionName { get; set; }

        public string EmployeeLevel { get; set; }

        public string Race { get; set; }

        public NextOfKinViewModel nextOfKin { get; set; }

        public ReviewViewModel Review { get; set; }

        public string GetGender
        {
            get
            {
                switch (Race)
                {
                    case "M":
                        return "Male";
                    default:
                        return "Female";

                }
            }
        }

        public string GetRace
        {
            get
            {
                switch(Race)
                {
                    case "I":
                        return "Indian";
                    case "B":
                        return "Black";
                    case "W":
                        return "White";
                    case "C":
                        return "Coloured";
                    default:
                        return "Non Dominant";
                }
            }
        }

        public static EmployeeViewModel FetchMyProfile()
        {

            Employee employee = Employee.FetchEmployeeData();

            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            //  try
            // {
                employeeViewModel.nextOfKin = new NextOfKinViewModel();
                employeeViewModel.Review = new ReviewViewModel();

                employeeViewModel.EmployeeID = employee.user.id;
                employeeViewModel.EmployeeLevel = employee.position.level;
                employeeViewModel.FirstName = employee.user.FirstName;
                employeeViewModel.LastName = employee.user.LastName;
                employeeViewModel.PositionName = employee.position.name;
                employeeViewModel.EmailAddress = employee.EmailAddress;
                employeeViewModel.PhoneNumber = employee.PhoneNumber;
                employeeViewModel.GitUsername = employee.GitUsername;
                employeeViewModel.BirthDate = employee.BornDate;
                employeeViewModel.GenderName = employee.Gender;
                employeeViewModel.Race = employee.Race;
                employeeViewModel.nextOfKin.Name = employee.NextOfKin.Name;
                employeeViewModel.nextOfKin.PhoneNumber = employee.NextOfKin.PhoneNumber;
                employeeViewModel.nextOfKin.Email = employee.NextOfKin.Email;
                employeeViewModel.nextOfKin.PhysicalAddress = employee.NextOfKin.PhysicalAddress;
                employeeViewModel.nextOfKin.Relationship = employee.NextOfKin.Relationship;
                employeeViewModel.Review.Date = employee.EmployeeReview.date;
                employeeViewModel.Review.Salary = employee.EmployeeReview.salary;
                employeeViewModel.Review.Type = employee.EmployeeReview.type;
                employeeViewModel.Review.ID = employee.EmployeeReview.id;
          //  }
            //catch(Exception ex)
           // {
            //    
           // }

            return employeeViewModel;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullNames()
        {
            return FirstName + " " + LastName;
        }


    }
}
