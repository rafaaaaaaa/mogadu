using mogadu.Business;
using mogadu.Business.Interfaces;
using mogadu.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mogadu.Views.Templates
{
    /// <summary>
    /// Interaktionslogik für SucheUserControl.xaml
    /// </summary>
    public partial class SucheUserControl 
    {
        public SucheUserControl(IDataRepository dataRepository, long mitarbeiterId)
        {
            InitializeComponent();
            DataContext = new SucheViewModel(dataRepository, mitarbeiterId);
        }
    }
}
