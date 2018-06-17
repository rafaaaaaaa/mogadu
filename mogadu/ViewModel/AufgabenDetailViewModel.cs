using mogadu.Business.Interfaces;
using mogadu.Database.ExpandedEntities;
using mogadu.ViewModel.Interfaces;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace mogadu.ViewModel
{
    public class AufgabenDetailViewModel : IWindow, INotifyPropertyChanged
    {
        private int _prozentualStatus;
        private string _prozentualText;
        private ExpandedMitarbeiter _selectedMitarbeiter;
        private bool _hasChanges;
        private readonly IDataRepository _dataRepository;
        private long _aufgabenId;

        public AufgabenDetailViewModel(IDataRepository dataRepository, long aufgabenId)
        {
            _hasChanges = false;
            SafeCommand = new DelegateCommand(Safe, ()=> _hasChanges);
            CancelCommand = new DelegateCommand(Refresh, ()=> _hasChanges);
            _dataRepository = dataRepository;
            _aufgabenId = aufgabenId;
            Refresh();           
        }

        public int ProzentualStatus
        {
            get
            {
                return _prozentualStatus;
            }
            set
            {
                _prozentualStatus = value;
                ProzentualText = ProzentualStatus.ToString() + "%";
                OnPropertyChanged("ProzentualStatus");
                _hasChanges = true;
            }
        }

        public ExpandedMitarbeiter SelectedMitarbeiter
        {
            get
            {
                return _selectedMitarbeiter;
            }
            set
            {
                _selectedMitarbeiter = value;
                OnPropertyChanged("SelectedMitarbeiter");
                _hasChanges = true;
            }
        }
        public ObservableCollection<ExpandedMitarbeiter> Mitarbeiter { get; set; }
        public string ProzentualText
        {
            get
            {
                return _prozentualText;
            }

            set
            {
                _prozentualText = value;
                OnPropertyChanged("Prozentualtext");
            }

        }
        public ExpandedAufgabe Aufgabe { get; set; }
        public string Windowname => "Aufgabe: " + Aufgabe.Aufgabenname;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        
        public ICommand SafeCommand { get; set; }
        public ICommand CancelCommand { get; set; }


        private void Refresh()
        {
            Aufgabe = _dataRepository.LoadAufgabeByAufgabenId(_aufgabenId);
            ProzentualStatus = Aufgabe.Prozentualstatus.Value;
            var mitarbeiter = _dataRepository.LoadAllMitarbeiterOfTeamByMitarbeiterId(Aufgabe.Auftrag.Team.TeamleiterId);
            Mitarbeiter = new ObservableCollection<ExpandedMitarbeiter>(mitarbeiter as List<ExpandedMitarbeiter>);
            SelectedMitarbeiter = Mitarbeiter.Where(m => m.MitarbeiterId == Aufgabe.MitarbeiterId).FirstOrDefault();
            _hasChanges = false;
        }

        private void Safe()
        {
            Aufgabe.MitarbeiterId = SelectedMitarbeiter.MitarbeiterId;
            Aufgabe.Prozentualstatus = ProzentualStatus;
            _dataRepository.SafeAufgabe(Aufgabe);


            _dataRepository.RefreshData();
            var auftragsaufgaben = _dataRepository.AlleAufgaben.Where(a => a.AuftragId == Aufgabe.AuftragId).ToList();       
            var isAuftragNichtFertig = auftragsaufgaben.Any(a => a.Prozentualstatus != 100);

            if(!isAuftragNichtFertig && ProzentualStatus == 100)
            {
                _dataRepository.SafeAuftrag(Aufgabe.Auftrag);
            };
        }
    }
}
