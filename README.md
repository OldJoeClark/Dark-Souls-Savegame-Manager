Allow backup/restore of multiple Dark Souls 1/2/3 save games with optional comments.


I wrote this some time back for Dark Souls 1 and gradually added enhancements for DS2 and DS3.    If you want to make backups of your game files on PC, this has been a pretty helpful utility for me.  It's for Windows 7, but may work for 8 and 10, just no way to test.  It does NOT run in the background like some of the other utilities, but does have some other nice features to compensate.


It has a fairly self-explanatory graphic interface.  Essentially, when you want to make a backup, you

(a) Exit the game to the main menu;

(b) Alt-Tab out of the game to the desktop where the backup utility can be accessed;

(c) Fill in the gui to create a save file with a name of your choice and comments describing what where you are at that point.


It keeps two simple text XML files, both automatically created and updated.  The first contains information as to where the game file and back saves are currently located and resides in the same location as the utility.  The second file is placed in the backup location, containing the file names and comments.  You do not have to manually create either of these files.


It tries to automatically detect the location of the main game file and chooses a default location for the saves.  These can be overridden, although I do not know why you would want to override the main game location.  The backup locations are in
C:\Users\<username>\Documents\_SaveGameFiles, with the backups located in subfolders named after the game (Dark SoulsI/II/III).  If all goes well, all the necessary things get created at startup and again you shouldn't have to manually do anything.


I am only putting this out as a courtesy in the hopes that it will save people from getting the games ruined by malicious hackers.  Even though it works for everything I do, I really wish someone would take it on and make it better.  There may be bugs that I have never encountered or great enhancements that could be added, but I am basically done with it.   


You will definitely need Framework .Net 4.5 and the usual VC2008 and VC2010 redistributables which you probably already have those anyway from other things.  But it will definitely not run without them.

1. Choose the game - i.e., "Dark Souls I/II/III" from the pick list.

2. The program tries to identify the default game file location and and picks a default backup file location under the users' documents folder. If these do not work, use the buttons to pick the desired locations. (NOTE - these have been tested on Windows 7 and seem to work properly. I cannot comment on later versions of Windows. I would not be surprised if it worked fine, though. Likewise, I would not be surprised if it did not work at all. I just do not have test capability here)

3. To make a backup of a game file, click "Save". Type in any file name. Type in descriptive comments. Select "Do It!" The game file will be copied to the save location with the name chosen.

4. To restore a backup, click "Restore". Highlight the desired file. Select "Do It!" This will overwrite the existing game, so make sure the game is not running or something unexpected and/or undesirable might happen.

5. You can make descriptive comments for each save. For example "Try first boss" or "Found an amazing chest". These comments are kept in a simple text XML file in the folder where the backups are located. 

It goes without saying that this program comes with no guarantee or warranty of any kind. Use at your own risk.