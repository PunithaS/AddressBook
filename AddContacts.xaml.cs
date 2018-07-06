using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AddressBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddContacts : Page
    {

        public AddContacts()
        {
            this.InitializeComponent();
        }

        //When clicking Cancel button, user gets navigated to the contact-list page where all contacts are displayed.
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Contacts));

        }

        //When clicking Save button, a new contact is saved created
        private async void Save_Click(object sender, RoutedEventArgs e)
        {

            var contact = new Contact
            {
                id = Guid.NewGuid().ToString(),
                Name = Name.Text,
                Hphone = HPhone.Text,
                Wphone = WPhone.Text,
                Email = Email.Text,
                Street1 = Street1.Text,
                Street2 = Street2.Text,
                City = City.Text,
                State = State.Text,
                Zip = Zip.Text

            };
            //Contact.AppendContact(contacts);

            var collection = await Contact.GetContactsAsync();
            collection.Add(contact);
            Contact.WriteContactCollection(collection);
            Output.Text = "New contact has been added!";
        }
    }
}
