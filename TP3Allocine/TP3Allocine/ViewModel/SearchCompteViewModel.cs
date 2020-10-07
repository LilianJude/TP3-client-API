using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3Allocine.ViewModel
{
    public class SearchCompteViewModel : ViewModelBase
    {
        private string _searchCompte;
        public string SearchCompte
        {
            get { return _searchCompte; }
            set
            {
                _searchCompte = value;
                RaisePropertyChanged();
            }
        }
    }
}
