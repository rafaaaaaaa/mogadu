using mogadu.Business.Interfaces;
using mogadu.ViewModel;
using System.Windows;

namespace mogadu.Views
{
    /// <summary>
    /// Interaktionslogik für MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView(IDataRepository dataRepository, long mitarbeiterId)
        {
            InitializeComponent();
            DataContext = new MainViewModel(dataRepository, mitarbeiterId);

        }
    }
}
