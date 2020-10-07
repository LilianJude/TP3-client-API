using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TP3Allocine2.Model;
using TP3Allocine2.Service;
using Windows.UI.Popups;

namespace TP3Allocine2.ViewModel
{
    class AddCompteViewModel : ViewModelBase
    {
        private Compte _addCompte;
        public ICommand BtnClearCompteCommand { get; private set; }
        public ICommand BtnAddCompteCommand { get; private set; }

        public AddCompteViewModel()
        {
            _addCompte = new Compte();
            BtnClearCompteCommand = new RelayCommand(ClearCompte);
            BtnAddCompteCommand = new RelayCommand(AddCompteAction);
        }

        public Compte AddCompte
        {
            get { return _addCompte; }
            set
            {
                _addCompte = value;
                RaisePropertyChanged();
            }
        }

        private async void AddCompteAction()
        {
            try
            {
                await GPSService.Instance.getLocation(this.AddCompte);
                await WSService.Instance.AddCompte(this.AddCompte);
    
                MessageDialog popup = new MessageDialog($"Utilisateur {AddCompte.Nom} ajouté ! Coordonnées : ({AddCompte.Latitude}; {AddCompte.Longitude})");
                await popup.ShowAsync();
                this.AddCompte = new Compte();
            }
            catch (Exception e)
            {
                MessageDialog popup = new MessageDialog(e.Message);
                await popup.ShowAsync();
            }

        }

        private void ClearCompte()
        {
            
        }
    }
}
