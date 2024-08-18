﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Base2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPageFlyout : ContentPage
    {
        public ListView ListView;

        public AdminPageFlyout()
        {
            InitializeComponent();

            BindingContext = new AdminPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class AdminPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<AdminPageFlyoutMenuItem> MenuItems { get; set; }
            
            public AdminPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<AdminPageFlyoutMenuItem>(new[]
                {
                    new AdminPageFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new AdminPageFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new AdminPageFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new AdminPageFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new AdminPageFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}