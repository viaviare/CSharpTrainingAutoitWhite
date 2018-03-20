using System.Collections.Generic;
using NUnit.Framework;
using System;

namespace addressbook_tests_white
{
	[TestFixture]
	public class GroupRemovalTests : TestBase
	{
		[Test]
		public void GroupRemovalTest()
		{
			int index = 0;
			if (app.GroupH.CountGroupItems() == 1)
			{
				GroupData tempData = new GroupData()
				{
					Name = "zzRR"
				};
				List<GroupData> checkGroupName = app.GroupH.GetGroupsList();
				app.GroupH.Add(tempData);
				string nameGroup = checkGroupName[0].Name;
				if (Convert.ToChar(nameGroup.Substring(0,1))<
					Convert.ToChar(tempData.Name.Substring(0,1)))
				{
					index = 1;
				}
			}

			
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
