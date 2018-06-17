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
using mogadu.Views.Suche;
using mogadu.Views.Aufgaben;
using mogadu.Views.Mitarbeiter;

namespace mogadu.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //Membervariablen
        private static MainViewModel _application;
        private IDataRepository _dataRepository;
        private UserControl _aktuellesTab;
        private long _mitarbeiterId;
        private bool _isLoading;
        private ObservableCollection<WindowInstance> _userControlInstances;

        public MainViewModel()
        {
            _application = this;
            _mitarbeiterId = 26;
            _userControlInstances = new ObservableCollection<WindowInstance>();
            NavigateToUebersichtCommand = new DelegateCommand(NavigateToUebersicht);
            NavigateToAuftraegeCommand = new DelegateCommand(NavigateToAuftraege);
            NavigateToTeamCommand = new DelegateCommand<long?>(NavigateToTeam);
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
        public void NavigateToUebersicht()
        {
            CreateWindow(new UebersichtUserControl(_dataRepository, _mitarbeiterId), Brushes.RoyalBlue);
        }
        public void NavigateToAuftraege()
        {
            CreateWindow(new AuftragUserControl(_dataRepository, _mitarbeiterId), Brushes.CornflowerBlue);
        }
        public void NavigateToTeam(long? teamId = null)
        {
            if (teamId == null)
            {
                CreateWindow(new TeamUserControl(_dataRepository, _mitarbeiterId), Brushes.LightSkyBlue);
            }

            else
            {
                var mitarbeiter = _dataRepository.LoadMitarbeiterByTeamId(teamId.Value);
                CreateWindow(new TeamUserControl(_dataRepository, mitarbeiter.MitarbeiterId), Brushes.LightSkyBlue);
            }
        }
        public void NavigateToAuftragDetail(long? auftragId = null)
        {
                CreateWindow(new AuftragDetailUserControl(_dataRepository, auftragId.Value), Brushes.LightGray);            
        }

        public void NavigateToAufgabenDetail(long aufgabenId)
        {
            CreateWindow(new AufgabenDetailUserControl(_dataRepository, aufgabenId), Brushes.LightSteelBlue);
        }

        public void NavigateToMitarbeiterDetail(long mitarbeiterId)
        {
            CreateWindow(new MitarbeiterDetailUserControl(_dataRepository, mitarbeiterId), Brushes.LightSteelBlue);
        }

        public void CreateWindow(UserControl usercontrol, Brush borderColor)
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
        public static MainViewModel Application
        {
            get
            {
                if(_application == null)
                {
                    _application = new MainViewModel();
                }
                return _application;
            }
            set
            {
                _application = value;
            }
        }
    }
}
