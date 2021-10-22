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
                Helper.DirSearchExtension(d.Name, ".kirbi");
            }
            Console.WriteLine("[!]--------------------[!]");
        }

        public static void Bloodhound()
        {
            Console.WriteLine("[!]---BloodHound Stuff---[!]");
            Console.WriteLine("[*] Looking for left over Bloodhound files.");
            foreach (DriveInfo d in allDrives)
            {
                Helper.DirSearchFile(d.Name, "bloodhound", ".zip");
            }
            Console.WriteLine("[!]--------------------[!]");
        }

        public static void SkeletonKey()
        {
            Console.WriteLine("[!]---Skeleton Key---[!]");
            Console.WriteLine("[*] Looking for left over Golden tickets.");
            Console.WriteLine(" [+] 'krbtgt' account password = 'mimikatz'.\n    Status: " + Helper.Authenticate("krbtgt", "mimikatz"));
            Console.WriteLine("[!]--------------------[!]");

        }
    }
}
