using System;
using System.Collections.Generic;
using FileBrowserPOC.ViewModel;
using Xamarin.Forms;

namespace FileBrowserPOC.View
{
    public partial class FileBrowserPage : ContentPage
    {
        public FileBrowserPage()
        {
            InitializeComponent();
            BindingContext = new FileBrowserViewModel();
        }
    }
}
