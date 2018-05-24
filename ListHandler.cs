using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using SaveGameFiles;

public class CListHandler
{
  public static String strGameDS1  = "Dark Souls I";
  public static String strGameDS2  = "Dark Souls II";
  public static String strGameDS3  = "Dark Souls III";
  public static String strGameGoaT = "Ghost of a Tale";
  
  public static string currentGame;
  public static string activeSaveLoc = "Not Set";

  [Serializable]
  public class SaveInformation
  {
    public string filename;
    public string comments;
  }

  public static string datFile = "_DARKSOULSIII_GameFileInfo.xml";
  public static List<SaveInformation> siList;

  [Serializable]
  public class SaveGamePaths
  {
    public string DS1GameFilePath = "";
    public string DS1SaveGamePath = "";

    public string DS2GameFilePath = "";
    public string DS2SaveGamePath = "";

    public string DS3GameFilePath = "";
    public string DS3SaveGamePath = "";

    public string GoaTGameFilePath = "";
    public string GoaTSaveGamePath = "";
  }

  public static SaveGamePaths sgp = new SaveGamePaths();

  public static string currentDocuments;
  public static string currentUserName;


  public static void Initialize(string docsPath, string user)
  {
    currentDocuments = docsPath;
    currentUserName = user;
    InitSaveGamePaths();
  }

  public static void SetActiveSaveLocation(string s)
  {
    activeSaveLoc = s;
  }

  public static void SetDatFile(string f)
  {
    //MessageBox.Show("CListHandler:SetDatFile -- activeSaveLoc: " + activeSaveLoc);
    datFile = f;
  }

  public static void ValidateFolder(string folder)
  {
    if (!System.IO.Directory.Exists(folder))
    {
      try
      {
        System.IO.Directory.CreateDirectory(folder);
      }
      catch (Exception e)
      {
        MessageBox.Show("Unable to create file folder:\n" + folder + "\n" + 
          e.Message + "\n" + e.InnerException.Message.ToString());
      }
    }
  }

  public static void SetGameData(string game, string gameLoc, string saveLoc)
  {
    // Add new games here
    if (game == strGameDS1)
    {
      sgp.DS1GameFilePath = gameLoc;
      sgp.DS1SaveGamePath = saveLoc;
    }
    if (game == strGameDS2)
    {
      sgp.DS2GameFilePath = gameLoc;
      sgp.DS2SaveGamePath = saveLoc;
    }
    if (game == strGameDS3)
    {
      sgp.DS3GameFilePath = gameLoc;
      sgp.DS3SaveGamePath = saveLoc;
    }
    if (game == strGameGoaT)
    {
      sgp.GoaTGameFilePath = gameLoc;
      sgp.GoaTSaveGamePath = saveLoc;
    }
  }

  public static void ClearList()
  {
    siList.Clear();
  }

  public static void SetRestoredFileComments(string srcName, string destName)
  {
    string restoredComments = "RESTORED from " + srcName;
    MessageBox.Show(restoredComments);

    int idx = 0;
    foreach (SaveInformation si in siList)
    {
      if (si.filename.ToUpper() == destName.ToUpper())
      {
        si.comments = restoredComments;
        return;
      }
      idx++;
    }
  }

