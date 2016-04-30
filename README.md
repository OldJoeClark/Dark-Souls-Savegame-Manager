# Dark-Souls-Savegame-Manager
Allow backup/restore of multiple Dark Souls 1/2/3 save games with optional comments.

1.  Choose the game - i.e., "Dark Souls I/II/III" from the pick list.
2.  The program tries to identify the default game file location and and picks a default backup file location under the users' documents folder.  If these do not work, use the buttons to pick the desired locations. (NOTE - these have been tested on Windows 7 and seem to work properly.  I cannot comment on later versions of Windows.  I would not be surprised if it worked fine, though.  Likewise, I would not be surprised if it did not work at all.  I just do not have test capability here)
3.  To make a backup of a game file, click "Save".  Type in any file name.  Type in descriptive comments.  Select "Do It!"  The game file will be copied to the save location with the name chosen.
4.  To restore a backup, click "Restore".  Highlight the desired file.  Select "Do It!"  This will overwrite the existing game, so make sure the game is not running or something unexpected and/or undesirable might happen.
5.  You can make descriptive comments for each save.  For example "Try first boss" or "Found an amazing chest".  These comments are kept in simple text XML files in the folder where the SaveGameUtility is located.  If you move the utility, be sure to backup these XML files and copy them to the new location.

It goes without saying that this program comes with no guarantee or warranty of any kind.  Use at your own risk.  
