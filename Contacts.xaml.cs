﻿using System;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AddressBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Contacts : Page
    {
        public ICollection<Contact> ContactsList;

        public Contacts()
        {
            this.InitializeComponent();
            //ContactsList = Contact.GetContactsAsync();

            ///Asynchronous function GetContactsAsync() 
            ///cannot be called here as a constructor function cannot be async
            ///so to load contacts in a list view, we can call the function GetContactsAsync()
            ///when the event PageLoading is occuring
        }

       private async void Page_Loading(FrameworkElement sender, object args)
       {
          ContactsList = await Contact.GetContactsAsync();
         ContactsListView.ItemsSource = ContactsList;
       }

        private void ContactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ListViewItem lbi = ((sender as ListBox).SelectedItem as ListViewItem);
            //Selected.Text = "   You selected " + lbi.Content.ToString() + ".";

        }

        private void ContactsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Contact selectedContact = (Contact)e.ClickedItem;
           // Selected.Text = selectedContact.Name;
            MainPage.MainPageFrame.Navigate(typeof(EditContacts),selectedContact.id);
        }
    }
}
