﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Catalog.Wpf.ViewModel;

namespace Catalog.Wpf
{
    public partial class ManageTagsWindow : Window
    {
        private readonly CatalogContext database = Application.Current.Database();

        public ManageTagsWindow()
        {
            ResetTags();

            InitializeComponent();
        }

        private void ResetTags()
        {
            DataContext =
                new ObservableCollection<TagViewModel>(
                    database
                        .Tags
                        .Select(tag => new TagViewModel(tag))
                );
        }

        protected override void OnClosed(EventArgs e)
        {
            database.Dispose();
        }

        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            database.SaveChanges();

            DialogResult = true;

            Close();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;

            Close();
        }
    }
}
