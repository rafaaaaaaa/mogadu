using mogadu.Business.Interfaces;
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

namespace mogadu.Views.Aufgaben
{
    /// <summary>
    /// Interaction logic for AufgabenDetailUserControl.xaml
    /// </summary>
    public partial class AufgabenDetailUserControl : UserControl
    {
        public AufgabenDetailUserControl(IDataRepository dataRepository, long aufgabenId)
        {
            InitializeComponent();
            DataContext = new AufgabenDetailViewModel(dataRepository, aufgabenId);
        }
    }
}
