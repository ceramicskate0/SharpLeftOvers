using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLeftOvers
{
    /// <summary>
    /// I know it says parse args. But im running them as they are called form here also.
    /// </summary>
    class ParseArgs
    {
        public static void RunArgs(string[] args)
        {
            if (args.Length <= 0)
            {
                Usage();
            }
            else
            {
                if (Helper.IsAdministrator==false)
                {
                    Console.WriteLine("[!] NOT Running elevated. " +
                        "Somethings wont work as good as they could. " +
                        "Also I cant search everything on the machine. " +
                        "Also i will only search user dir for most things (File Permissions). [!]");
                }
                else
                {
                    Console.WriteLine("[*] Running elevated");
                }
                for (int x = 0; x < args.Length; ++x)
                {
                    try
                    {
                        switch (args[0].ToLower())
                        {
                            case "-all":
                                Commands.Roastedtickets();
                                Commands.Bloodhound();
                                Commands.SkeletonKey();
                                Commands.MemDumpFiles();
                                Commands.Keefarce();
                                Commands.Keethief();
                                Commands.NotepadPlusPlus();
                                Commands.RDPThief();
                                break;
                            case "-roastedtickets":
                                Commands.Roastedtickets();
                                break;
                            case "-bloodhound":
                                Commands.Bloodhound();
                                break;
                            case "-skeletonkey":
                                Commands.SkeletonKey();
                                break;
                            case "-dmp":
                                Commands.MemDumpFiles();
                                break;
                            case "-keethief":
                                Commands.Keethief();
                                break;
                            case "-keefarce":
                                Commands.Keefarce();
                                break;
                            case "-notepadplusplus":
                                Commands.NotepadPlusPlus();
                                break;
                            case "-rdpthief":
                                Commands.RDPThief();
                                break;
                            case "-keepass-plugin":
                                Commands.KeePassPlugin();
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Usage();
                        Console.WriteLine("[Error]: " + e.Message.ToString());
                    }
                }
            }
        }
        public static void Logo()
        {
            Console.WriteLine(@")
  _____ __ __   ____  ____   ____  _        ___  _____  ______   ___   __ __    ___  ____    _____
 / ___/|  |  | /    ||    \ |    \| |      /  _]|     ||      | /   \ |  |  |  /  _]|    \  / ___/
(   \_ |  |  ||  o  ||  D  )|  o  ) |     /  [_ |   __||      ||     ||  |  | /  [_ |  D  )(   \_ 
 \__  ||  _  ||     ||    / |   _/| |___ |    _]|  |_  |_|  |_||  O  ||  |  ||    _]|    /  \__  |
 /  \ ||  |  ||  _  ||    \ |  |  |     ||   [_ |   _]   |  |  |     ||  :  ||   [_ |    \  /  \ |
 \    ||  |  ||  |  ||  .  \|  |  |     ||     ||  |     |  |  |     | \   / |     ||  .  \ \    |
  \___||__|__||__|__||__|\_||__|  |_____||_____||__|     |__|   \___/   \_/  |_____||__|\_|  \___|
                                                                                                  
created by: Ceramicskate0
 ");
        }
        
        public static void Usage()
        {
            Console.WriteLine(@"
Commands List:
Note: you can run them by adding them each to commandline or '-all' command.

-all
Run all searchs/things (list seens below)

-roastedtickets
Search file system for any files with .kirbi & .ccache file extensions. (default for tools)

-bloodhound
Search file systemt for file with name bloodhound and a zip file. (default for tool)

-skeletonkey
Attempt to auth to krbtgt account with password 'mimikatz' to check for skeleton key. (Credit Red Sieges Youtube talk)

-dmp
Attempt to find lsass dump files or other memory dump files.

-keethief
Attempt to find left over keethief dumps.

-keefarce
Attempt to find left over keefarce dumps.

-notepadplusplus
Attempt to locate left over notepad++ temp files. (Credit: mcbazza)

-rdpthief
Attempt to find left over RDP Thief file

-keepass-plugin
Attempt to find left over KeePass pLugins (Malicous POC also)
");

        }
    }
}
