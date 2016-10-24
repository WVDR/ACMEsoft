using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ACMEsoft.Model;

namespace ACMEsoftApp.ViewModels
{
    class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        internal void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private ACMEsoftContext  dataContext;

        public ACMEsoftContext DataContext
        {
            get
            {
                return dataContext;
            }
            set
            {
                if (dataContext != value)
                {
                    dataContext = value;
                    NotifyPropertyChanged("DataContext");
                }
            }
        }

        private string apiAddress = "http://localhost:49762";

        public string APIAddress
        {
            get { return apiAddress; }
            set { apiAddress = value; }
        }

    }
}
