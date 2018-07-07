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
    public sealed partial class DisplayContactInfo : Page
    {
        public DisplayContactInfo()
        {
            this.InitializeComponent();
        }
        private void BACK_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Contacts));
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Contact displayContact = (Contact)e.Parameter;

            DisplayName.Text = displayContact.Name;
            HPhone.Text = displayContact.Hphone;
            WPhone.Text = displayContact.Wphone;
            Email.Text = displayContact.Email;
            Street1.Text = displayContact.Street1;
            Street2.Text = displayContact.Street2 + " , " + displayContact.City + " , " + displayContact.State + " , " + displayContact.Zip;
            IsFav.Visibility = Convert.ToBoolean(displayContact.IsFav) ? Visibility.Visible : Visibility.Collapsed;
            DOB.Text = displayContact.DOB.ToString("d");
        }
    }
}
