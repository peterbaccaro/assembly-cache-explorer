using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblyCacheHelper.DTO
{
    public class NetAssembly
    {
        public string AssemblyName { get; set; }
        public string AssemblyFullName { get; set; }
        public string AssemblyVersion { get; set; }
        public string Culture { get; set; }
        public string PublicKeyToken { get; set; }
        public string ProcessorArchitecture { get; set; }
        public string RuntimeVersion { get; set; }
        public string ModifiedDate { get; set; }
        public string FileSize { get; set; }
        public string AssemblyFilename { get; set; }
        public string FileVersion { get; set; }
        public string FileDescription { get; set; }
        public string Company { get; set; }
        public string ProductName { get; set; }
    }
}
