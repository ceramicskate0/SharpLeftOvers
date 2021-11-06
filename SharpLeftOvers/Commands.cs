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
                    Helper.DirSearchExtension(d.Name, ".kirbi");
                }
                else
                {
                    Helper.DirSearchExtension(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".kirbi");
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
            Console.WriteLine("[!]--------------------[!]");

        }
        public static void NotepadPlusPlus()
        {
            Console.WriteLine("[!]---Notepad++---[!]");
            Console.WriteLine("[*] Looking for left over Notepad++ files");
            Helper.DirSearchFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\Roaming\Notepad++\backup");
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
            Console.WriteLine("[!]---.dmp Files Stuff---[!]");
            Console.WriteLine("[*] Looking for POSSIBLE left over lsass dump files.");
            foreach (DriveInfo d in allDrives)
            {
                if (Helper.IsAdministrator == true)
                {
                    Helper.DirSearchFile(d.Name, "lsass", ".dmp");
                }
                else
                {
                    Helper.DirSearchFile(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "lsass", ".dmp"); 
                }
            }
            Console.WriteLine("[*] Looking for POSSIBLE left over OTHER memory dump files.");
            foreach (DriveInfo d in allDrives)
            {
                if (Helper.IsAdministrator == true)
                {
                    Helper.DirSearchExtension(d.Name,".dmp");
                }
                else
                {
                    Helper.DirSearchExtension(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".dmp");
                }
        }
            Console.WriteLine("[!]--------------------[!]");
        }
    }
}
