using System.Threading.Tasks;

namespace XForms.Utils.Notifications
{
	public interface IDialogService
	{
		/// <summary>
		/// Presents an alert dialog to the application user with a single cancel button.
		/// </summary>
		/// <para>
		/// The <paramref name="message"/> can be empty.
		/// </para>
		/// <param name="title">Title to display.</param>
		/// <param name="message">Message to display.</param>
		/// <param name="cancelButton">Text for the cancel button.</param>
		/// <returns></returns>
		Task AlertAsync(string title, string message, string cancelButton = "Cancel");

		/// <summary>
		/// Presents an confirm dialog to the application user with an accept and a cancel button.
		/// </summary>
		/// <para>
		/// The <paramref name="message"/> can be empty.
		/// </para>
		/// <param name="title">Title to display.</param>
		/// <param name="message">Message to display.</param>
		/// <param name="acceptButton">Text for the accept button.</param>
		/// <param name="cancelButton">Text for the cancel button.</param>
		/// <returns><c>true</c> if non-destructive button pressed; otherwise <c>false</c>/></returns>
		Task<bool> ConfirmAsync(string title, string message, string acceptButton = "Yes", string cancelButton = "No");
	}
}
