using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            // determine the package root, based on own location
            string result = Assembly.GetExecutingAssembly().Location;
            int index = result.LastIndexOf("\\");
            string rootPath = $"{result.Substring(0, index)}\\..\\";

            rootPath += @"BackgroundProcess\BackgroundProcess.exe";

            ProcessStartInfo info = new ProcessStartInfo
            {
                Verb = "runas",
                UseShellExecute = true,
                FileName = rootPath
            };
            Process.Start(info);
        }
    }
}
