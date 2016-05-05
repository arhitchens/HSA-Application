using System;
using Xamarin.Forms;
using HSA_App.Layout;

namespace HSA_App
{
	public class MainPage : MasterDetailPage
	{
		MasterPage masterPage;

		public MainPage()
		{
			masterPage = new MasterPage();
			Master = masterPage;
			Detail = new NavigationPage(new AccountPage());

			masterPage.ListView.ItemSelected += OnItemSelected;

/*			if (Device.OS == TargetPlatform.Windows) {
				Master.Icon = "swap.png";
			}*/
		}

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MasterPageItem;
			if (item != null) {
				Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
				masterPage.ListView.SelectedItem = null;
				IsPresented = false;
			}
		}
	}
}