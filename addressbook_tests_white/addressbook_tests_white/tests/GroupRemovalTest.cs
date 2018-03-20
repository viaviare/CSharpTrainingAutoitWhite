using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_white
{
	[TestFixture]
	public class GroupRemovalTests : TestBase
	{
		[Test]
		public void GroupRemovalTest()
		{

			if (app.GroupH.CountGroupItems() == 0)
			{
				GroupData tempData = new GroupData()
				{
					Name = "vvRR"
				};
				app.GroupH.Add(tempData);
			}
			int index = 0;
			List<GroupData> oldGroups = app.GroupH.GetGroupsList();
			app.GroupH.Remove(index);
			oldGroups.RemoveAt(index);
			List<GroupData> newGroups = app.GroupH.GetGroupsList();
			oldGroups.Sort();
			newGroups.Sort();
			Assert.AreEqual(oldGroups, newGroups);
		}
	}
}
