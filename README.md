# SharpLeftOvers
(Because anything C# needs to start with a name 'Sharp')

## HEY! LISTEN!
Of course community and your help/pull/issue requests are very very welcome. Ive tried to keep the coding simple to help anyone pick it up quick. 

## Background
So heres how this started...there i was doing Red team stuff minding my own business when...BAM! i find bloodhound data and Kerberos tickets sitting on the disk of this box im on...of course im gonna use it...well after i look at it. Turns out (and im sure you have run into this also) previous pentesters had not cleaned up. Finding this kind of stuff makes tests go faster and well no need to redo the wheel. So time to tool it. Since nothing gets fixed until you tool it. Also i got the skeleton key idea from someones talk, i think it was red seige's.

## What is this
SharpLeftOvers is a tool that is geared towards finding default left over artifacts from previous pentests to help yours go faster. It also could be used to help Blue Teams but I am on Red so that is the focus of the tool. Its kind of like Bloodhound that way i guess, multiple uses. Ive tried to keep it able to be run in CobaltStrike(BAD WORD) and other tools who run C# in an appdomain or as a Fork & Run (if this still works for you)(By that i mean no wait for input and no Enviorment.Exit(); !!!!!!!). 

## Usage
      Commands List:
      Note: you can run them by adding them each to commandline or '-all' command.

      -all
      Run all searchs/things (list seens below)

      -roastedtickets
      Search file system for any files with .kirbi file extension. (default for tools)

      -bloodhound
      Search file systemt for file with name bloodhound and a zip file. (default for tool)

      -skeletonkey
      Attempt to auth to krbtgt account with password 'mimikatz' to check for skeleton key. (Credit Red Sieges Youtube talk)

      -dmp
      Attempt to find lsass dump files or other memory dump files with .dmp extension.

      -keethief
      Attempt to find left over keethief dumps.

      -keefarce
      Attempt to find left over keefarce dumps.

      -notepadplusplus
      Attempt to locate left over notepad++ temp files. (Credit: mcbazza)

      -rdpthief
      Attempt to find left over RDP Thief file


## Dev/Contrib Stuff:
- **Commands.cs** = The searchs to look for things. If you want to add new ones put the code here. Try to keep it to a simple method to run.
- **Helper.cs** = Contains the random functions that will or could be used in varios Commands and other parts of the app.
- **ParseArgs.cs** = Contains the `switch` statement to run commands and print logo. Since any additons will require an update to usage the logo is here. 
  - Add new commands here in switch statement. 
  - Update usage.
- **Program.cs** = run command parser and show logo. 
