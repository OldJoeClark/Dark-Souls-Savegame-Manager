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
  public static string currentGame;

  [Serializable]
  public class SaveInformation
  {
    public string filename;
    public string comments;
  }

  public static string datFile = "_DARKSOULSIII_GameFileInfo.xml";

  [Serializable]
  public class GameFileInfo
  {
    public string DS1GameFilePath = "";
    public string DS1SaveGamePath = "";

    public string DS2GameFilePath = "";
    public string DS2SaveGamePath = "";

    public string DS3GameFilePath = "";
    public string DS3SaveGamePath = "";

    public List<SaveInformation> siList;
  }

  public static string currentDocuments;
  public static string currentUserName;

  public static GameFileInfo gfi = new GameFileInfo();

  public static void Initialize(string docsPath, string user)
  {
    currentDocuments = docsPath;
    currentUserName = user;
  }

  public static void SetDatFile(string f)
  {
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
    if (game == "Dark Souls I")
    {
      gfi.DS1GameFilePath = gameLoc;
      gfi.DS1SaveGamePath = saveLoc;
    }
    if (game == "Dark Souls II")
    {
      gfi.DS2GameFilePath = gameLoc;
      gfi.DS2SaveGamePath = saveLoc;
    }
    if (game == "Dark Souls III")
    {
      gfi.DS3GameFilePath = gameLoc;
      gfi.DS3SaveGamePath = saveLoc;
    }
  }

  public static void ClearList()
  {
    gfi.siList.Clear();
  }

  public static void SetRestoredFileComments(string srcName, string destName)
  {
    string restoredComments = "RESTORED from " + srcName;
    MessageBox.Show(restoredComments);

    int idx = 0;
    foreach (SaveInformation si in gfi.siList)
    {
      if (si.filename.ToUpper() == destName.ToUpper())
      {
        si.comments = restoredComments;
        return;
      }
      idx++;
    }
  }

  public static void Save()
  {
    XmlSerializer xmlFmt = new XmlSerializer(typeof(GameFileInfo), new Type[] { typeof(GameFileInfo) });
    using (Stream f = new FileStream(datFile, FileMode.Create, FileAccess.Write, FileShare.None))
    {
      xmlFmt.Serialize(f, gfi);
    }
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

  public static void GottaStartSomewhere()
  {
    gfi.DS1GameFilePath = "C:\\Users\\" + currentUserName + "\\Documents\\NBGI\\DarkSouls";
    gfi.DS1SaveGamePath = currentDocuments + "\\_SaveGameFiles\\Dark SoulsI\\Backup Saves";

    gfi.DS2GameFilePath = "C:\\Users\\" + currentUserName + "\\AppData\\Roaming\\DarkSoulsII\\";
    gfi.DS2SaveGamePath = currentDocuments + "\\_SaveGameFiles\\Dark SoulsII\\Backup Saves";

    gfi.DS3GameFilePath = "C:\\Users\\" + currentUserName + "\\AppData\\Roaming\\DarkSoulsIII\\";
    gfi.DS3SaveGamePath = currentDocuments + "\\_SaveGameFiles\\Dark SoulsIII\\Backup Saves";

    gfi.siList = new List<SaveInformation>();

    string savefilePath = "";

    if (currentGame == "Dark Souls I")
    {
      savefilePath = gfi.DS1SaveGamePath;
    }
    if (currentGame == "Dark Souls II")
    {
      savefilePath = gfi.DS2SaveGamePath;
    }
    if (currentGame == "Dark Souls III")
    {
      savefilePath = gfi.DS2SaveGamePath;
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


  public static void Load()
  {
    BinaryFormatter bf = new BinaryFormatter();
    try
    {
      XmlSerializer xmlFmt = new XmlSerializer(typeof(GameFileInfo), new Type[] { typeof(GameFileInfo) });
      using (Stream f = File.OpenRead(datFile))
      {
        gfi = (GameFileInfo)xmlFmt.Deserialize(f);
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

    foreach (SaveInformation si in gfi.siList)
    {
      if (fname.ToUpper() == si.filename.ToUpper())
        return si;
    }
    return siNotFound;
  }

  public static void Replace(string fname, string comments)
  {
    int idx = 0;
    foreach (SaveInformation si in gfi.siList)
    {
      if (si.filename.ToUpper() == fname.ToUpper())
      {
        gfi.siList.RemoveAt(idx);

        SaveInformation siNew = new SaveInformation();

        siNew.filename = fname;
        siNew.comments = comments;
        gfi.siList.Add(siNew);
        return;
      }
      idx++;
    }

    SaveInformation siReallyNew = new SaveInformation();
    siReallyNew.comments = comments;
    siReallyNew.filename = fname;

    gfi.siList.Add(siReallyNew);
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

    foreach (SaveInformation si in gfi.siList)
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
      String m = "The following files were not found in the save file folder:\n" + noLongerExists + "Remove them from the information list?";
      m += "\nNote - pressing ACCEPT will NOT delete any files.  \nIt only updates the list of backup files that is stored internally)";
      ObsoleteListItemsDlg dlg = new ObsoleteListItemsDlg();

      ListBox lb;
      foreach (Control control in dlg.Controls)
      {
        if (control.Name == "EntryList")
        {
          lb = (ListBox)control;

          for (int i = gfi.siList.Count - 1; i >= 0; i--)
          {
            if (gfi.siList.ElementAt(i).comments == "NOLONGEREXISTS")
            {
              lb.Items.Add(gfi.siList.ElementAt(i).filename);
            }
          }
        }
      }

      DialogResult o = dlg.ShowDialog();
      if (o == DialogResult.OK)
      {
        for (int i = gfi.siList.Count - 1; i >= 0; i--)
        {
          if (gfi.siList.ElementAt(i).comments == "NOLONGEREXISTS")
          {
            gfi.siList.RemoveAt(i);
          }
        }

        Save();
      }
    }
  }
}