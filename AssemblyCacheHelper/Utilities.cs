using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace AssemblyCacheHelper
{
    public class Utilities
    {
        public static string RunProcess(string exePath, string arguments)
        {
            string result = "";

            Process process = new Process();
            process.StartInfo.FileName = exePath;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            StreamReader sr = process.StandardOutput;
            result = sr.ReadToEnd();
            process.WaitForExit();

            return result;
        }
    }
}
