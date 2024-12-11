using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Client;

/// <summary>
/// The main form.
/// </summary>
public partial class MainForm : Form
{
	/// <summary>
	/// Initializes a new instance of the <see cref="MainForm"/> class.
	/// </summary>
	public MainForm()
	{
		InitializeComponent();

		buttonUpdate.Enabled = false;
		buttonShow.Enabled = false;
	}

	/// <summary>
	/// Main form load.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The E.</param>
	private async void MainForm_LoadAsync(object sender, EventArgs e)
	{
		if (AppSession.Context is null)
		{
			ShowError("Database connection failed.");
			return;
		}

		await LoadPasswordsAsync();
	}

	/// <summary>
	/// Button add click.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The E.</param>
	private async void ButtonAdd_ClickAsync(object sender, EventArgs e)
	{
		if (AppSession.Key is null)
		{
			ShowError("Key initialization failed.");
			return;
		}

		if (AppSession.Context is null)
		{
			ShowError("Database connection failed.");
			return;
		}

		if (string.IsNullOrWhiteSpace(textBoxHost.Text) || string.IsNullOrWhiteSpace(textBoxUser.Text) || string.IsNullOrWhiteSpace(textBoxPasscode.Text))
		{
			ShowError("Inputs cannot be empty.");
			return;
		}

		try
		{
			Secret? secret = await GetSecretAsync();
			if (secret == null)
			{
				ShowError("Secret not found.");
				return;
			}

			// Get the ApiUrl from the app.config file
			string? apiUrl = ConfigurationManager.AppSettings["ApiUrl"];

			if (string.IsNullOrEmpty(apiUrl))
			{
				throw new MissingConfigurationException("ApiUrl is not set in the app.config file.");
			}

			// Get the key from the web API
			var payload = new Parcel { Text = textBoxPasscode.Text, Key = secret.Key };
			var webApiService = new WebApiService();
			var (Response, Success) = await webApiService.PostAsync<Parcel>($"{apiUrl}/api/EncryptText", payload);
			if (!Success || Response is null)
			{
				ShowError("Failed to encrypt passcode.");
				return;
			}

			var password = new Password { SecretId = secret.Id, Host = textBoxHost.Text, User = textBoxUser.Text, Passcode = Response! };
			await AppSession.Context.Passwords.AddAsync(password);
			await AppSession.Context.SaveChangesAsync();
			await LoadPasswordsAsync();
		}
		catch (Exception ex)
		{
			ShowError(ex.Message);
		}
	}

	/// <summary>
	/// Button update click.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The E.</param>
	private async void ButtonUpdate_ClickAsync(object sender, EventArgs e)
	{
		if (dataGridViewPass.SelectedRows.Count == 0)
		{
			ShowError("No record selected.");
			return;
		}

		try
		{
			var selectedRow = dataGridViewPass.SelectedRows[0];
			var id = (Guid)selectedRow.Cells["Id"].Value!;
			var password = await AppSession.Context!.Passwords.FindAsync(id);

			if (password is null)
			{
				ShowError("Password not found.");
				return;
			}

			if (MessageBox.Show($"Update passcode for user: {password.User}?") == DialogResult.OK)
			{
				password.Passcode = textBoxPasscode.Text;

				Secret? secret = await GetSecretAsync();

				if (secret == null)
				{
					ShowError("Secret not found.");
					return;
				}

				password.SecretId = secret.Id;

				// Get the ApiUrl from the app.config file
				string? apiUrl = ConfigurationManager.AppSettings["ApiUrl"];

				if (string.IsNullOrEmpty(apiUrl))
				{
					throw new MissingConfigurationException("ApiUrl is not set in the app.config file.");
				}

				// Get the key from the web API
				var payload = new Parcel { Text = password.Passcode, Key = AppSession.Key! };
				var webApiService = new WebApiService();
				var (Response, Success) = await webApiService.PostAsync<Parcel>($"{apiUrl}/api/EncryptText", payload);
				if (!Success || Response is null)
				{
					ShowError("Failed to encrypt passcode.");
					return;
				}

				await AppSession.Context.SaveChangesAsync();
				await LoadPasswordsAsync();
			}
		}
		catch (Exception ex)
		{
			ShowError(ex.Message);
		}
	}

