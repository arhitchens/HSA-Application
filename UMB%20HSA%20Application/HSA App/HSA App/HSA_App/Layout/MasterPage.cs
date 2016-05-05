using System.Collections.Generic;
using Xamarin.Forms;

namespace HSA_App.Layout
{
	public class MasterPage : ContentPage
	{
		public ListView ListView { get { return listView; } }

		ListView listView;

		public MasterPage()
		{
			var masterPageItems = new List<MasterPageItem>();
			masterPageItems.Add(new MasterPageItem {
				Title = "Account Page",
				IconSource = "contacts.png",
				TargetType = typeof(AccountPage)
			});
			masterPageItems.Add(new MasterPageItem {
				Title = "Pending Claims",
				IconSource = "todo.png",
				TargetType = typeof(PendingClaimsPage)
			});
			masterPageItems.Add(new MasterPageItem {
				Title = "Tax Info",
				IconSource = "reminders.png",
				TargetType = typeof(TaxInfoPage)
			});

			listView = new ListView {
				ItemsSource = masterPageItems,
				ItemTemplate = new DataTemplate(() => {
					var imageCell = new ImageCell();
					imageCell.SetBinding(TextCell.TextProperty, "Title");
					imageCell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
					return imageCell;
				}),
				VerticalOptions = LayoutOptions.FillAndExpand,
//				SeparatorVisibility = SeparatorVisibility.None
			};

			Padding = new Thickness(0, 40, 0, 0);
			Icon = "hamburger.png";
			Title = "Personal Organiser";
			Content = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					listView
				}	
			};
		}
	}
}