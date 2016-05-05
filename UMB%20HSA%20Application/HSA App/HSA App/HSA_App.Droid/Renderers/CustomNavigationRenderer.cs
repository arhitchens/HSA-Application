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
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using HSA_App.Droid.Renderers;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationRenderer))]

namespace HSA_App.Droid.Renderers {
	public class CustomNavigationRenderer : NavigationRenderer {
		protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e) {
			base.OnElementChanged(e);

			RemoveAppIconFromActionBar();
			SetActionBarColor();
		}

		void RemoveAppIconFromActionBar() {
			// http://stackoverflow.com/questions/14606294/remove-icon-logo-from-action-bar-on-android
			var actionBar = ((Activity)Context).ActionBar;
			actionBar.SetIcon(new ColorDrawable(Color.Transparent.ToAndroid()));
		}

		void SetActionBarColor() {
			var actionBar = ((Activity)Context).ActionBar;
			actionBar.SetBackgroundDrawable(new ColorDrawable(Color.Green.ToAndroid()));
		}
	}
}