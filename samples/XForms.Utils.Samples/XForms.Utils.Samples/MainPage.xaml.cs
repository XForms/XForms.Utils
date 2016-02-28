using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XForms.Utils.Notifications;

namespace XForms.Utils.Samples
{
	public partial class MainPage : ContentPage
	{
		private IDialogService _dialogService;

		public MainPage()
		{
			InitializeComponent();

			_dialogService = new DialogService();
		}

		private async void ShowAlertClicked(object sender, EventArgs e)
		{
			await _dialogService.AlertAsync("Alert title", "alert content");
		}

		private async void ShowConfirmClicked(object sender, EventArgs e)
		{
			var isYes = await _dialogService.ConfirmAsync("Confirm?", "content");
			if (isYes)
			{
				await _dialogService.AlertAsync("", "Yes");
			}
		}
	}
}
