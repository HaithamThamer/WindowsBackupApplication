using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using Microsoft.Win32;
using System.Threading;
namespace BackupApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue(Application.ProductName, Application.ExecutablePath.ToString());
            while (true)
            {
                ZipFile.CreateFromDirectory(@"d:\CurrentProjects", @"D:\Google\CurrentProjects\Backup_" + Environment.MachineName.ToString() + "_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm") + ".zip");
                Thread.Sleep(TimeSpan.FromHours(1));
            }
        }
        
    }
}
