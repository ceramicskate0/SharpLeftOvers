using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SharpLeftOvers
{
    class Helper
    {
        private static List<string> filesfound = new List<string>();
        public static bool IsAdministrator =>
           new WindowsPrincipal(WindowsIdentity.GetCurrent())
               .IsInRole(WindowsBuiltInRole.Administrator);
        public static List<string> DirSearchExtension(string sDir, string extension)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    try
                    {
                        foreach (string f in Directory.GetFiles(d))
                        {
                            if (Path.GetExtension(f).ToLower().Equals(extension.ToLower()) == true)
                            {
                                Console.WriteLine(" [+] Found: " + f);
                                filesfound.Add(f);
                            }
                        }
                        DirSearchExtension(d, extension);
                    }
                    catch (System.Exception excpt)
                    {
                        Console.WriteLine("[!] " + excpt.Message);
                    }
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
            return filesfound;
        }
        public static List<string> DirSearchFile(string sDir, string FileName, string extension)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    try
                    {
                        foreach (string f in Directory.GetFiles(d))
                        {
                            if (Path.GetFileName(f).ToLower().Contains(FileName.ToLower()) == true && Path.GetExtension(f).ToLower().Contains(extension.ToLower()) == true)
                            {
                                Console.WriteLine(" [+] Found: " + f);
                                filesfound.Add(f);
                            }
                        }
                        DirSearchFile(d, FileName,extension);
                    }
                    catch (System.Exception excpt)
                    {
                        Console.WriteLine("[!] " + excpt.Message);
                    }
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
            return filesfound;
        }
        public static List<string> DirSearchFile(string sDir, string FileName)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    try
                    {
                        foreach (string f in Directory.GetFiles(d))
                        {
                            if (Path.GetFileName(f).ToLower().Contains(FileName.ToLower()) == true)
                            {
                                Console.WriteLine(" [+] Possible Find: " + f);
                                filesfound.Add(f);
                            }
                        }
                        DirSearchFile(d, FileName);
                    }
                    catch (System.Exception excpt)
                    {
                        //Console.WriteLine("[!] " + excpt.Message);
                    }
                }
            }
            catch (System.Exception excpt)
            {
                //Console.WriteLine(excpt.Message);
            }
            return filesfound;
        }

        public static long FileSize(string path)
        {
            FileInfo info = new FileInfo(path);
            return info.Length;
        }

        public static string GetDomain()
        {
            return System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
        }

        //https://github.com/raystyle/SharpDomainSpray/blob/master/ADAuth.cs
        public static bool Authenticate(string userName, string password)
        {
            bool authentic = false;
            try
            {
                DirectoryEntry entry = new DirectoryEntry("LDAP://" + GetDomain(),
                    userName, password);
                object nativeObject = entry.NativeObject;
                authentic = true;
            }
            catch (DirectoryServicesCOMException) { }
            return authentic;
        }

        //borrowed form https://github.com/GhostPack/SharpDPAPI/blob/master/SharpDPAPI/lib/Interop.cs
        // for DC enumeration 
        [DllImport("Netapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int DsGetDcName
          (
            [MarshalAs(UnmanagedType.LPTStr)] string ComputerName,
            [MarshalAs(UnmanagedType.LPTStr)] string DomainName,
            [In] int DomainGuid,
            [MarshalAs(UnmanagedType.LPTStr)] string SiteName,
            [MarshalAs(UnmanagedType.U4)] DSGETDCNAME_FLAGS flags,
            out IntPtr pDOMAIN_CONTROLLER_INFO
          );
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct DOMAIN_CONTROLLER_INFO
        {
            [MarshalAs(UnmanagedType.LPTStr)]
            public string DomainControllerName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string DomainControllerAddress;
            public uint DomainControllerAddressType;
            public Guid DomainGuid;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string DomainName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string DnsForestName;
            public uint Flags;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string DcSiteName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string ClientSiteName;
        }

        [Flags]
        public enum DSGETDCNAME_FLAGS : uint
        {
            DS_FORCE_REDISCOVERY = 0x00000001,
            DS_DIRECTORY_SERVICE_REQUIRED = 0x00000010,
            DS_DIRECTORY_SERVICE_PREFERRED = 0x00000020,
            DS_GC_SERVER_REQUIRED = 0x00000040,
            DS_PDC_REQUIRED = 0x00000080,
            DS_BACKGROUND_ONLY = 0x00000100,
            DS_IP_REQUIRED = 0x00000200,
            DS_KDC_REQUIRED = 0x00000400,
            DS_TIMESERV_REQUIRED = 0x00000800,
            DS_WRITABLE_REQUIRED = 0x00001000,
            DS_GOOD_TIMESERV_PREFERRED = 0x00002000,
            DS_AVOID_SELF = 0x00004000,
            DS_ONLY_LDAP_NEEDED = 0x00008000,
            DS_IS_FLAT_NAME = 0x00010000,
            DS_IS_DNS_NAME = 0x00020000,
            DS_RETURN_DNS_NAME = 0x40000000,
            DS_RETURN_FLAT_NAME = 0x80000000
        }
        
        [DllImport("Netapi32.dll", SetLastError = true)]
        public static extern int NetApiBufferFree(IntPtr Buffer);

        public static string GetDCName()
        {
            // retrieves the current domain controller name
            // adapted from https://www.pinvoke.net/default.aspx/netapi32.dsgetdcname
            DOMAIN_CONTROLLER_INFO domainInfo;
            const int ERROR_SUCCESS = 0;
            IntPtr pDCI = IntPtr.Zero;

            int val = DsGetDcName("", "", 0, "",
            DSGETDCNAME_FLAGS.DS_DIRECTORY_SERVICE_REQUIRED |
            DSGETDCNAME_FLAGS.DS_RETURN_DNS_NAME |
            DSGETDCNAME_FLAGS.DS_IP_REQUIRED, out pDCI);

            if (ERROR_SUCCESS == val)
            {
                domainInfo = (DOMAIN_CONTROLLER_INFO)Marshal.PtrToStructure(pDCI, typeof(DOMAIN_CONTROLLER_INFO));
                string dcName = domainInfo.DomainControllerName;
                NetApiBufferFree(pDCI);
                return dcName.Trim('\\');
            }
            else
            {
                string errorMessage = new Win32Exception((int)val).Message;
                Console.WriteLine("\r\n  [X] Error {0} retrieving domain controller : {1}", val, errorMessage);
                NetApiBufferFree(pDCI);
                return "";
            }
        }
    }
}
