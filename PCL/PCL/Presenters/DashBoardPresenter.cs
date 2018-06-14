using PCL.Lookups;
using PCL.ViewModel;
using System.Collections.Generic;

namespace PCL.Presenters
{
    public class DashBoardPresenter
    {

        public LinkedList<EmployeeViewModel> FilteredemployeeList = new LinkedList<EmployeeViewModel>();

        public DashBoardPresenter()
        {

        }

        public void InitializeCollection()
        {
            EmployeeCollectionViewModel.Instance.FetchFilteredEmployeeListFromCloudSdk(null);
            FilteredemployeeList = EmployeeCollectionViewModel.Instance.employeeList;
        }

        public void GetFilteredEmployeeCollection(FilterLookup filter, string filterValue)
        {

            string queryString = formFilterQueryString(filter, filterValue);
            EmployeeCollectionViewModel.Instance.FetchFilteredEmployeeListFromCloudSdk(queryString);
            FilteredemployeeList = EmployeeCollectionViewModel.Instance.employeeList;

        }

        private string formFilterQueryString(FilterLookup filter, string filterValue)
        {

            switch(filter)
            {
                case FilterLookup.Gender:
                        return "gender=" + filterValue;
                case FilterLookup.Race:
                    return "race=" + filterValue;
                default:
                    return null;
            }

        }


        private void PopulateEmployeeCollectionWithTestData()
        {

            EmployeeViewModel employeeViewModel1 = new EmployeeViewModel();
            employeeViewModel1.EmployeeID = 2;
            employeeViewModel1.FirstName = "Lerato";
            employeeViewModel1.LastName = "Malatji";
            employeeViewModel1.PositionName = "Sales Lead";
            employeeViewModel1.EmployeeLevel = "Senior";

            EmployeeViewModel employeeViewModel2 = new EmployeeViewModel();
            employeeViewModel2.EmployeeID = 13;
            employeeViewModel2.FirstName = "keabetswe";
            employeeViewModel2.LastName = "Motupa";
            employeeViewModel2.PositionName = "Developer";
            employeeViewModel2.EmployeeLevel = "Junior";

            EmployeeViewModel employeeViewModel3 = new EmployeeViewModel();
            employeeViewModel3.EmployeeID = 13;
            employeeViewModel3.FirstName = "Masefako";
            employeeViewModel3.LastName = "Mojapelo";
            employeeViewModel3.PositionName = "Developer";
            employeeViewModel3.EmployeeLevel = "Intermediate";

            EmployeeViewModel employeeViewModel4 = new EmployeeViewModel();
            employeeViewModel4.EmployeeID = 13;
            employeeViewModel4.FirstName = "Mothibi";
            employeeViewModel4.LastName = "Mojapelo";
            employeeViewModel4.PositionName = "Sales Person";
            employeeViewModel4.EmployeeLevel = "Intermediate";

            FilteredemployeeList.AddLast(employeeViewModel4);
            FilteredemployeeList.AddLast(employeeViewModel1);
            FilteredemployeeList.AddLast(employeeViewModel2);
            FilteredemployeeList.AddLast(employeeViewModel3);


        }

    }
}
