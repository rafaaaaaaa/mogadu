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
    /// Interaktionslogik für UebersichtUserControl.xaml
    /// </summary>
    public partial class UebersichtUserControl : UserControl
    {
        public UebersichtUserControl(IDataRepository dataRepository, long id)
        {
            InitializeComponent();
            DataContext = new UebersichtViewModel(dataRepository, id);
        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
