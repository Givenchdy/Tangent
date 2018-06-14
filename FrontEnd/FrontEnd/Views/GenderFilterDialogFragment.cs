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
using PCL.Lookups;
using CheeseBind;

namespace FrontEnd.Views
{
    class GenderFilterDialogFragment : DialogFragment
    {

        [BindView(Resource.Id.okBtnID)] Button okayButton;
        [BindView(Resource.Id.cancelBtnID)] Button cancelButton;

        [BindView(Resource.Id.genderFilterRadioGroupID)] RadioGroup genderRadioGroup;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.gender_filter_dialog_view, container, false);
            Cheeseknife.Bind(this, view);

            okayButton.Click += OnOkayClick;
            cancelButton.Click += OnCancelClick;

            return view;

        }

        protected void OnOkayClick(object sender, EventArgs e)
        {

            string filterValue = null;

            switch (genderRadioGroup.CheckedRadioButtonId)
            {
                case Resource.Id.maleRadioID:
                    filterValue = "M";
                    break;
                case Resource.Id.femaleRadioID:
                    filterValue = "F";
                    break;
            }


            ShowEmployeeCollectionView(filterValue);

            Dismiss();
        }

        protected void OnCancelClick(object sender, EventArgs e)
        {
            Dismiss();
        }

        public void ShowEmployeeCollectionView(string filterValue)
        {
            EmployeeCollectionFragment employeeCollectionViewFragment = new EmployeeCollectionFragment();
            employeeCollectionViewFragment.filter = FilterLookup.Gender;
            employeeCollectionViewFragment.filterValue = filterValue;
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.fragmentContainerID, employeeCollectionViewFragment);
            transaction.Commit();
        }

    }
}