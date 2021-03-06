﻿using mogadu.Business;
using mogadu.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mogadu.Views.Dashboard
{
    /// <summary>
    /// Interaktionslogik für WetterTileUserControl.xaml
    /// </summary>
    public partial class WetterTileUserControl : UserControl
    {
        public WetterTileUserControl()
        {
            InitializeComponent();
            DataContext = new WetterTileViewModel(new WetterErmittler());
        }
    }
}
