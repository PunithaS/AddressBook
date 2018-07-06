/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace AddressBook
{
    public class ContactManager
    {
        const string TEXT_FILE_NAME = "ContactsTextFile.txt";

        public async static Task<ICollection<Contact>> GetContacts()
        {
            var contacts = new List<Contact>();

            var folder = ApplicationData.Current.LocalFolder;
            var contactFile = await folder.GetFileAsync(TEXT_FILE_NAME);
            var lines = await FileIO.ReadLinesAsync(contactFile);

            foreach (var line in lines)
            {
              //  var contactData = line.Split(',');
               // var contact = new Contact();
                //contactData[0], contactData[1], contactData[2], contactData[3]
                //contacts.Add(contact);
            }
            return contacts;
        }


    }
}*/
