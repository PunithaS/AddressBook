using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace AddressBook
{
    public class Contact
    {
        const string TEXT_FILE = "ContactsTextFile.txt";
        public string Name { get; set; }
        public string Hphone { get; set; }
        public string Wphone { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public static Contact GetContacts()
        {
            var cdetails = new Contact
            {
                Name = "aaa",
                Hphone = "3434",
                Wphone = "3453455678",
                Email = "punitha.mad@gmail.com",
                Street1 = "asd",
                Street2 = "asdf",
                City = "sammamish",
                State = "wa",
                Zip = "34343"
            };
            return cdetails;
        }

        public static async Task<ICollection<Contact>> GetContactsAsync()
        {
            var contactsList = new List<Contact>();
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            var contactFile = await folder.GetFileAsync(TEXT_FILE);
            var lines = await FileIO.ReadLinesAsync(contactFile);
            foreach (var line in lines)
            {
                var contactsData = line.Split(';');
                var contact = new Contact
                {
                    Name = contactsData[0],
                    Hphone = contactsData[1],
                    Wphone = contactsData[2],
                    Email = contactsData[3],
                    Street1 = contactsData[4],
                    Street2 = contactsData[5],
                    City = contactsData[6],
                    State = contactsData[7],
                    Zip = contactsData[8]

                };
                contactsList.Add(contact);
            }
            return contactsList;
        }

        public async static void WriteContact(Contact contacts)
        {
            var contactData = $"{contacts.Name};{contacts.Hphone};" +
                $"{contacts.Wphone};{contacts.Email};{contacts.Street1};" +
                $"{contacts.Street2},{contacts.City};{contacts.State};{contacts.Zip}";
            await FileHelper.WriteTextFile(TEXT_FILE, contactData);
        }

        public async static void AppendContact(Contact contacts)
        {
            var contactData = $"{contacts.Name};{contacts.Hphone};" +
                $"{contacts.Wphone};{contacts.Email};{contacts.Street1};" +
                $"{contacts.Street2},{contacts.City};{contacts.State};{contacts.Zip}";
            await FileHelper.AppendTextFile(TEXT_FILE, contactData);
        }
    }
}
