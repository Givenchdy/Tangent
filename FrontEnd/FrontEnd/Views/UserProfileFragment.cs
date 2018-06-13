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
using PCL.ViewModel;
using CheeseBind;

namespace FrontEnd.Views
{
    public class UserProfileFragment : Fragment
    {

        public EmployeeViewModel selectedEmployee;

        [BindView(Resource.Id.firstnameTextID)] TextView firstNameText;
        [BindView(Resource.Id.lastNameTextID)]  TextView lastNameText;
        [BindView(Resource.Id.PositionTextID)]  TextView positionNameText;
        [BindView(Resource.Id.LevelTextID)]     TextView LevelNameText;
        [BindView(Resource.Id.BornDayTextID)]   TextView bornDayText;
        [BindView(Resource.Id.genderTextID)]    TextView genderText;


        //Contact details
        [BindView(Resource.Id.PhoneTextID)] TextView phoneText;
        [BindView(Resource.Id.EmailTextID)] TextView emailText;
        [BindView(Resource.Id.GithubUsernameTextID)] TextView gitusernameText;



        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
             View view =  inflater.Inflate(Resource.Layout.user_profile_view, container, false);
            Cheeseknife.Bind(this, view);

            SetUserData();

            return view;
        }

        private void SetUserData()
        {

            if (selectedEmployee != null)
            {

                firstNameText.Text = selectedEmployee.FirstName;
                lastNameText.Text = selectedEmployee.LastName;
                positionNameText.Text = selectedEmployee.PositionName;
                LevelNameText.Text = selectedEmployee.EmployeeLevel;
                bornDayText.Text = selectedEmployee.BirthDate;
                genderText.Text = selectedEmployee.GenderName;

                //Contact details
                phoneText.Text = selectedEmployee.PhoneNumber;
                emailText.Text = selectedEmployee.EmailAddress;
                gitusernameText.Text = selectedEmployee.GitUsername;
            }

    }
    }
}