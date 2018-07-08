using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
            if (Name.Text.Length == 0 && HPhone.Text.Length == 0 && WPhone.Text.Length == 0 && Email.Text.Length == 0 && Street1.Text.Length == 0 && City.Text.Length == 0 && Zip.Text.Length == 0)
            {
                Output.Text = "Fill out the missing information!";
            }
            else
            {
                string x = HPhone.Text;
                string y = WPhone.Text;
                string z = Zip.Text;
                var isNumericX = !string.IsNullOrEmpty(x) && x.All(Char.IsDigit);
                var isNumericY = !string.IsNullOrEmpty(y) && y.All(Char.IsDigit);
                var isNumericZ = !string.IsNullOrEmpty(z) && z.All(Char.IsDigit);
                if (!isNumericX)
                {
                    Output.Text = "Invalid personal phone number. Please enter a valid number";
                }else if (!isNumericY)
                {
                    Output.Text = "Invalid work phone number. Please enter a valid number";
                }else if (!isNumericZ)
                {
                    Output.Text = "Invalid zipcode number. Please enter a valid number";
                }
                else
                {
                    var contacts = new Contact
                    {
                        id = Guid.NewGuid().ToString(),
                        Name = Name.Text,
                        Hphone = HPhone.Text,
                        Wphone = WPhone.Text,
                        DOB = DOB.Date.DateTime,
                        Email = Email.Text,
                        Street1 = Street1.Text,
                        Street2 = Street2.Text,
                        City = City.Text,
                        State = State.Text,
                        Zip = Zip.Text,
                        IsFav = CheckFav.IsChecked.Value.ToString(),
                        id = Guid.NewGuid().ToString()
                    };
                    Contact.AppendContact(contacts);
                    String AddedMessage = "Your contact has been added successfully.";
                    MessageDialog msgdialog = new MessageDialog(AddedMessage, "Contact Added!");
                    await msgdialog.ShowAsync();
                    Name.Text = String.Empty;
                    HPhone.Text = String.Empty;
                    WPhone.Text = String.Empty;
                    Email.Text = String.Empty;
                    Street1.Text = String.Empty;
                    Street2.Text = String.Empty;
                    City.Text = String.Empty;
                    State.Text = String.Empty;
                    Zip.Text = String.Empty;
                    CheckFav.IsChecked = false;
                 }
            }  
        }


    }
}
