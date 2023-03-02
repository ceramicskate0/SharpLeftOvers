using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLeftOvers
{
    class Commands
    {
        private static DriveInfo[] allDrives = DriveInfo.GetDrives();

        public static void Roastedtickets()
        {
            Console.WriteLine("[!]---Roasted Tickets---[!]");
            Console.WriteLine("[*] Looking for left over Kerberos(roasted) tickets.");
            foreach (DriveInfo d in allDrives)
            {
                if (Helper.IsAdministrator == true)
                {
                    Helper.DirSearchExtensions(d.Name, ".kirbi|.ccache");
                }
                else
                {
                    Helper.DirSearchExtensions(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".kirbi|.ccache");
                    Helper.DirSearchExtensions(@"C:\Windows\Tasks", ".kirbi|.ccache");
                }
            }
            Console.WriteLine("[!]--------------------[!]");
        }

        public static void Bloodhound()
        {
            Console.WriteLine("[!]---BloodHound Stuff---[!]");
            Console.WriteLine("[*] Looking for left over Bloodhound files.");
            foreach (DriveInfo d in allDrives)
            {
                if (Helper.IsAdministrator == true)
                {
                    Helper.DirSearchFile(d.Name, "bloodhound", ".zip");
                }
                else
                {
                    Helper.DirSearchFile(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "bloodhound", ".zip");
                    Helper.DirSearchFile(@"C:\Windows\Tasks", "bloodhound", ".zip");
                }
        }
            Console.WriteLine("[!]--------------------[!]");
        }

        public static void SkeletonKey()
        {
            Console.WriteLine("[!]---Skeleton Key---[!]");
            Console.WriteLine("[*] Looking for left over Golden tickets.");
            try
            {
                Console.WriteLine(" [+] 'krbtgt' account password = 'mimikatz'.\n    Status: " + Helper.Authenticate("krbtgt", "mimikatz"));
            }
            catch (Exception e)
            {
                Console.WriteLine("[!] Error:" + e.Message.ToString());
            }
            Console.WriteLine("[!]--------------------[!]");

        }

        public static void Keefarce()
        {
            Console.WriteLine("[!]---KeeFarce---[!]");
            Console.WriteLine("[*] Looking for left over KeeFarce files");
            Helper.DirSearchFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "keepass_export", ".csv");
            Console.WriteLine("[!]--------------------[!]");

        }

        public static void RDPThief()
        {
            Console.WriteLine("[!]---RDP Thief---[!]");
            Console.WriteLine("[*] Looking for left over RDP Thief files");
            Helper.DirSearchFile(System.IO.Path.GetTempPath(), "data", ".bin");
            Helper.DirSearchFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RdpThief_x64.tmp");
            Console.WriteLine("[!]--------------------[!]");

        }

        public static void NotepadPlusPlus()
        {
            Console.WriteLine("[!]---Notepad++---[!]");
            Console.WriteLine("[*] Looking for left over Notepad++ files");
            Helper.DirSearchFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Roaming\Notepad++\backup");
            Console.WriteLine("[!]--------------------[!]");

        }

        public static void dragoncastle()
        {
            Console.WriteLine("[!]---DragonCaslte---[!]");
            Console.WriteLine("[*] Looking for left over DragonCastle files");
            Console.WriteLine("Result of search for 'C:\\pwned.txt': "+File.Exists(@"C:\pwned.txt"));
            Console.WriteLine("[!]--------------------[!]");
        }
        public static void dumpert()
        {
            Console.WriteLine("[!]---DumpERT---[!]");
            Console.WriteLine("[*] Looking for left over DumpERT files");
            Console.WriteLine("Result of search for 'C:\\windows\\temp\\dumpert.dmp': " + File.Exists(@"C:\windows\temp\dumpert.dmp"));
            Console.WriteLine("[!]--------------------[!]");
        }

        public static void nppspy()
        {
            Console.WriteLine("[!]---NPPSpy---[!]");
            Console.WriteLine("[*] Looking for left over NPPSpy files");
            Console.WriteLine("Result of search for 'C:\\NPPSpy.txt': " + File.Exists(@"C:\NPPSpy.txt"));
            Console.WriteLine("[!]--------------------[!]");
        }

        public static void KeePassPlugin()
        {
            Console.WriteLine("[!]---KeePass-Plugin---[!]");
            Console.WriteLine("[*] Looking for Confirmed POC Malicious KeePassPlugin files");
            Helper.DirSearchFile(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "KeePassHttp", "plgx");
            Helper.DirSearchFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\KeePass\PluginCache\", "KeePassHttp", "dll");
            Console.WriteLine("[*] Looking for any KeePassPlugin config files");
            Helper.DirSearchExtensions(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "plgx");
            Console.WriteLine("[*] Looking for any plugin files");
            Helper.DirSearchFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\KeePass\PluginCache\", "dll");
            Console.WriteLine("[!]--------------------[!]");

        }
        public static void Keethief()
        {
            Console.WriteLine("[!]---KeeThief---[!]");
            Console.WriteLine("[*] Looking for left over KeeThief files");
            Helper.DirSearchFile(allDrives[0]+"Temp", ".csv");
            Console.WriteLine("[!]--------------------[!]");

        }
        public static void MemDumpFiles()
        {
            try
            {
                List<string> finds = new List<string>();
                Console.WriteLine("[!]---.dmp Files Stuff---[!]");
                Console.WriteLine("\n[*] Looking for POSSIBLE left over lsass dump files.");
                foreach (DriveInfo d in allDrives)
                {
                    if (Helper.IsAdministrator == true)
                    {
                        finds.AddRange(Helper.DirSearchFile(d.Name, "lsass", ".dmp"));
                    }
                    else
                    {
                        finds.AddRange(Helper.DirSearchFile(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "lsass", ".dmp"));
                        finds.AddRange(Helper.DirSearchFile(@"c:\windows\tasks", "lsass", ".dmp"));
                    }
                }
                finds = finds.Distinct().ToList();
                foreach (string f in finds)
                {
                    Console.WriteLine(" [+] Possible Find: " + f);
                }
                finds = new List<string>();
                Console.WriteLine("\n[*] Looking for POSSIBLE left over OTHER memory dump files.");
                foreach (DriveInfo d in allDrives)
                {
                    if (Helper.IsAdministrator == true)
                    {
                        finds.AddRange(Helper.DirSearchExtensions(d.Name, "*.dmp|*.ccache|*.mdmp"));
                    }
                    else
                    {
                        finds.AddRange(Helper.DirSearchExtensions(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".dmp|.mdmp"));
                        finds.AddRange(Helper.DirSearchExtensions(@"c:\windows\tasks", ".dmp|.mdmp"));
                    }
                }
                finds = finds.Distinct().ToList();
                foreach (string f in finds)
                {
                    Console.WriteLine(" [+] Possible Find: " + f);
                }
                Console.WriteLine("\n[!]--------------------[!]");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n[!] MemDumpFiles() FAILED!!! "+e.Message.ToString());
            }
        }
    }
}
