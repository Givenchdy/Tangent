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
using PCL.Lookups;
using Android.Support.Constraints;

namespace FrontEnd.Views
{
    public class DashboardSummaryFragment : Fragment
    {

        [BindView(Resource.Id.totalEmployeesCountID)] TextView totalEmployeeCountText;
        [BindView(Resource.Id.totalDeveloperCountID)] TextView totalDevelopersCountText;
        [BindView(Resource.Id.totalSalesTeamCountID)] TextView totalSalesTeamCountText;
        [BindView(Resource.Id.totalReviewsTeamCountID)] TextView totalEmployeeReviewCountText;
        [BindView(Resource.Id.totalMonthlyBorndaysTeamCountID)] TextView totalMonthlyBornDaysCountText;

        [BindView(Resource.Id.totalEmployeesContainerID)] ConstraintLayout totalEmployeeButton;
        [BindView(Resource.Id.totalDevelopersContainerID)] ConstraintLayout totalDevelopersButton;
        [BindView(Resource.Id.totalSalesContainerID)] ConstraintLayout totalSalesTeamButton;
        [BindView(Resource.Id.totalReviewsContainerID)] ConstraintLayout totalEmployeeReviewButton;
        [BindView(Resource.Id.totalBorndaysContainerID)] ConstraintLayout totalMonthlyBornDaysButton;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
             View view = inflater.Inflate(Resource.Layout.dashboard_fragment_view, container, false);

            Cheeseknife.Bind(this, view);
            SetActions();

            return view;
        }

        private void SetActions()
        {
            totalEmployeeButton.Click += OnTotalEmployeeClick;
            totalDevelopersButton.Click += OnTotalDevelopersClick;
            totalSalesTeamButton.Click += OnTotalSalesTeamClick;
            totalEmployeeReviewButton.Click += OnEmployeeReviewsClick;
            totalMonthlyBornDaysButton.Click += OnTotalMonthlyBirthdaysClick;
        }

        protected void OnTotalEmployeeClick(object sender, EventArgs e)
        {
            ShowEmployeeCollectionView(FilterLookup.AllEmployees);
        }

        protected void OnTotalDevelopersClick(object sender, EventArgs e)
        {
           // ShowEmployeeCollectionView(FilterLookup.Developers);
        }

        protected void OnTotalSalesTeamClick(object sender, EventArgs e)
        {
           // ShowEmployeeCollectionView(FilterLookup.SalesTeam);
        }

        protected void OnTotalMonthlyBirthdaysClick(object sender, EventArgs e)
        {
            ShowEmployeeCollectionView(FilterLookup.MonthlyBirthDays);
        }

        protected void OnEmployeeReviewsClick(object sender, EventArgs e)
        {
            ShowEmployeeCollectionView(FilterLookup.EmployeeReviews);
        }

        public void ShowEmployeeCollectionView(FilterLookup filter)
        {
            EmployeeCollectionFragment employeeCollectionViewFragment = new EmployeeCollectionFragment();
            employeeCollectionViewFragment.filter = filter;
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.fragmentContainerID, employeeCollectionViewFragment);
            transaction.Commit();
        }

    }

    
}