using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_white
{
	[TestFixture]
	public class GroupCreationTests : TestBase
	{
		[Test]
		public void GroupCreationTest()
		{
			List<GroupData> oldGroups = app.GroupH.GetGroupsList();

			GroupData groupItem = new GroupData()
			{
				Name = "ABzAB"
			};
			app.GroupH.Add(groupItem);
			oldGroups.Add(groupItem);
			List<GroupData> newGroups = app.GroupH.GetGroupsList();
			oldGroups.Sort();
			newGroups.Sort();
			Assert.AreEqual(oldGroups, newGroups);

		}
	}
}
