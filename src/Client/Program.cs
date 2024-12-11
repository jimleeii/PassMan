namespace Client;

/// <summary>
/// The program.
/// </summary>
internal static class Program
{
	/// <summary>
	///  The main entry point for the application.
	/// </summary>
	[STAThread]
	private static async Task Main()
	{
		// Initialize the AppSession
		await AppSession.Initialize();

		// To customize application configuration such as set high DPI settings or default font,
		// see https://aka.ms/applicationconfiguration.
		ApplicationConfiguration.Initialize();
		Application.Run(new MainForm());
	}
}