	/// <summary>
	/// Handles the click event of the button show.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The E.</param>
	private async void ButtonShow_ClickAsync(object sender, EventArgs e)
	{
		if (AppSession.Context is null)
		{
			ShowError("Database connection failed.");
			return;
		}

		bool hasSelection = dataGridViewPass.SelectedRows.Count > 0;
		buttonUpdate.Enabled = hasSelection;
		buttonShow.Enabled = hasSelection;

		if (!hasSelection)
		{
			ShowError("No record selected.");
			return;
		}

		try
		{
			var selectedRow = dataGridViewPass.SelectedRows[0];
			var id = (Guid)selectedRow.Cells["Id"].Value!;
			var password = await AppSession.Context.Passwords.FindAsync(id);

			if (password is null)
			{
				ShowError("Password not found.");
				return;
			}

			Secret? secret = await GetSecretByIdAsync(password.SecretId);
			if (secret is null)
			{
				ShowError("Secret not found.");
				return;
			}

			string? apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
			if (string.IsNullOrEmpty(apiUrl))
			{
				throw new MissingConfigurationException("ApiUrl is not set in the app.config file.");
			}

			var payload = new Parcel { Text = password.Passcode, Key = secret.Key };
			var webApiService = new WebApiService();
			var (Response, Success) = await webApiService.PostAsync<Parcel>($"{apiUrl}/api/DecryptText", payload);
			if (!Success || Response is null)
			{
				ShowError("Failed to decrypt passcode.");
				return;
			}

			var dialogResult = MessageBox.Show(this, $"Decrypted Passcode: {Response}", "Decrypted Passcode", MessageBoxButtons.OK, MessageBoxIcon.Information);
			if (dialogResult == DialogResult.OK)
			{
				Copy(Response);
			}
		}
		catch (Exception ex)
		{
			ShowError(ex.Message);
		}
	}

	/// <summary>
	/// Handles the selection changed event of the data grid view of passwords.
	/// Enables/disables the update and show buttons based on whether a row is selected.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The E.</param>
	private async void DataGridViewPass_SelectionChangedAsync(object sender, EventArgs e)
	{
		bool hasSelection = dataGridViewPass.SelectedRows.Count > 0;
		buttonUpdate.Enabled = hasSelection;
		buttonShow.Enabled = hasSelection;

		if (hasSelection)
		{
			try
			{
				var selectedRow = dataGridViewPass.SelectedRows[0];
				var id = (Guid)selectedRow.Cells["Id"].Value!;
				var password = await AppSession.Context!.Passwords.FindAsync(id);

				if (password is null)
				{
					ShowError("Password not found.");
					return;
				}

				textBoxHost.Text = password.Host ?? string.Empty;
				textBoxUser.Text = password.User ?? string.Empty;
				textBoxPasscode.Text = password.Passcode ?? string.Empty;
			}
			catch (Exception ex)
			{
				ShowError(ex.Message);
			}
		}
	}

	/// <summary>
	/// Get the secret.
	/// </summary>
	/// <returns>A Task of type Secret?</returns>
	private static async Task<Secret?> GetSecretAsync()
	{
		if (AppSession.Key is null || AppSession.Context is null)
		{
			return null;
		}

		try
		{
			var secret = await AppSession.Context.Secrets.FirstOrDefaultAsync(s => AppSession.Key == s.Key);
			if (secret == null)
			{
				secret = new Secret { Key = AppSession.Key! };
				await AppSession.Context.Secrets.AddAsync(secret);
				await AppSession.Context.SaveChangesAsync();
			}

			return secret;
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException("Error getting secret.", ex);
		}
	}

	/// <summary>
	/// Get the secret by id.
	/// </summary>
	/// <param name="id">The id.</param>
	/// <returns>A Task of type Secret?</returns>
	private static async Task<Secret?> GetSecretByIdAsync(Guid id)
	{
		if (AppSession.Context is null)
		{
			throw new InvalidOperationException("AppSession.Context is null.");
		}

		try
		{
			var secret = await AppSession.Context.Secrets.FirstOrDefaultAsync(s => id == s.Id);
			return secret;
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException("Error getting secret by id.", ex);
		}
	}

	/// <summary>
	/// Load passwords into the DataGridView.
	/// </summary>
	private async Task LoadPasswordsAsync()
	{
		if (AppSession.Context is null)
		{
			ShowError("Database context is not initialized.");
			return;
		}

		try
		{
			var data = await AppSession.Context.Passwords.ToListAsync();
			if (data is null || data.Count == 0)
			{
				ShowWarning("No password data available.");
			}

			dataGridViewPass.DataSource = data;
		}
		catch (Exception ex)
		{
			ShowError($"Error loading passwords: {ex.Message}");
		}
	}

	/// <summary>
	/// Copies the specified text to the clipboard.
	/// </summary>
	/// <param name="text">The text to be copied to the clipboard.</param>
	/// <returns>A Task representing the asynchronous operation.</returns>
	private static void Copy(string? text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			throw new ArgumentNullException(nameof(text), "The text to be copied to the clipboard cannot be null or empty.");
		}

		try
		{
			Thread thread = new(() => Clipboard.SetText(text));
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			thread.Join();
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException("An error occurred while copying the text to the clipboard.", ex);
		}
	}


	/// <summary>
	/// Show an error message.
	/// </summary>
	/// <param name="message">The error message.</param>
	private void ShowError(string message)
	{
		MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}

	/// <summary>
	/// Show a warning message.
	/// </summary>
	/// <param name="message">The warning message.</param>
	private void ShowWarning(string message)
	{
		MessageBox.Show(this, message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
	}
}