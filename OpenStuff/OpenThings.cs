using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenStuff
{
    public class OpenThings
    {
        public static void openAccessFile(string fileAccessPath)
        {
            Process.Start("MSACCESS.EXE", fileAccessPath);
        }

        public static void openExcelFile(string fileExcelPath)
        {
            Process.Start("Excel.exe", fileExcelPath);
        }

        public static void openFileFolder(string fileFolderPath)
        {
            Process.Start("Explorer.exe", @fileFolderPath);
        }

        public static void openInternetExplorer(string urlPath)
        {
            Process.Start("IExplore.exe", urlPath);
        }

        public static void openFirefox(string urlPath)
        {
            Process.Start("Firefox.exe", urlPath);
        }
    }
}
