using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3Allocine2.ViewModel
{
    class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<SearchCompteViewModel>();
            SimpleIoc.Default.Register<AddCompteViewModel>();
        }

        public SearchCompteViewModel SearchCompte => ServiceLocator.Current.GetInstance<SearchCompteViewModel>();
        public AddCompteViewModel AddCompte => ServiceLocator.Current.GetInstance<AddCompteViewModel>();
    }

}
