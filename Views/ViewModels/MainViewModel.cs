using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.AppConfig;

namespace Test.Views.ViewModels
{
    public class MainViewModel: ObservableObject
    {
        public RelayCommand DescriptionViewCommand { get; set; }
        public RelayCommand PollViewCommand { get; set; }
        public RelayCommand ContactsViewCommand { get; set; }

        public DescriptionViewModel DescriptionVM { get; set; }
        public PollViewModel PollVM { get; set; }
        public ContactsViewModel ContactsVM { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            DescriptionVM = new DescriptionViewModel();
            PollVM = new PollViewModel();
            ContactsVM = new ContactsViewModel();

            CurrentView = DescriptionVM;

            DescriptionViewCommand = new RelayCommand(o => {
                CurrentView = DescriptionVM;
            });

            PollViewCommand = new RelayCommand(o => {
                CurrentView = PollVM;
            });

            ContactsViewCommand = new RelayCommand(o => {
                CurrentView = ContactsVM;
            });
        }


    }
}
