using mvvm_comander.Model;
using MVVMTotalCommander.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace mvvm_comander.ViewModel
{
    class PanelTCViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Model.PanelTCModel panel;

        public String CurrentPath
        {
            get => panel.CurrentPath;
            set { 
                panel.CurrentPath = value;
                OnPropertyChange(nameof(CurrentPath));
            }
        }

        public String CurrentDrive
        {
            get { return panel.CurrentDrive; }
            set
            {
                panel.CurrentDrive = value;
                OnPropertyChange(nameof(CurrentDrive));
            }
        }

        public List<string> DriversList
        {
            get { return panel.DriversList; }
            set
            {
                panel.DriversList = panel.loadDrivers();
                OnPropertyChange(nameof(DriversList));
            }
        }

        private ICommand loadDrivesCommand;
        public ICommand LoadDrivesCommand => loadDrivesCommand ?? (loadDrivesCommand = new RelayCommand(
                o => DriversList = panel.loadDrivers(),
                o => true
            ));


        private ICommand selectDriveCommand;
        public ICommand SelectDriveCommand => selectDriveCommand ?? (selectDriveCommand = new RelayCommand(
                o => CurrentPath = CurrentDrive,
                o => true
            ));

        private void OnPropertyChange(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public PanelTCViewModel() => panel = new Model.PanelTCModel();

    }
}
