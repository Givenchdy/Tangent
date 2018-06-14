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
using PCL.Lookups;

namespace FrontEnd.Views
{
    class RaceFilterDialogFragment : DialogFragment
    {

        [BindView(Resource.Id.okBtnID)]     Button okayButton;
        [BindView(Resource.Id.cancelBtnID)] Button cancelButton;

        [BindView(Resource.Id.raceFilterRadioGroupID)] RadioGroup raceRadioGroup;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.race_filter_dialog_view, container, false);
            Cheeseknife.Bind(this, view);

            okayButton.Click += OnOkayClick;
            cancelButton.Click += OnCancelClick;

            return view;

        }

        protected void OnOkayClick(object sender, EventArgs e)
        {

            string filterValue = null;

            switch(raceRadioGroup.CheckedRadioButtonId)
            {
                case Resource.Id.blackRadioID:
                    filterValue = "B";
                    break;
                case Resource.Id.whiteRadioID:
                    filterValue = "W";
                    break;
                case Resource.Id.indianRadioID:
                    filterValue = "I";
                    break;
                case Resource.Id.colouredRadioID:
                    filterValue = "C";
                    break;
                default:
                    filterValue = "N";
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
            employeeCollectionViewFragment.filter = FilterLookup.Race;
            employeeCollectionViewFragment.filterValue = filterValue;
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.fragmentContainerID, employeeCollectionViewFragment);
            transaction.Commit();
        }

    }
}