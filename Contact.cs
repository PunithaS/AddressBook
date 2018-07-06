using System;
using System.Collections.Generic;
using System.IO;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.Collections.ObjectModel;


namespace AddressBook
{
    public class Contact
    {
        const string TEXT_FILE = "ContactsTextFile.txt";
        public string id { get; set; }
        public string Name { get; set; }
        public string Hphone { get; set; }
        public string Wphone { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string IsFav { get; set; }
        
        //public static Contact GetContacts()
        //{
        //    var cdetails = new Contact
        //    {
        //        Name = "aaa",
        //        Hphone = "3434",
        //        Wphone = "3453455678",
        //        Email = "punitha.mad@gmail.com",
        //        Street1 = "asd",
        //        Street2 = "asdf",
        //        City = "sammamish",
        //        State = "wa",
        //        Zip = "34343"
        //    };
        //    return cdetails;
        //}

        public static async Task<ObservableCollection<Contact>> GetContactsAsync()
        {
            var contactsList = new ObservableCollection<Contact>();
            StorageFolder folder = ApplicationData.Current.LocalFolder;

            try
            {
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
                        Zip = contactsData[8],
                        id = contactsData[9],
                        IsFav = contactsData[10]

                    };
                    contactsList.Add(contact);
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                ///ignore exception and return empty list
                contactsList.Clear();
            }
            return contactsList;

        }

        public static async Task<Contact> GetSingleContactsAsync(string id)
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile contactFile = await folder.GetFileAsync(TEXT_FILE);
            var lines = await FileIO.ReadLinesAsync(contactFile);
            var contact = new Contact();
            foreach (var line in lines)
            {
                var contactsData = line.Split(';');
                if (contactsData[9] == id)
                {

                    contact.Name = contactsData[0];
                    contact.Hphone = contactsData[1];
                    contact.Wphone = contactsData[2];
                    contact.Email = contactsData[3];
                    contact.Street1 = contactsData[4];
                    contact.Street2 = contactsData[5];
                    contact.City = contactsData[6];
                    contact.State = contactsData[7];
                    contact.Zip = contactsData[8];
                    contact.id = contactsData[9];
                    contact.IsFav = contactsData[10];
                }
            }
            return contact;
        }

        public async static void WriteContact(Contact contacts)
        {
            var contactData = $"{contacts.Name};{contacts.Hphone};" +
                $"{contacts.Wphone};{contacts.Email};{contacts.Street1};" +
                $"{contacts.Street2};{contacts.City};{contacts.State};{contacts.Zip};{contacts.id};{contacts.IsFav}";
            await FileHelper.WriteTextFile(TEXT_FILE, contactData);
        }

        public async static void AppendContact(Contact contacts)
        {
            var contactData = $"{contacts.Name};{contacts.Hphone};" +
                $"{contacts.Wphone};{contacts.Email};{contacts.Street1};" +
                $"{contacts.Street2};{contacts.City};{contacts.State};{contacts.Zip};{contacts.id};{contacts.IsFav}";
            await FileHelper.AppendTextFile(TEXT_FILE, contactData);
        }

        public async static void EditContact(Contact editedContacts)
        {
            var updatedLines = new List<String>();
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile contactFile = await folder.GetFileAsync(TEXT_FILE);
            IList<string> originalLines = File.ReadAllLines(contactFile.Path);
            var contact = new Contact();
            foreach (var line in originalLines)
            {
                string[] oldContactsDataPerLine = line.Split(';');
               
                    if (oldContactsDataPerLine[9] == editedContacts.id)
                    //   if(oldContactsDataPerLine[9].CompareTo(editedContacts.id)==0)
                    {
                        oldContactsDataPerLine[0] = editedContacts.Name;
                    oldContactsDataPerLine[1] = editedContacts.Hphone;
                    oldContactsDataPerLine[2] = editedContacts.Wphone;
                    oldContactsDataPerLine[3] = editedContacts.Email;
                    oldContactsDataPerLine[4] = editedContacts.Street1;
                    oldContactsDataPerLine[5] = editedContacts.Street2;
                    oldContactsDataPerLine[6] = editedContacts.City;
                    oldContactsDataPerLine[7] = editedContacts.State;
                    oldContactsDataPerLine[8] = editedContacts.Zip;
                }
                updatedLines.Add(string.Join(";", oldContactsDataPerLine));
            }
            File.WriteAllLines(contactFile.Path, updatedLines.ToArray());
        }

        public async static void WriteContactCollection(ICollection<Contact> contactcollection)
        {
            string contactsData = string.Empty;
            foreach (var contact in contactcollection)
            {
                contactsData += $"{contact.Name};{contact.Hphone};{contact.Wphone};" +
                    $"{contact.Email};{contact.Street1};{contact.Street1};" +
                    $"{contact.City};{contact.State};{contact.Zip};{contact.id};{contact.IsFav}" + Environment.NewLine;
            }

            await FileHelper.CreateTextFile(TEXT_FILE, contactsData);
        }

        public static async Task<ICollection<Contact>> GetFavContactsAsync()
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile contactFile = await folder.GetFileAsync(TEXT_FILE);
            var lines = await FileIO.ReadLinesAsync(contactFile);
            var favContactsList = new List<Contact>();
            foreach (var line in lines)
            {
                var contactsData = line.Split(';');

                if (contactsData[10] == "True")
                {
                    var favContact = new Contact
                    {
                        Name = contactsData[0],
                        Hphone = contactsData[1],
                        Wphone = contactsData[2],
                        Email = contactsData[3],
                        Street1 = contactsData[4],
                        Street2 = contactsData[5],
                        City = contactsData[6],
                        State = contactsData[7],
                        Zip = contactsData[8],
                        id = contactsData[9],
                        IsFav = contactsData[10]
                    };
                    favContactsList.Add(favContact);
                }
            }
            return favContactsList;
        }

    }
}
