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
using AddressBook;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AddressBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Contacts : Page
    {
        public ObservableCollection<Contact> ContactsList;

        public Contacts()
        {
            this.InitializeComponent();
        }

        // To load contacts in a list view, we can call the function GetContactsAsync() when the event PageLoading is occuring

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            ContactsList = await Contact.GetContactsAsync();
            ContactsListView.ItemsSource = ContactsList;
        }

        private void ContactsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Contact selectedContact = (Contact)e.ClickedItem;
            //Selected.Text = selectedContact.Name;
            //MainPage.MainPageFrame.Navigate(typeof(EditContacts), selectedContact.Name);
            this.Frame.Navigate(typeof(DisplayContactInfo), selectedContact);
        }
        
      /*  private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var index = ContactsListView.SelectedIndex;

            if (index >= 0)
            {
                var deleteConfirmationDialog = new DeleteConfirmationDialog();
                ContentDialogResult result = await deleteConfirmationDialog.ShowAsync();

                /// Delete the contact if the user clicked the primary button.
                /// Otherwise, do nothing.
                if (result == ContentDialogResult.Primary)
                {
                    /// Delete the contact.
                    ContactsList.RemoveAt(ContactsListView.SelectedIndex);
                    Contact.WriteContactCollection(ContactsList);
                }
                else
                {
                    /// The user clicked the Cancel Button, pressed ESC, Gamepad B, or the system back button.
                    /// Do nothing.
                }
            }
        }
    
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Contact selectedContact = ContactsListView.SelectedItem as Contact;
            // Selected.Text = selectedContact.Name;
            MainPage.MainPageFrame.Navigate(typeof(EditContacts), selectedContact.id);
        }*/
    }
}