  //////////////////////////////////
  public static void InitSaveGamePaths()
  {
    //sgp.DS1GameFilePath = "C:\\Users\\" + currentUserName + "\\Documents\\NBGI\\DarkSouls";
    //sgp.DS1SaveGamePath = currentDocuments + "\\_SaveGameFiles\\Dark SoulsI\\Backup Saves";

    //sgp.DS2GameFilePath = "C:\\Users\\" + currentUserName + "\\AppData\\Roaming\\DarkSoulsII\\";
    //sgp.DS2SaveGamePath = currentDocuments + "\\_SaveGameFiles\\Dark SoulsII\\Backup Saves";

    //sgp.DS3GameFilePath = "C:\\Users\\" + currentUserName + "\\AppData\\Roaming\\DarkSoulsIII\\";
    //sgp.DS3SaveGamePath = currentDocuments + "\\_SaveGameFiles\\Dark SoulsIII\\Backup Saves";


    // Add new games here
    sgp.DS1GameFilePath = "C:\\Users\\" + currentUserName + "\\Documents\\NBGI\\DarkSouls";
    sgp.DS1SaveGamePath = currentDocuments + "\\_SaveGameFiles\\Dark SoulsI\\Backup Saves";

    sgp.DS2GameFilePath = "C:\\Users\\" + currentUserName + "\\AppData\\Roaming\\DarkSoulsII\\";
    sgp.DS2SaveGamePath = currentDocuments + "\\_SaveGameFiles\\Dark SoulsII\\Backup Saves";

    sgp.DS3GameFilePath = "C:\\Users\\" + currentUserName + "\\AppData\\Roaming\\DarkSoulsIII\\";
    sgp.DS3SaveGamePath = currentDocuments + "\\_SaveGameFiles\\Dark SoulsIII\\Backup Saves";

    sgp.GoaTGameFilePath = "C:\\Users\\" + currentUserName + "\\Documents\\My Games\\Ghost of a Tale\\";
    sgp.GoaTSaveGamePath = currentDocuments + "\\_SaveGameFiles\\Ghost of a Tale\\Backup Saves";
  }

  public static void ReadSaveGamePaths()
  {
    BinaryFormatter bf = new BinaryFormatter();
    try
    {
      XmlSerializer xmlFmt = new XmlSerializer(typeof(SaveGamePaths), new Type[] { typeof(SaveGamePaths) });

      if (System.IO.File.Exists("SaveGamePaths.xml"))
      {
        using (Stream f = File.OpenRead("SaveGamePaths.xml"))
        {
          sgp = (SaveGamePaths)xmlFmt.Deserialize(f);
        }
      }
      else
      {
        InitSaveGamePaths();
        UpdateSaveGamePaths();
      }
    }
    catch(Exception e)
    {
      MessageBox.Show("Error opening SaveGamePaths.xml:\n" + e.Message + "\n" + e.InnerException.Message.ToString());
    }
  }

  public static void UpdateSaveGamePaths()
  {
    XmlSerializer xmlFmt = new XmlSerializer(typeof(SaveGamePaths), new Type[] { typeof(SaveGamePaths) });

    using (Stream f = new FileStream("SaveGamePaths.xml", FileMode.Create, FileAccess.Write, FileShare.None))
    {
      xmlFmt.Serialize(f, sgp);
    }
  }

  /////////////////////////////////

  public static void GottaStartSomewhere()
  {
    InitSaveGamePaths();

    siList = new List<SaveInformation>();

    string savefilePath = "";

    // Add new games here
    if (currentGame == strGameDS1)
    {
      savefilePath = sgp.DS1SaveGamePath;
    }
    if (currentGame == strGameDS2)
    {
      savefilePath = sgp.DS2SaveGamePath;
    }
    if (currentGame == strGameDS3)
    {
      savefilePath = sgp.DS2SaveGamePath;
    }
    if (currentGame == strGameGoaT)
    {
      savefilePath = sgp.GoaTSaveGamePath;
    }

    if (!System.IO.Directory.Exists(savefilePath))
    {
      try
      {
        System.IO.Directory.CreateDirectory(savefilePath);
      }
      catch (Exception e)
      {
        MessageBox.Show("Unable to create save file folder:\n" + savefilePath + "\n" + e.Message);
      }
    }     
    
    Save();
  }


  public static void LoadGameFileInfo()
  {
    try
    {
      Load();
    }
    catch (Exception e)
    {
      MessageBox.Show("Initialization error: \n" + e.Message + "\n" + e.InnerException.Message.ToString());
    }
  }

