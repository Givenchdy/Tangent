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

        public static string TAG = "DashboardSummaryFragment";
        [BindView(Resource.Id.totalEmployeesCountID)] TextView totalEmployeeCountText;
       // [BindView(Resource.Id.totalReviewsTeamCountID)] TextView totalEmployeeReviewCountText;
        [BindView(Resource.Id.totalMonthlyBorndaysTeamCountID)] TextView totalMonthlyBornDaysCountText;

        [BindView(Resource.Id.totalEmployeesContainerID)] ConstraintLayout totalEmployeeButton;
        [BindView(Resource.Id.totalRaceContainerID)] ConstraintLayout totalRaceButton;
        [BindView(Resource.Id.totalGenderContainerID)] ConstraintLayout totalGendersButton;

        [BindView(Resource.Id.MyProfileContainerID)] ConstraintLayout myProfileButton;
        [BindView(Resource.Id.totalBorndaysContainerID)] ConstraintLayout totalMonthlyBornDaysButton;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            DashBoardView.CurrentFragmentTag = TAG;
            DashBoardView.exitCounter = 0;
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
            totalRaceButton.Click += OnRaceFilterClick;
            totalGendersButton.Click += OnGenderFilterClick;
            myProfileButton.Click += OnMyProfileClick;
            totalMonthlyBornDaysButton.Click += OnTotalMonthlyBirthdaysClick;
        }


        protected void OnMyProfileClick(object sender, EventArgs e)
        {
            //ShowEmployeeCollectionView(FilterLookup.EmployeeReviews);
            DetailedUserProfileFragment userViewFragment = new DetailedUserProfileFragment();
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.fragmentContainerID, userViewFragment);
            transaction.Commit();
        }

        protected void OnTotalEmployeeClick(object sender, EventArgs e)
        {
            ShowEmployeeCollectionView(FilterLookup.AllEmployees);
        }



        protected void OnRaceFilterClick(object sender, EventArgs e)
        {
            // ShowEmployeeCollectionView(FilterLookup.Developers);
            FragmentTransaction transcation = FragmentManager.BeginTransaction();
            RaceFilterDialogFragment dialog = new RaceFilterDialogFragment();
            dialog.Show(transcation, "show dialog");
        }

        protected void OnGenderFilterClick(object sender, EventArgs e)
        {
            // ShowEmployeeCollectionView(FilterLookup.Developers);
            FragmentTransaction transcation = FragmentManager.BeginTransaction();
            GenderFilterDialogFragment dialog = new GenderFilterDialogFragment();
            dialog.Show(transcation, "show dialog");
        }




        protected void OnTotalMonthlyBirthdaysClick(object sender, EventArgs e)
        {
            ShowEmployeeCollectionView(FilterLookup.MonthlyBirthDays);
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