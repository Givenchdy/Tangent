using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CheeseBind;
using Android.Support.Constraints;
using PCL.Lookups;
using PCL.Presenters;

namespace FrontEnd.Views
{
    [Activity(Label = "DashBoardActivity")]
    public class DashBoardView : Activity
    {

        public static string CurrentFragmentTag = DashboardSummaryFragment.TAG;
        public static DashBoardPresenter dashBoardPresenter;
        public static Context context;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dashboard_view);

            context = this;

            dashBoardPresenter = new DashBoardPresenter();
            dashBoardPresenter.InitializeCollection();

            ShowDashBoardSummaryFragment();
            // Create your application here
        }

        public static int exitCounter = 0;
        public override void OnBackPressed()
        {
            //base.OnBackPressed();
            if (CurrentFragmentTag.Equals(DashboardSummaryFragment.TAG))
            {
                if (exitCounter == 0)
                {
                    exitCounter++;
                    Toast.MakeText(this, "Press again to exit app", ToastLength.Short).Show();
                }
                else
                {
                    exitCounter = 0;
                    base.OnBackPressed();
                }
            
            }
            else if(CurrentFragmentTag.Equals(EmployeeCollectionFragment.TAG))
            {
                ShowDashBoardSummaryFragment();
            }
            else if(CurrentFragmentTag.Equals(UserProfileFragment.TAG))
            {
                EmployeeCollectionFragment employeeCollectionFragment = new EmployeeCollectionFragment();
                ShowFragment(employeeCollectionFragment);
            }
        }

        private void ShowDashBoardSummaryFragment()
        {
            DashboardSummaryFragment dashboardFragmentViewFragment = new DashboardSummaryFragment();

            ShowFragment(dashboardFragmentViewFragment);
        }

        private void ShowFragment(Fragment fragment)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.fragmentContainerID, fragment);
            transaction.Commit();
        }



    }
}