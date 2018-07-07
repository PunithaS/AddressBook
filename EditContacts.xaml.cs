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
    public sealed partial class EditContacts : Page
    {
        public Contact contactItem;
       public string hangindId;

        public EditContacts()
        {
            this.InitializeComponent();
        }

        //When clicking Cancel button, user gets navigated to the contact-list page where all contacts are displayed.
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EditNavigationPage));

        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedId = (string)e.Parameter;
            contactItem = await Contact.GetSingleContactsAsync(selectedId);
            Name.Text = contactItem.Name;
            HPhone.Text = contactItem.Hphone;
            WPhone.Text = contactItem.Wphone;
            Email.Text = contactItem.Email;
            Street1.Text = contactItem.Street1;
            Street2.Text = contactItem.Street2;
            City.Text = contactItem.City;
            State.Text = contactItem.State;
            Zip.Text = contactItem.Zip;
            hangindId=contactItem.id;
        }

        //When clicking Save button, a new contact is saved created
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var editedContacts = new Contact
            {
                Name = Name.Text,
                Hphone = HPhone.Text,
                Wphone = WPhone.Text,
                Email = Email.Text,
                Street1 = Street1.Text,
                Street2 = Street2.Text,
                City = City.Text,
                State = State.Text,
                Zip = Zip.Text,
                id=hangindId

            };
                Contact.EditContact(editedContacts);
          //  MainPage.MainPageFrame.Navigate(typeof(Contacts));
            Output.Text = "Contact Successfully Edited!";
        }
    }
}
