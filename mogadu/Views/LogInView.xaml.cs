using mogadu.Business;
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
using System.Windows.Shapes;

namespace mogadu.Views
{
    /// <summary>
    /// Interaktionslogik für LogInView.xaml
    /// </summary>
    public partial class LogInView : Window
    {
        public LogInView()
        {
            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            DataContext = new LoginViewModel(new DataRepository(), this);
        }
    }
}
