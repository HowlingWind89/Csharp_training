using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;
using System.Windows.Automation;

namespace Addressbook_tests_white
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELETEGROUPWINTITLE = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        internal List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }
            CloseGroupsDialogue(dialogue);
            return list;
        }

        internal void Add(GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialogue();
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox TextBox = (TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            TextBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialogue(dialogue);
        }

        private void CloseGroupsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
        }

        private Window OpenGroupsDialogue()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }

        /*internal void ConfirmGroupRemove()
        {
            aux.ControlClick(DELETEGROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
        }
        internal void Remove()
        {
            OpenGroupsDialogue();
            aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", "#0|#", "");
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait(DELETEGROUPWINTITLE);
            ConfirmGroupRemove();
            CloseGroupsDialogue();
        }*/
    }
}