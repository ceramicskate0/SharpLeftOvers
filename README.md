# SharpLeftOvers
(Because anything C# needs to start with a name 'Sharp')

## [The Blog Post](https://ceramicskate0.github.io/SharpLeftovers.html)

## Super Low Detection Rating
![SharpLeftOvers](https://user-images.githubusercontent.com/6934294/158038932-43d1ef7a-63b9-440c-963c-26545c9565e5.PNG)
[VT Link](https://www.virustotal.com/gui/file/966cebb69e58697b3e0c855f232c10098d6f00093fbc88ea98d0071303dc0e1c/detection)
- **UPDATE** as of 2/3/23 still bypassing defender :-)
- **UPDATE** as of 9/13/23 still bypassing defender and its down to 3 A/V detections from the 4 in the image :-)

## PSA
Oh its also gonna run slow when you run as elevated. More folders to search and all. If you know a way to speed it up let me know (issue/pull/DM)

## HEY! LISTEN!
Of course community and your help/pull/issue requests are very very welcome. Ive tried to keep the coding simple to help anyone pick it up quick. 

## Background
So heres how this started...there i was doing Red team stuff minding my own business when...BAM! i find bloodhound data and Kerberos tickets sitting on the disk of this box im on...of course im gonna use it...well after i look at it. Turns out (and im sure you have run into this also) previous pentesters had not cleaned up. Finding this kind of stuff makes tests go faster and well no need to redo the wheel. So time to tool it. Since nothing gets fixed until you tool it. Also i got the skeleton key idea from someones talk, i think it was red seige's.

## What is this
SharpLeftOvers is a tool that is geared towards finding default left over artifacts from previous pentests to help yours go faster. It also could be used to help Blue Teams but I am on Red so that is the focus of the tool. Its kind of like Bloodhound that way i guess, multiple uses. Ive tried to keep it able to be run in CobaltStrike (BAD WORD) and other tools who run C# in an appdomain or as a Fork & Run (if this still works for you)(By that i mean no wait for input and no Enviorment.Exit(); !!!!!!!). 

## Usage
**Example:**``SharpLeftOvers.exe -all``

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

      -dragoncastle
      Find dragoncastle left over files

      -nppspy
      Find nppspy leftovers files

      -dumpert
      Find dumpert leftovers files


## Dev/Contrib Stuff:
- **Commands.cs** = The searchs to look for things. If you want to add new ones put the code here. Try to keep it to a simple method to run.
- **Helper.cs** = Contains the random functions that will or could be used in varios Commands and other parts of the app.
- **ParseArgs.cs** = Contains the `switch` statement to run commands and print logo. Since any additons will require an update to usage the logo is here. 
  - Add new commands here in switch statement. 
  - Update usage.
- **Program.cs** = run command parser and show logo. 
