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

namespace huang.Droid.MainFlow
{
    [Activity(Label = "DetailActivity")]
    public class DetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.master_detailview);

            //
            string userjson = Intent.GetStringExtra("UserJson");

            User selectedUser = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(userjson);

            //
            var lbUserName = FindViewById<TextView>(Resource.Id.master_detailview_lbusername);
            var lbUserDescription = FindViewById<TextView>(Resource.Id.master_detailview_lbusedescription);

            //
            if (null != selectedUser)
            {
                lbUserName.Text = selectedUser.Name;
                lbUserDescription.Text = selectedUser.Description;
            }

            var btnWeb = FindViewById<Button>(Resource.Id.master_detailview_btnweb);
            btnWeb.Click += (sender, e) => {

            };

            var btnMap = FindViewById<Button>(Resource.Id.master_detailview_btnmap);
            btnMap.Click += (sender, e) => {

            };

        }

    }
}