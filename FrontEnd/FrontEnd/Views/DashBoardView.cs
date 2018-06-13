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

        public static DashBoardPresenter dashBoardPresenter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dashboard_view);

            dashBoardPresenter = new DashBoardPresenter();
            dashBoardPresenter.InitializeCollection();

            ShowDashBoardSummaryFragment();
            // Create your application here
        }

        private void ShowDashBoardSummaryFragment()
        {

            DashboardSummaryFragment dashboardFragmentViewFragment = new DashboardSummaryFragment();
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.fragmentContainerID, dashboardFragmentViewFragment);
            transaction.Commit();
        }



    }
}