using System;
using System.Linq;
using Xamarin.Forms;

namespace HSA_App
{
	public class SignUpPage : ContentPage
	{
		Entry emailEntry, passwordEntry;
		
		public SignUpPage()
		{
			emailEntry = new Entry {
				Placeholder = "Enter email"
			};
			passwordEntry = new Entry {
				Placeholder = "Enter Password",
				IsPassword = true
			};

			var signUpButton = new Button {
				Text = "Sign Up"
			};
			signUpButton.Clicked += OnSignUpButtonClicked;

			//Title = "Sign Up";


			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(0, 40, 0, 0),
				Children = {
					emailEntry,
					passwordEntry,
					signUpButton,
					
				}
			};
		}

		async void OnSignUpButtonClicked(object sender, EventArgs e)
		{
			var user = new User() {
				Email = emailEntry.Text,
				Password = passwordEntry.Text
				
			};

			// Sign up logic goes here

			var signUpSucceeded = AreDetailsValid(user);
			if (signUpSucceeded) {
				var rootPage = Navigation.NavigationStack.FirstOrDefault();
				if (rootPage != null) {
					Application.Current.MainPage = new MainPage();
				}
			} else {
				await DisplayAlert("Login Failed!", "Failed to login to your account!", "Okay");
			}
		}

		bool AreDetailsValid(User user)
		{
			return (!string.IsNullOrWhiteSpace(user.Email) && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@"));
		}
	}
}