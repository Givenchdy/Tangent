using PCL.ViewInterfaces;

namespace PCL.Presenters
{
    public class LoginPresenter
    {
        ILoginView IloginView;

        public void Initialize(ILoginView IloginView)
        {
            this.IloginView = IloginView;
            CheckUserAuthentication(true);
        }

        public void CheckUserAuthentication(bool loginStatus)
        {
            if(loginStatus)
            {
                IloginView.StartDashBoardView();
            }

        }

        public bool AuthenticateUser(string username, string password)
        {

           // Employee employee = new Employee();
           // bool result = Employee.AuthenticateUser(username, password);

           // if(result)          
            //    employee = Employee.FetchEmployeeData();
            
           // CheckUserAuthentication(result);

            return true;
        }

    }
}
