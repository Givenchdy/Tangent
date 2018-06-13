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
using PCL.Presenters;
using PCL.ViewInterfaces;

namespace FrontEnd.Views
{
    [Activity(Label = "LoginActivity", MainLauncher = true)]
    public class LoginView : Activity, ILoginView
    {

        [BindView(Resource.Id.loginNameTxtID)] EditText loginUserNameBox;
        [BindView(Resource.Id.passwordTxtID)]  EditText loginPasswordBox;
        [BindView(Resource.Id.loginBtnID)]     Button   loginButton;

        LoginPresenter loginPresenter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login_view);
            Cheeseknife.Bind(this);

            loginPresenter = new LoginPresenter();
            loginPresenter.Initialize(this);

            loginButton.Click += OnLoginClick;

        }

        protected void OnLoginClick(object sender, EventArgs e)
        {
            Login();
        }

        public bool Login()
        {
            
            string username = loginUserNameBox.Text;
            string password = loginPasswordBox.Text;
            bool loginResults = loginPresenter.AuthenticateUser(username, password);
            StartDashBoardView();

            return true;
        }

        public void StartDashBoardView()
        {
            StartActivity(typeof(DashBoardView));
            Finish();       
        }


    }
}