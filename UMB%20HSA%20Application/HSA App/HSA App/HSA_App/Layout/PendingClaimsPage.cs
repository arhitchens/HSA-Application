using System;
using Xamarin.Forms;

namespace HSA_App {
	public class PendingClaimsPage : ContentPage {
		public PendingClaimsPage() {
			var logOutButton = new ToolbarItem {
				Text = "Logout"
			};
			logOutButton.Clicked += OnLogoutButtonClicked;

			var cameraButton = new ToolbarItem {
				Icon = "@drawable/camera"
			};
			cameraButton.Clicked += OnCameraButtonClicked;

			ToolbarItems.Add(cameraButton);
			ToolbarItems.Add(logOutButton);

			//Title = "Account Page";
			Content = new StackLayout {
				Children = {
					new Label {
						Text = "Account content goes here",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand
					}
				}
			};
		}

		//not necessary as there is no await command within this funciton.
		/*async*/
		void OnLogoutButtonClicked(object sender, EventArgs e) {
			App.IsUserLoggedIn = false;
			Application.Current.MainPage = new NavigationPage(new LoginPage());
		}

		/*async*/
		void OnCameraButtonClicked(object sender, EventArgs e) {
			//			Go to camera
		}
	}
}