using mogadu.ViewModel;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace mogadu.ViewModel.WindowHandling
{
    public class WindowInstance : INotifyPropertyChanged
    {
        private bool _isActive;
        private MainViewModel _mainViewModel;
        public WindowInstance(MainViewModel mainViewModel, Brush bordercolor)
        {
            _mainViewModel = mainViewModel;
            BringWindowInstanceToTopCommand = new DelegateCommand(BringWindowInstanceToTop);
            DeleteWindowInstanceCommand = new DelegateCommand(DeleteWindowInstance);
            IsActive = true;
            BorderColor = bordercolor;
        }
        public UserControl UserControlInstance { get; set; }

        public bool IsActive
        {   get
            {
                return _isActive;
            }

            set
            {
                _isActive = value;
                OnPropertyChanged("IsActive");
            }
        }

        public string WindowName { get; set; }

        public System.Windows.Media.Brush BorderColor { get; set; }
        public ICommand DeleteWindowInstanceCommand { get; set; }
        public ICommand BringWindowInstanceToTopCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void DeleteWindowInstance()
        {
            _mainViewModel.DeleteView(this);
        }
        private void BringWindowInstanceToTop()
        {
            _mainViewModel.UpdateView(UserControlInstance);
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
