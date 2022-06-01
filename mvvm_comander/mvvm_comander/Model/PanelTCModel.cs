using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace mvvm_comander.Model
{
    internal sealed class PanelTCModel
    {
        public string CurrentPath { get; set; }
        public string CurrentDrive { get; set; }


        private List<string> driversList;

        public List<string> DriversList
        {
            get { return driversList; }
            set { driversList = value; }
        }


        public List<string> loadDrivers() 
        {
            return Directory.GetLogicalDrives().ToList();
        }

        public void LoadFiles()
        {
            List<string> directories = new List<string>();
            List<string> files = new List<string>();

            directories = Directory.GetDirectories(CurrentPath).ToList();
            files = Directory.GetFiles(CurrentPath).ToList();
        }
    }
}
