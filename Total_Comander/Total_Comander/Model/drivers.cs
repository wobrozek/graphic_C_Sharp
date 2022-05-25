using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Total_Comander.Model
{
    class drivers
    {
        public string CurrentPath { get; set; }
        public string CurrentDrive { get; set; }

        public List<string> list { get; set; }

        public void loadDrivers(){
            list = Directory.GetLogicalDrives().ToList();
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
