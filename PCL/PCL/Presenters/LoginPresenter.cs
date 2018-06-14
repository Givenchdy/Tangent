using CloudSdk.Model;
using PCL.ViewInterfaces;

namespace PCL.Presenters
{
    public class LoginPresenter
    {
        ILoginView IloginView;

        public void Initialize(ILoginView IloginView, string tokenKey)
        {
            this.IloginView = IloginView;

            if(tokenKey != null)
               CheckUserAuthentication(true);
            else
                CheckUserAuthentication(false);

        }

        public void CheckUserAuthentication(bool loginStatus)
        {
            if(loginStatus)
            {
                IloginView.StartDashBoardView();
            }

        }

        public string AuthenticateUser(string username, string password)
        {

            Employee employee = new Employee();
            string result = Employee.AuthenticateUser(username, password);

            if(result != null)          
                employee = Employee.FetchEmployeeData();
            
            CheckUserAuthentication(true);

            return result;
        }

    }
}
