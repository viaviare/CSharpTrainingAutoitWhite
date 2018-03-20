using System.Collections.Generic;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using System.Windows.Automation;

namespace addressbook_tests_white
{
	public class GroupHelper: HelperBase
	{

		public static string WinGroupEditor = "Group editor";
		Window dialogue;

		public GroupHelper(ApplicationManager manager) : base(manager)
		{ }


		public GroupHelper Add(GroupData group)
		{
			dialogue = OpenGroupDialogue();

			dialogue.Get<Button>("uxNewAddressButton").Click();
			TextBox textBox = (TextBox)dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
			textBox.Enter(group.Name);
			Keyboard.Instance.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.RETURN);
			CloseGroupDialogue(dialogue);
			return this;
		}



		public List<GroupData> GetGroupsList()
		{
			List<GroupData> groups = new List<GroupData>();
			DefineRootArray(out TreeNode root);

			foreach (TreeNode item in root.Nodes)
			{
				groups.Add(new GroupData()
				{
					Name = item.Text
				});
			}

			CloseGroupDialogue(dialogue);
			return groups;
		}

		public void Remove(int index)
		{
			DefineRootArray(out TreeNode root);

			TreeNode removedGroup = root.Nodes[index];
			removedGroup.Select();
			Window deleteGroupDialogue = OpenGroupRemovalConfirmation();
			deleteGroupDialogue.Get<Button>("uxOKAddressButton").Click();
			CloseGroupDialogue(dialogue);
		}

		private Window OpenGroupDialogue()
		{
			manager.MainWindow.Get<Button>("groupButton").Click();
			return manager.MainWindow.ModalWindow(WinGroupEditor);
		}

		private Window OpenGroupRemovalConfirmation()
		{
			dialogue.Get<Button>("uxDeleteAddressButton").Click();
			return dialogue.ModalWindow("Delete group");
		}

		private void CloseGroupDialogue(Window dialogue)
		{
			dialogue.Get<Button>("uxCloseAddressButton").Click();
		}

		private void DefineRootArray(out TreeNode root)
		{
			dialogue = OpenGroupDialogue();
			Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
			root = tree.Nodes[0];
		}

		public int CountGroupItems()
		{
			DefineRootArray(out TreeNode root);

			int count = root.Nodes.Count;
			CloseGroupDialogue(dialogue);
			return count;
		}
	}
}