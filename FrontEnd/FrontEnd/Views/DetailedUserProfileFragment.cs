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

namespace FrontEnd.Views
{
    public class DetailedUserProfileFragment : Fragment
    {


        [BindView(Resource.Id.firstnameTextID)] TextView firstNameText;
        [BindView(Resource.Id.lastNameTextID)] TextView lastNameText;
        [BindView(Resource.Id.PositionTextID)] TextView positionNameText;
        [BindView(Resource.Id.LevelTextID)] TextView LevelNameText;
        [BindView(Resource.Id.BornDayTextID)] TextView bornDayText;
        [BindView(Resource.Id.GenderTextID)] TextView genderText;
        [BindView(Resource.Id.RaceTextID)] TextView raceText;

        [BindView(Resource.Id.nextOfKinNameTextID)] TextView nextOfKinName;
        [BindView(Resource.Id.nextOfKinRelationTextID)] TextView nextOfKinRelationship;
        [BindView(Resource.Id.nextOfKinEmailTextID)] TextView nextOfKinEmail;
        [BindView(Resource.Id.nextOfKinPhoneTextID)] TextView nextOfKinPhone;
        [BindView(Resource.Id.nextOfKinAddressTextID)] TextView nextOfKinAddress;


        [BindView(Resource.Id.reviewDateTextID)] TextView reviewDate;
        [BindView(Resource.Id.reviewSalaryTextID)] TextView reviewSalary;
        [BindView(Resource.Id.reviewTypeTextID)] TextView reviewType;


        //Contact details
        [BindView(Resource.Id.PhoneTextID)] TextView phoneText;
        [BindView(Resource.Id.EmailTextID)] TextView emailText;
        [BindView(Resource.Id.GithubUsernameTextID)] TextView gitusernameText;

        public EmployeeViewModel selectedEmployee;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            selectedEmployee = DashBoardView.dashBoardPresenter.FetchMyProfile();

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
             View view =  inflater.Inflate(Resource.Layout.user_detailed_profile_view, container, false);
            Cheeseknife.Bind(this, view);

            SetUserData();
             return view;
        }

        private void SetUserData()
        {

            if (selectedEmployee != null)
            {
           //     try
           //     {
                    firstNameText.Text = selectedEmployee.FirstName;
                    lastNameText.Text = selectedEmployee.LastName;
                    positionNameText.Text = selectedEmployee.PositionName;
                    LevelNameText.Text = selectedEmployee.EmployeeLevel;
                    bornDayText.Text = selectedEmployee.BirthDate;
                    genderText.Text = selectedEmployee.GetGender;
                    raceText.Text = selectedEmployee.GetRace;

                    //Contact details
                    phoneText.Text = selectedEmployee.PhoneNumber;
                    emailText.Text = selectedEmployee.EmailAddress;
                    gitusernameText.Text = selectedEmployee.GitUsername;

                    nextOfKinName.Text = selectedEmployee.nextOfKin.Name;
                    nextOfKinRelationship.Text = selectedEmployee.nextOfKin.Relationship;
                    nextOfKinEmail.Text = selectedEmployee.nextOfKin.Email;
                    nextOfKinPhone.Text = selectedEmployee.nextOfKin.PhoneNumber;
                    nextOfKinAddress.Text = selectedEmployee.nextOfKin.PhysicalAddress;

             //   }
              //  catch(Exception ex)
              //  {
              //      Log.Error(Tag, ex.Message);
              //  }
            }
        }
    }
}