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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AddressBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
           // MyFrame.Navigate(typeof(Contacts));
            //this.DataContext = Contact.GetContacts();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void OptionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ContactList.IsSelected)
            {
                MyFrame.Navigate(typeof(Contacts));
            }
            else if (AddContact.IsSelected)
            {
                MyFrame.Navigate(typeof(AddContacts));
            }
            else if (DeleteContact.IsSelected)
            {
                MyFrame.Navigate(typeof(DeleteContact));
            }
        }
    }
}
