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

namespace huang.Droid
{
    public class UserListAdapter : BaseAdapter<User>
    {
        private Activity context;

        private List<User> Users { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XamarinTableView.Droid.MainActivity.UserListAdapter"/> class.
        /// 傳入資料以及負責繪圖的 Context
        /// </summary>
        /// <param name="users">Users.</param>
        /// <param name="context">Context.</param>
        public UserListAdapter(IEnumerable<User> users, Activity context)
        {
            this.context = context;

            Users = new List<User>();
            Users.AddRange(users);
        }

        /// <summary>
        /// 讓作業系統了解需要準備多少記憶體
        /// </summary>
        /// <value>資料筆數</value>
        public override int Count => Users.Count;

        /// <summary>
        /// 在資料列順序與顯示順序不同時，這邊要做處理。
        /// 
        /// </summary>
        /// <returns>The item identifier.</returns>
        /// <param name="position">Position.</param>
        public override long GetItemId(int position)
        {
            return position;
        }

        /// <summary>
        /// 回傳 UI 
        /// </summary>
        /// <returns>The view.</returns>
        /// <param name="position">Position.</param>
        /// <param name="convertView">Convert view.</param>
        /// <param name="parent">Parent.</param>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {


            // UI Binding
            var view = convertView;

            if (null == view)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.master_masterview_useritemview, parent, false);

            }

            // Data Binding
            User user = Users[position];

            view.FindViewById<TextView>(Resource.Id.master_masterview_useritemview_lbname).Text = user.Name;
            view.FindViewById<TextView>(Resource.Id.master_masterview_useritemview_lbdescription).Text = user.Description;

            return view;
        }


        /// <summary>
        /// Gets the <see cref="T:XamarinTableView.Droid.MainActivity.UserListAdapter"/> with the specified position.
        /// </summary>
        /// <param name="position">Position.</param>
        public override User this[int position] => Users[position];
    }
}