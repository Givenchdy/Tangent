using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSdk.Models
{
    class NextOfKin
    {


        private int id;
        private string name;
        private string relationship;
        private string phone_number;
        private string email;
        private string physical_address;
        private int employeeID;

        public int ID
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Relationship
        {
            get => relationship;
            set => relationship = value;
        }

        public string PhoneNumber
        {
            get => phone_number;
            set => phone_number = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        public string PhysicalAddress
        {
            get => physical_address;
            set => physical_address = value;
        }


        public int EmployeeID
        {
            get => employeeID;
            set => employeeID = value;
        }


    }
}
