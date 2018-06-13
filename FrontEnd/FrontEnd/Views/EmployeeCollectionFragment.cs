using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using CheeseBind;
using PCL.ViewModel;
using PCL.Lookups;

namespace FrontEnd.Views
{
    public class EmployeeCollectionFragment : Fragment
    {

        [BindView(Resource.Id.employeeListID)] ListView employeeListView;
        EmployeeListItemAdapter employeeListItemAdapter;
        LinkedList<EmployeeViewModel> employeeList;

        public FilterLookup filter;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            employeeList = DashBoardView.dashBoardPresenter.FilteredemployeeList;

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View  view =  inflater.Inflate(Resource.Layout.employee_collection_fragment_view, container, false);
            Cheeseknife.Bind(this, view);
            employeeListView.ItemClick += listClick;
        
            if (employeeList != null)
            {
                EmployeeListItemAdapter employeeListItemAdapter = new EmployeeListItemAdapter(Context, employeeList);
                employeeListView.Adapter = employeeListItemAdapter;
            }

            return view;
        }


        private void listClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            int clickedIndex = e.Position;
            
            UserProfileFragment userProfile = new UserProfileFragment();
            userProfile.selectedEmployee = employeeList.ElementAt(clickedIndex);
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.fragmentContainerID, userProfile);
            transaction.Commit();

        }
    }
}