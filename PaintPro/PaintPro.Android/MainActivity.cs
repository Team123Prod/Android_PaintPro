using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace PaintPro.Droid
{
	[Activity (Label = "PaintPro.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        ImageButton btnMenuLeft;
        ImageButton btnImageAddTab;
        ImageButton btnImageSave;
        ImageButton btnImageLoad;
        ImageButton btnImageSetting;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            SetSpinnersListeners();

            btnMenuLeft = FindViewById<ImageButton>(Resource.Id.imageButtonLeftMenu);
            btnMenuLeft.Click += btnMenuLeft_Click;
            btnImageAddTab = FindViewById<ImageButton>(Resource.Id.btnImageAddTab);
            btnImageAddTab.Click += btnImageAddTab_Click;
            btnImageSave = FindViewById<ImageButton>(Resource.Id.btnImageSave);
            btnImageSave.Click += btnImageSave_Click;
            btnImageLoad = FindViewById<ImageButton>(Resource.Id.btnImageLoad);
            btnImageLoad.Click += btnImageLoad_Click;
            btnImageSetting = FindViewById<ImageButton>(Resource.Id.btnImageSetting);
            btnImageSetting.Click += btnImageSetting_Click;
        }
        private void SetSpinnersListeners()
        {
            Spinner spPlugins = FindViewById<Spinner>(Resource.Id.spPlugins);

            var adapterP = ArrayAdapter.CreateFromResource(this, Resource.Array.plugins_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapterP.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spPlugins.Adapter = adapterP;

            spPlugins.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            if (spinner.Id == Resource.Id.spPlugins)
            {
                switch (spinner.SelectedItem.ToString())
                {
                    case "Empty figure":
                        Toast.MakeText(this, string.Format("Empty figure"), ToastLength.Short).Show();
                        break;
                    case "Figure with text":
                        Toast.MakeText(this, string.Format("Figure with text"), ToastLength.Short).Show();
                        break;
                    case "Figure with image":
                        Toast.MakeText(this, string.Format("Figure with image"), ToastLength.Short).Show();
                        break;
                }
            }
        }
        private void btnImageAddTab_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, string.Format("Btn Add Tab"), ToastLength.Short).Show();
        }

        private void btnImageSave_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, string.Format("Btn Save"), ToastLength.Short).Show();
        }

        private void btnImageLoad_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, string.Format("Btn Load"), ToastLength.Short).Show();
        }

        private void btnImageSetting_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, string.Format("Btn Settings"), ToastLength.Short).Show();
        }

        private void btnMenuLeft_Click(object sender, EventArgs e)
        {
            PopupMenu menu = new PopupMenu(this, btnMenuLeft);
            menu.MenuInflater.Inflate(Resource.Layout.popup_menu, menu.Menu);

            menu.MenuItemClick += (s, arg) =>
            {
                Toast.MakeText(this, string.Format("Menu {0} clicked", arg.Item.TitleFormatted), ToastLength.Short).Show();

            };

            menu.DismissEvent += (s, arg) => {
                Toast.MakeText(this, string.Format("Menu dissmissed"), ToastLength.Short).Show();

            };

            menu.Show();
        }
    }
    
}


