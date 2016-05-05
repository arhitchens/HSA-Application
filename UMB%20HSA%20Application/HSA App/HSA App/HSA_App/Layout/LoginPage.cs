using System;
using Xamarin.Forms;

namespace HSA_App
{
	public class LoginPage : ContentPage
	{
		Entry emailEntry, passwordEntry;
		
		public LoginPage()
		{
			/*Changing Layout.
			var toolbarItem = new ToolbarItem {
				Text = "Sign Up"
			};
			toolbarItem.Clicked += OnSignUpButtonClicked;
			ToolbarItems.Add (toolbarItem);
			*/

			
			emailEntry = new Entry {
				Placeholder = "Enter email"
			};
			passwordEntry = new Entry {
				Placeholder = "Enter Password",
				IsPassword = true
			};

			//Create login and signup buttons.
			var loginButton = new Button {
				Text = "Login"
			};
			loginButton.Clicked += OnLoginButtonClicked;

			//Title = "Login";

			var signUpButton = new Button {
				Text = "Sign Up"
			};
			signUpButton.Clicked += OnSignUpButtonClicked;

			var buttonLayout = new StackLayout {
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {
					loginButton,
					signUpButton,
				}
			};




			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					new Image {
						Source = "drawable/UMB_Logo"
					},
					emailEntry,
					passwordEntry,
					buttonLayout,
				}
			};
		}

		async void OnSignUpButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SignUpPage());
		}

		async void OnLoginButtonClicked(object sender, EventArgs e)
		{
			var user = new User {
				Email = emailEntry.Text,
				Password = passwordEntry.Text
			};

			var isValid = AreCredentialsCorrect(user);
			if (isValid) {
				Application.Current.MainPage = new MainPage();
			} else {
				await DisplayAlert("Login Failed!", "Failed to login to your account!", "Okay");
				//passwordEntry.Text = string.Empty;
			}
		}

		bool AreCredentialsCorrect(User user)
		{
			return user.Email == Constants.Username && user.Password == Constants.Password;
		}
	}
}