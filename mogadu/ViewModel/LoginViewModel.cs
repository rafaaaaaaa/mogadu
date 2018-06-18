using mogadu.Database;
using NHibernate;
using Prism.Commands;
using System.Linq;
using System.Windows.Input;
using mogadu.Database.Entities;
using System.Collections.Generic;
using mogadu.Business.Interfaces;
using mogadu.Business;
using System.Windows.Controls;
using System;
using mogadu.Views;
using mogadu.Database.ExpandedEntities;
using System.Drawing;
using System.ComponentModel;
using System.Windows;
//ERRORHANDLING VALIDIEREN
//CanLogin implementieren
//UI verschönern

namespace mogadu.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private Visibility _hasError;
        private IDataRepository _dataRepository;
        private Window _window;
        public LoginViewModel(IDataRepository dataRepository, Window window)
        {
            _window = window;
            LoginCommand = new DelegateCommand<object>(Login);
            _dataRepository = dataRepository;
            Mitarbeiters = _dataRepository.AlleMitarbeiter;
            _hasError = Visibility.Hidden;
        }

        public Visibility HasError
        {
            get
            {
                return _hasError;
            }
            set
            {
                _hasError = value;
                OnPropertyChanged("HasError");
            }
        }
        public List<ExpandedMitarbeiter> Mitarbeiters { get; set; }
        public Mitarbeiter SelectedMitarbeiter { get; set; }
        public ICommand LoginCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Login(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var password = passwordBox.Password;
            var logins = _dataRepository.AlleLogins;
            var loginperson = logins.Where(login => login.MitarbeiterId == SelectedMitarbeiter?.MitarbeiterId).FirstOrDefault();

                if (loginperson != null && loginperson.Passwort != password || loginperson == null)
                {
                    HasError = Visibility.Visible;
                    return;
                }

            MainView view = new MainView(_dataRepository, SelectedMitarbeiter.MitarbeiterId);
            view.Show();
            _window.Close();
        }
    }
}
