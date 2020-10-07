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
using TP3Allocine2.Utils;
using TP3Allocine2.View;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TP3Allocine2.ViewModel
{
    class SearchCompteViewModel : ViewModelBase
    {
        private Compte _searchCompte;
        private string _melAddress;
        public ICommand BtnSearchCompte { get; private set; }
        public ICommand BtnModifyCompteCommand { get; private set; }
        public ICommand BtnClearCompteCommand { get; private set; }
        public ICommand BtnAddCompteCommand { get; private set; }


        public SearchCompteViewModel()
        {
            _searchCompte = new Compte();
            BtnSearchCompte = new RelayCommand(searchCompteAction);
            BtnModifyCompteCommand = new RelayCommand(ModifyCompte);
            BtnClearCompteCommand = new RelayCommand(ClearCompte);
            BtnAddCompteCommand = new RelayCommand(AddCompte);
        }

        
        public string MelAddress
        {
            get { return _melAddress; }
            set
            {
                _melAddress = value;
                RaisePropertyChanged();
            }
        }

        public Compte SearchCompte
        {
            get { return _searchCompte; }
            set
            {
                _searchCompte = value;
                RaisePropertyChanged();
            }
        }

        private async void searchCompteAction() {
            try { 
                SearchCompte = await WSService.Instance.GetCompteByEmailAsync(_melAddress);
            }
            catch (Exception e)
            {
                MessageDialog popup = new MessageDialog(e.Message);
                await popup.ShowAsync();
            }
        }

        private async void ModifyCompte()
        {
            try
            {
                await WSService.Instance.ModifyCompte(SearchCompte);
                MessageDialog popup = new MessageDialog($"Compte {SearchCompte.Nom} modifié !");
                await popup.ShowAsync();
            }
            catch (Exception e)
            {
                MessageDialog popup = new MessageDialog(e.Message);
                await popup.ShowAsync();
            }
        }

        private async void AddCompte()
        {
            RootPage r = (RootPage)Window.Current.Content;
            SplitView sv = (SplitView)(r.Content);
            (sv.Content as Frame).Navigate(typeof(AddCompte));
        }

        private void ClearCompte()
        {
            SearchCompte = null;
        }
    }
}
