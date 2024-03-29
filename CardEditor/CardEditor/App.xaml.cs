﻿using CardEditor.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows;

namespace CardEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public MainWindow MainWindow { get; set; }
        public ViewModelLocator ViewModelLocator { get; set; }

        public DBCRUD Database { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Database = new DBCRUD("DiabloCardEditor");
            ViewModelLocator = new ViewModelLocator();
            ViewModelLocator.InitViewModels();
            MainWindow = new MainWindow();
            MainWindow.Show();
        }
    }
}
