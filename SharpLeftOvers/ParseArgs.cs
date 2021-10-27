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
                    Console.WriteLine("[!] NOT Running as admin. Somethings wont work as good as they could.");
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
                        }
                    }
                    catch (Exception e)
                    {
                        Usage();
                        Console.WriteLine("[Error] Invalid input " + e.Message.ToString());
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
Search file system for any files with .kirbi file extension. (default for tools)

-bloodhound
Search file systemt for file with name bloodhound and a zip file. (default for tool)

-skeletonkey
Attempt to auth to krbtgt account with password 'mimikatz' to check for skeleton key.
");

        }
    }
}
