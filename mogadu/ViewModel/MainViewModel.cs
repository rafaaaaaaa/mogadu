using mogadu.Views.Templates;
using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using System;
using mogadu.ViewModel.Interfaces;
using System.Windows.Media;
using System.Linq;
using mogadu.ViewModel.WindowHandling;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using mogadu.Business;
using mogadu.Business.Interfaces;

namespace mogadu.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //Membervariablen
        private IDataRepository _dataRepository;
        private UserControl _aktuellesTab;
        private long _mitarbeiterId;
        private bool _isLoading;
        private ObservableCollection<WindowInstance> _userControlInstances;

        public MainViewModel()
        {
            _mitarbeiterId = 26;
            _userControlInstances = new ObservableCollection<WindowInstance>();
            NavigateToUebersichtCommand = new DelegateCommand(NavigateToUebersicht);
            NavigateToAuftraegeCommand = new DelegateCommand(NavigateToAuftraege);
            NavigateToSucheCommand = new DelegateCommand(NavigateToSuche);
            NavigateToTeamCommand = new DelegateCommand(NavigateToTeam);
            _dataRepository = new DataRepository();
            NavigateToUebersicht();
        }

        //Properties
        //public bool IsLoading
        //{
        //    get
        //    {
        //        return _isLoading;
        //    }

        //    set
        //    {
        //        _isLoading = value;
        //        OnPropertyChanged("IsLoading");
        //    }
        //}
        public ObservableCollection<WindowInstance> UserControlInstances
        {
            get
            {
                return _userControlInstances;
            }
            set
            {
                _userControlInstances = value;
                OnPropertyChanged("UserControlInstances");
            }
        }
        public UserControl AktuellesTab
        {
            get
            {
                return _aktuellesTab;
            }
            set
            {
                _aktuellesTab = value;
                OnPropertyChanged("AktuellesTab");
            }
        }
        public ICommand NavigateToUebersichtCommand { get; set; }
        public ICommand NavigateToAuftraegeCommand { get; set; }
        public ICommand NavigateToSucheCommand { get; set; }
        public ICommand NavigateToTeamCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //Methods
        private void NavigateToUebersicht()
        {
            CreateWindow(new UebersichtUserControl(_dataRepository, _mitarbeiterId), Brushes.RoyalBlue);
        }
        private void NavigateToAuftraege()
        {
            CreateWindow(new AuftrageUserControl(_dataRepository, _mitarbeiterId), Brushes.CornflowerBlue);
        }
        private void NavigateToTeam()
        {
            CreateWindow(new TeamUserControl(_dataRepository, _mitarbeiterId), Brushes.LightSkyBlue);
        }
        private void NavigateToSuche()
        {
            CreateWindow(new SucheUserControl(_dataRepository, _mitarbeiterId), Brushes.LightBlue);
        }
        private void CreateWindow(UserControl usercontrol, Brush borderColor)
        {
            var windowInstance = new WindowInstance(this, borderColor) { UserControlInstance = usercontrol, WindowName = ((IWindow)usercontrol.DataContext).Windowname };
            _userControlInstances.Insert(0, windowInstance);
            UserControlInstances = _userControlInstances;
            UpdateView(usercontrol);
        }
        internal void UpdateView(UserControl userControlInstance)
        {
            foreach(var instance in UserControlInstances)
            {
                if (instance.UserControlInstance != userControlInstance)
                    instance.IsActive = false;

                else
                    instance.IsActive = true;
            }

            UserControlInstances = UserControlInstances;

            AktuellesTab = userControlInstance;
        }
        internal void DeleteView(WindowInstance windowInstance)
        {
            var index = UserControlInstances.IndexOf(windowInstance);
            UserControlInstances.Remove(windowInstance);

            var newIndex = index == 0 ? index : index - 1;
            if (UserControlInstances.Count != 0 && newIndex >= 0)
            {
                UserControlInstances[newIndex].IsActive = true;
                UpdateView(UserControlInstances[newIndex].UserControlInstance);
            }
            else
            AktuellesTab = null;
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
