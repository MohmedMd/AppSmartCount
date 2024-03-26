using AppSmartCount.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppSmartCount.ViewModels
{
    public partial class TuserViewModels : INotifyPropertyChanged
    {

        // Fileds
        private string _TuserNa;
        private string _TuserNa1;   
        private string _TuserPs;
        private string _TuserPs1;
        private string _TuserAd;
        private string _TuserAd1;
        private Tuser _selectedTuser;

        // Get And set
        public string TuserNa
        {
            get => _TuserNa;
            set
            {
                if (_TuserNa != value)
                {
                    _TuserNa = value;
                    OnPropertyChanged();
                }
            }
        }
        public string TuserNa1
        {
            get => _TuserNa1;
            set
            {
                if (_TuserNa1 != value)
                {
                    _TuserNa1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string TuserPs
        {
            get => _TuserPs;
            set
            {
                if (_TuserPs != value)
                {
                    _TuserPs = value;
                    OnPropertyChanged();
                }
            }
        }
        public string TuserPs1
        {
            get => _TuserPs1;
            set
            {
                if (_TuserPs1 != value)
                {
                    _TuserPs1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string TuserAd
        {
            get => _TuserAd;
            set
            {
                if (_TuserAd != value)
                {
                    _TuserAd = value;
                    OnPropertyChanged();
                }
            }
        }
        public string TuserAd1
        {
            get => _TuserAd1;
            set
            {
                if (_TuserAd1 != value)
                {
                    _TuserAd1 = value;
                    OnPropertyChanged();
                }
            }
        }

        public Tuser SelectedTuser
        {
            get => _selectedTuser;
            set
            {
                if (_selectedTuser != value)
                {
                    _selectedTuser = value;
                    TuserNa = _selectedTuser.Na; TuserNa1 = _selectedTuser.Na1;
                    TuserPs = _selectedTuser.Ps; TuserPs1 = _selectedTuser.Ps1;
                    TuserAd = _selectedTuser.Ad; TuserAd1 = _selectedTuser.Ad1;

                    OnPropertyChanged();
                }
            }
        }
   
        // Property
        public ObservableCollection <Tuser> TuserCollection { get; set; }

        public ICommand AddTuserCommand { get;  }
        public ICommand EditTuserCommand { get; }
        public ICommand RemoveTuserCommand { get; }

        public TuserViewModels()
        {
            TuserCollection = new ObservableCollection<Tuser>();
               AddTuserCommand = new Command(AddTuser);
              EditTuserCommand = new Command(EditTuser);
            RemoveTuserCommand = new Command(DeleteTuser);
        }

        private void EditTuser(object obj)
        {
            if (SelectedTuser != null)
            {
             foreach (Tuser tuser in TuserCollection.ToList())
                {
                  if(tuser == SelectedTuser )
                    {
                     var newTuser = new Tuser
                        {
                           
                            Id = tuser.Id,
                            Na = TuserNa ,
                            Na1 = TuserNa1 ,
                            Ad = TuserAd,
                            Ad1 = TuserAd1,
                            Ps  = TuserPs,
                            Ps1  = TuserPs1,
                         };
                       TuserCollection.Remove (tuser);
                       TuserCollection.Add (newTuser);

                    }
                }
                
        

            }

        }

        private void DeleteTuser(object obj)
        {
         if ( SelectedTuser != null )
            {
                TuserCollection.Remove(SelectedTuser);
                // Rest Values
                TuserNa = string.Empty;
                TuserNa1 = string.Empty;
                TuserPs = string.Empty;
                TuserPs1 = string.Empty;
                TuserAd = string.Empty;
                TuserAd1 = string.Empty;

            }

        }

        private void AddTuser(object obj)
        {
            // Geneate a unique Id for the new person
            int newId = TuserCollection.Count > 0 ? TuserCollection.Max(p => p.Id) + 1 : 1;
            // set New User
            var tuser = new Tuser
            {
                Id = newId,
                Na= TuserNa ,
                Na1 = TuserNa1 ,
                Ps = TuserPs ,  
                Ps1 = TuserPs1 ,
                Ad = TuserAd ,
                Ad1 = TuserAd1 ,
            };
          TuserCollection.Add(tuser);
            // Rest Values
            TuserNa = string .Empty;
            TuserNa1 = string.Empty;
            TuserPs = string .Empty;
            TuserPs1 = string.Empty;
            TuserAd = string .Empty;
            TuserAd1 = string .Empty;

        }

        //  PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName=null)
        {
         PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));

        }
    
    }
}
