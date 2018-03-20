using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;


namespace addressbook_tests_white
{
	public class ApplicationManager
	{
		public static string WinTitle = "Free Address Book";
		private GroupHelper groupHelper;

		public ApplicationManager()
		{
			Application app = Application.Launch(@"C:\Program Files (x86)\GAS Softwares\Free Address Book\AddressBook.exe");
			MainWindow = app.GetWindow(WinTitle);

			groupHelper = new GroupHelper(this);
		}

		public void Stop()
		{
			MainWindow.Get<Button>("uxExitAddressButton").Click();
		}

		public Window MainWindow { get; private set; }

		public GroupHelper GroupH
		{
			get 
			{
				return groupHelper;
			}
		}

	}
}
