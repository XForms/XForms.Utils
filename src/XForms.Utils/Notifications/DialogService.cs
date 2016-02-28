using System.Threading.Tasks;
using Xamarin.Forms;

namespace XForms.Utils.Notifications
{
	public class DialogService : IDialogService
	{
		public virtual async Task AlertAsync(string title, string message, string cancelButton = "Cancel")
		{
			await Application.Current.MainPage.DisplayAlert(title, message, cancelButton);
		}

		public virtual async Task<bool> ConfirmAsync(string title, string message, string acceptButton = "Yes", string cancelButton = "No")
		{
			return await Application.Current.MainPage.DisplayAlert(title, message, acceptButton, cancelButton);
		}
	}
}