  public static void Save()
  {
    string fullPath = activeSaveLoc + "\\" + datFile;
    XmlSerializer xmlFmt = new XmlSerializer(typeof(List<SaveInformation>), new Type[] { typeof(List<SaveInformation>) });

    using (Stream f = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None))
    {
      xmlFmt.Serialize(f, siList);
    }
  }

  public static void Load()
  {
    BinaryFormatter bf = new BinaryFormatter();
    try
    {
      string fullPath = activeSaveLoc + "\\" + datFile;
      XmlSerializer xmlFmt = new XmlSerializer(typeof(List<SaveInformation>), new Type[] { typeof(List<SaveInformation>) });

      using (Stream f = File.OpenRead(fullPath))
      {
        siList = (List<SaveInformation>)xmlFmt.Deserialize(f);
      }
    }
    catch
    {
      GottaStartSomewhere();
    }
  }

  public static SaveInformation FindbyFilename(string fname)
  {
    SaveInformation siNotFound = new SaveInformation();
    siNotFound.filename = fname;
    siNotFound.comments = "Not Set";

    foreach (SaveInformation si in siList)
    {
      if (fname.ToUpper() == si.filename.ToUpper())
        return si;
    }
    return siNotFound;
  }

  public static void Replace(string fname, string comments)
  {
    int idx = 0;
    foreach (SaveInformation si in siList)
    {
      if (si.filename.ToUpper() == fname.ToUpper())
      {
        siList.RemoveAt(idx);

        SaveInformation siNew = new SaveInformation();

        siNew.filename = fname;
        siNew.comments = comments;
        siList.Add(siNew);
        return;
      }
      idx++;
    }

    SaveInformation siReallyNew = new SaveInformation();
    siReallyNew.comments = comments;
    siReallyNew.filename = fname;

    siList.Add(siReallyNew);
  }

  public static bool CheckExist(string FileName_From_siList, List<string> FileName_From_Folder)
  {
    foreach (string fn in FileName_From_Folder)
    {
      if (FileName_From_siList == fn)
        return true;
    }

    return false;
  }

  public static void ValidateFiles(object a1, object a2)
  {
    System.Windows.Forms.ListBox.ObjectCollection c1 =
      (System.Windows.Forms.ListBox.ObjectCollection) a1;

    System.Windows.Forms.ListBox.ObjectCollection c2 =
      (System.Windows.Forms.ListBox.ObjectCollection) a2;

    List<string> FileNameList = new List<string>();

    foreach (object o in c1)
    {
      FileNameList.Add(o.ToString());
    }

    foreach (object o in c2)
    {
      FileNameList.Add(o.ToString());
    }

    int idx = 0;
    int pdx = 0;

    String noLongerExists = "";

    foreach (SaveInformation si in siList)
    {
      if (!CheckExist(si.filename, FileNameList))
      {
        noLongerExists += si.filename + "\n";
        si.comments = "NOLONGEREXISTS";
        pdx--;
      }
      else
      {
        idx++;
        pdx++;
      }
    }

    if (noLongerExists.Length > 0)
    {
      //String m = "The following files were not found in the save file folder:\n" + noLongerExists + "Remove them from the information list?";
      //m += "\nNote - pressing ACCEPT will NOT delete any files.  \nIt only updates the list of backup files that is stored internally)";
      ObsoleteListItemsDlg dlg = new ObsoleteListItemsDlg();

      ListBox lb;
      foreach (Control control in dlg.Controls)
      {
        if (control.Name == "EntryList")
        {
          lb = (ListBox)control;

          for (int i = siList.Count - 1; i >= 0; i--)
          {
            if (siList.ElementAt(i).comments == "NOLONGEREXISTS")
            {
              lb.Items.Add(siList.ElementAt(i).filename);
            }
          }
        }
      }

      DialogResult o = dlg.ShowDialog();
      if (o == DialogResult.OK)
      {
        for (int i = siList.Count - 1; i >= 0; i--)
        {
          if (siList.ElementAt(i).comments == "NOLONGEREXISTS")
          {
            siList.RemoveAt(i);
          }
        }

        Save();
      }
    }
  }
}