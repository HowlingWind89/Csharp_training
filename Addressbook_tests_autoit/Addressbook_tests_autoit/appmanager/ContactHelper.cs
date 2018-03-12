using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook_tests_autoit
{
    public class ContactHelper : HelperBase
    {
        public static string CONTACTWINTITLE = "Contact Editor";
        public ContactHelper(ApplicationManager manager) : base(manager) { }

        internal List<ContactData> GetContactList()
        {
            List<ContactData> list = new List<ContactData>();
            string count = aux.ControlListView(WINTITLE, "", "WindowsForms10.Window.8.app.0.2c908d510",
                "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string itemFullName = aux.ControlListView(WINTITLE, "", "WindowsForms10.Window.8.app.0.2c908d510",
                    "GetText", "#0|#"+i, "First name + Last name");
                list.Add(new ContactData()
                {
                     FirstName = itemFullName
                });
            }
            return list;
        }

        internal void Add(ContactData newContact)
        {
            OpenContactsDialogue();
            aux.ControlSend(CONTACTWINTITLE, "", "WindowsForms10.EDIT.app.0.2c908d516", newContact.FirstName);
            aux.ControlSend(CONTACTWINTITLE, "", "WindowsForms10.EDIT.app.0.2c908d513", newContact.LastName);
            ConfirmContactCreation();
            CloseContactsDialogue();
        }

        private void OpenContactsDialogue()
        {
            aux.WinWait(WINTITLE);
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d58");
            aux.WinWait(CONTACTWINTITLE);
        }

        private void ConfirmContactCreation()
        {
            aux.ControlClick(CONTACTWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d57");
        }
        private void CloseContactsDialogue()
        {
            aux.ControlClick(CONTACTWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d59");
        }
    }
}