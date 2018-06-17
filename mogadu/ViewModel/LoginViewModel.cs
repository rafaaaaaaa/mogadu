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
//ERRORHANDLING VALIDIEREN
//CanLogin implementieren
//UI verschönern

namespace mogadu.ViewModel
{
    public class LoginViewModel
    {
        private IDataRepository _dataRepository;
        public LoginViewModel(IDataRepository dataRepository)
        {
            LoginCommand = new DelegateCommand<object>(Login);
            _dataRepository = dataRepository;
            Mitarbeiters = _dataRepository.LoadAllMitarbeiter();
        }

        public List<ExpandedMitarbeiter> Mitarbeiters { get; set; }
        public Mitarbeiter SelectedMitarbeiter { get; set; }
        public ICommand LoginCommand { get; set; }
        private void Login(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            var password = passwordBox.Password;
            var logins = _dataRepository.AlleLogins;

            if (logins.Where(login => login.MitarbeiterId == SelectedMitarbeiter.MitarbeiterId).First().Passwort != password)
            {
                //ERRORHANDLING VALIDIEREN
            }
            MainView view = new MainView();
            view.Show();
        }
    }
}
