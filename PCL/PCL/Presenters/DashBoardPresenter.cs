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

        public EmployeeViewModel FetchMyProfile()
        {
           EmployeeViewModel employeeViewModel =  EmployeeViewModel.FetchMyProfile();
            return employeeViewModel;
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

    }
}
