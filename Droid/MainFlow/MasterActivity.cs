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
    [Activity(Label = "MasterActivity")]
    public class MasterActivity : Activity
    {
        private ListView UserListView { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.masterView);

            UserListView = FindViewById<ListView>(Resource.Id.master_masterview_userlistview);

            if (null != UserListView)
            {
                LoadData();
            }
        }

        private void LoadData()
        {

            var list = new List<User>
            {
                new User {Name = @"Aa", Description = @"使用者 甲"},
                new User {Name = @"Bb", Description = @"使用者 乙"},
                new User {Name = @"Cc", Description = @"使用者 丙"},
                new User {Name = @"Dd", Description = @"使用者 丁"}
            };

            RunOnUiThread(() => {

                UserListView.Adapter = new UserListAdapter(list, this);

                UserListView.ItemClick += (sender, args) =>
                {
                    User user = list[args.Position];

                    // 推送到下一個 Activity
                    Intent nextActivity = new Intent(this, typeof(DetailActivity));

                    string userjson = Newtonsoft.Json.JsonConvert.SerializeObject(user);

                    nextActivity.PutExtra("UserJson", userjson);
                    StartActivity(nextActivity);
                };
            }
            );

        }

    }
}