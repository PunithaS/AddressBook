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
    public sealed partial class FavContacts : Page
    {
        public ICollection<Contact> FavContactsList;

        public FavContacts()
        {
            this.InitializeComponent();
        }

        private async void Page_Loading(FrameworkElement sender, object args)
        {
            FavContactsList = await Contact.GetFavContactsAsync();
            FavContactsListView.ItemsSource = FavContactsList;

        }

        
        private void FavContactsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Contact selectedContact = (Contact)e.ClickedItem;
            this.Frame.Navigate(typeof(DisplayContactInfo), selectedContact);
        }
    }
}
