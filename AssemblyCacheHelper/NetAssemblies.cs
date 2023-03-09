using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssemblyCacheHelper.DTO;
using System.Threading;
using System.Threading.Tasks;
using System.Resources;

namespace AssemblyCacheHelper
{
    using System.IO;
    using System.Reflection;
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    public class NetAssemblies
    {
        static List<NetAssembly> _netAssemblyCache = new List<NetAssembly>();

        public static List<NetAssembly> NetAssemblyCache 
        {
            get
            {
                if (_netAssemblyCache.Count() == 0)
                {
                    if (File.Exists("NetAssemblyCache.xml"))
                    {
                        StreamReader sr = new StreamReader("NetAssemblyCache.xml");
                        _netAssemblyCache = AssemblyCacheHelper.Serialization.DeserializeObject<List<NetAssembly>>(sr.ReadToEnd());
                        sr.Close();
                    }
                    else
                    {
                        Stream stm = Assembly.GetExecutingAssembly().GetManifestResourceStream("AssemblyCacheHelper.Resources.NetAssemblyCache.xml");
                        StreamReader sr = new StreamReader(stm);
                        _netAssemblyCache = AssemblyCacheHelper.Serialization.DeserializeObject<List<NetAssembly>>(sr.ReadToEnd());
                        sr.Close();
                    }
                }
                return _netAssemblyCache;
            }
        }

        public static NetAssembly GetAssemblyInfo(string assemblyFullPath, string runtimeVersion)
        {
            NetAssembly netAssembly = new NetAssembly();

            FileInfo fi = new FileInfo(assemblyFullPath);
            netAssembly.ModifiedDate = fi.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss");
            netAssembly.FileSize = fi.Length.ToString("###,###,##0.###");
            netAssembly.AssemblyFilename = assemblyFullPath;

            var asmCache = (from asm in NetAssemblyCache
                            where asm.ModifiedDate == netAssembly.ModifiedDate &&
                                  asm.FileSize == netAssembly.FileSize &&
                                  asm.AssemblyFilename == netAssembly.AssemblyFilename
                            select asm).FirstOrDefault();

            if (asmCache != null)
            {
                netAssembly.FileVersion = asmCache.FileVersion;
                netAssembly.FileDescription = asmCache.FileDescription;
                netAssembly.Company = asmCache.Company;
                netAssembly.ProductName = asmCache.ProductName;
                netAssembly.AssemblyName = asmCache.AssemblyName;
                netAssembly.AssemblyFullName = asmCache.AssemblyFullName;
                netAssembly.ProcessorArchitecture = asmCache.AssemblyFullName;
                netAssembly.RuntimeVersion = asmCache.RuntimeVersion;
                netAssembly.AssemblyVersion = asmCache.AssemblyVersion;
                netAssembly.Culture = asmCache.Culture;
                netAssembly.PublicKeyToken = asmCache.PublicKeyToken;
            }
            else
            {
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assemblyFullPath);
                netAssembly.FileVersion = fvi.FileVersion;
                netAssembly.FileDescription = fvi.FileDescription;
                netAssembly.Company = fvi.CompanyName;
                netAssembly.ProductName = fvi.ProductName;

                AssemblyName asmName = AssemblyName.GetAssemblyName(assemblyFullPath);
                netAssembly.AssemblyName = asmName.Name;
                netAssembly.AssemblyFullName = asmName.FullName;
                netAssembly.ProcessorArchitecture = asmName.ProcessorArchitecture.ToString();
                netAssembly.RuntimeVersion = runtimeVersion;

                string asmFullName = asmName.FullName;
                string[] s = asmFullName.Split(',');
                netAssembly.AssemblyVersion = s[1].Replace(" Version=", "");
                netAssembly.Culture = s[2].Replace(" Culture=", "");
                netAssembly.PublicKeyToken = s[3].Replace(" PublicKeyToken=", "");
            }
            
            return netAssembly;
        }

        public static string GetImageRuntimeVersion(string assemblyFullPath)
        {
            AppDomain appDomain = null;
            string assemblyVersion = "";
            try 
            {
                byte[] buffer = File.ReadAllBytes(assemblyFullPath);
                appDomain = AppDomain.CreateDomain("TempAppDomain");
                Assembly assembly = appDomain.Load(buffer);

                assemblyVersion = assembly.ImageRuntimeVersion;
            }
            catch
            { 
            }
            finally 
            { 
                if (appDomain != null)
                    AppDomain.Unload(appDomain); 
            }
            return assemblyVersion;
        }
    }
}
