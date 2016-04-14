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
  [Serializable]
  public class SaveInformation
  {
    public string filename;
    public string comments;
  }

  public static string datFile = "_DARKSOULS_GameFileInfo.xml";
  public static List<SaveInformation> siList = new List<SaveInformation>();

  public static void SetDatFile(string f)
  {
    datFile = f;
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

  public static void Save()
  {
    XmlSerializer xmlFmt = new XmlSerializer(typeof(List<SaveInformation>), new Type[] { typeof(SaveInformation) });
    using (Stream f = new FileStream(datFile, FileMode.Create, FileAccess.Write, FileShare.None))
    {
      xmlFmt.Serialize(f, siList);
    }
  }

  public static void Load()
  {
    BinaryFormatter bf = new BinaryFormatter();
    try
    {
      XmlSerializer xmlFmt = new XmlSerializer(typeof(List<SaveInformation>), new Type[] { typeof(SaveInformation) });
      using (Stream f = File.OpenRead(datFile))
      {
        siList = (List<SaveInformation>)xmlFmt.Deserialize(f);
      }
    }
    catch
    {
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

  public static void Validate(object a1, object a2)
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
      String m = "The following files were not found:\n" + noLongerExists + "Remove them from the information list?";

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

      //DialogResult d = MessageBox.Show(m, "Confirm", MessageBoxButtons.YesNo);

      //if (d == DialogResult.Yes)
      //{
      //  for (int i = siList.Count - 1; i >= 0; i--)
      //  {
      //    if (siList.ElementAt(i).comments == "NOLONGEREXISTS")
      //    {
      //      siList.RemoveAt(i);
      //    }
      //  }

      //  Save();
      //}
    }
  }
}