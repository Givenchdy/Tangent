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

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullNames()
        {
            return FirstName + " " + LastName;
        }


    }
}
