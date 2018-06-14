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
using Android.Util;
using FrontEnd.Views;

namespace FrontEnd.Settings
{
    public class SettingsData
    {

        private static string TAG = "SettingsData";
        private static string APP_PREFERENCE_ID = "FrontEnd.Settings.APP_PREFERENCE_ID";
        public static string APP_TOKEN = "FrontEnd.Settings.APP_TOKEN";


        public static string GetAndroidStringFromPreferences(string key)
        {

            string StringData = null;

            try
            {
                Context context = DashBoardView.context;
                ISharedPreferences settings = context.GetSharedPreferences(APP_PREFERENCE_ID, FileCreationMode.Private);
                StringData = settings.GetString(key, null);
            }
            catch (Exception ex)
            {
                Log.Error(TAG, ex.Message);
            }
            return StringData;       
        }


        public static void SetPreferenceKey(string androidKey, string value)
        {

            try
            {
                Context context = DashBoardView.context;
                ISharedPreferences settings = context.GetSharedPreferences(APP_PREFERENCE_ID, FileCreationMode.Private);
                var editor = settings.Edit();
                editor.Remove(androidKey);
                editor.PutString(androidKey, value);
                editor.Commit();
            }
            catch (Exception ex)
            {
                Log.Error(TAG, ex.Message);
            }
        }



    }
}