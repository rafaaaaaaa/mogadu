using mogadu.Business;
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

namespace mogadu.Views.Templates
{
    /// <summary>
    /// Interaktionslogik für TeamUserControl.xaml
    /// </summary>
    public partial class TeamUserControl : UserControl
    {
        public TeamUserControl(IDataRepository dataRepository, long id)
        {
            InitializeComponent();
             DataContext = new TeamViewModel(dataRepository, id);
        }
    }
}
