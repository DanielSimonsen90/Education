using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoWayTest
{
    class Person : INotifyPropertyChanged
    {
        #region Properties
        public int ID { get => _id; set { _id = value; OnPropertyChanged("ID"); } }
        private int _id;
        
        public string Fornavn { get => _fornavn; set { _fornavn = value; OnPropertyChanged("Fornavn"); } }
        private string _fornavn;
        
        public string Efternavn { get => _efternavn; set { _efternavn = value; OnPropertyChanged("Efternavn"); } }
        private string _efternavn;
        
        public int Formue { get => _formue; set { _formue = value; OnPropertyChanged("Formue"); } }
        private int _formue;
        #endregion

        public Person(int ID, string Fornavn, string Efternavn, int Formue)
        {
            this.ID = ID;
            this.Fornavn = Fornavn;
            this.Efternavn = Efternavn;
            this.Formue = Formue;
        }

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        #endregion

        public string GetFormue() => $"{Fornavn} {Efternavn} har en formue på {Formue} kr.";
    }
}
