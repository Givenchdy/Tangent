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
using PCL.ViewModel;

namespace FrontEnd.Views
{
    class EmployeeListItemAdapter : BaseAdapter
    {

        LinkedList<EmployeeViewModel> employeeList = new LinkedList<EmployeeViewModel>();
        Context context;

        public EmployeeListItemAdapter(Context context, LinkedList<EmployeeViewModel> employeeList)
        {
            this.employeeList = employeeList;
            this.context = context;
        }

        public override int Count
        {
            get { return employeeList.Count(); }
        }

        public override long GetItemId(int position)
        {
            return employeeList.ElementAt(position).EmployeeID;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            View row = convertView;
            row = LayoutInflater.From(context).Inflate(Resource.Layout.employee_list_item_view, null, false);

            TextView fullNamesText    = (TextView)row.FindViewById(Resource.Id.employeeListItemFullNameID);
            TextView positionNameText = (TextView)row.FindViewById(Resource.Id.employeeListItemPositionID);
            TextView expertLevelText  = (TextView)row.FindViewById(Resource.Id.employeeListItemExpertLevelID);

            fullNamesText.Text = employeeList.ElementAt(position).FullNames();
            positionNameText.Text = employeeList.ElementAt(position).PositionName;
            expertLevelText.Text = employeeList.ElementAt(position).EmployeeLevel;

            return row;
        }


    }
}