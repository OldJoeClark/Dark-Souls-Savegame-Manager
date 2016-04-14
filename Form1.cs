using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SaveGameFiles
{
  public partial class Form1 : Form
  {
    //                    C:\\Users\\us\\Documents\\NBGI\\DarkSouls
    //string SourceSaves = "C:\\Users\\us\\Documents\\NBGI\\DarkSouls";
    //string BackupSaves = "D:\\UserData\\Games\\Dark Souls\\Backup Saves";

    //string DarkSoulsSaveFile = "draks0005.sl2";

    string SourceSaves = "";
    string BackupSaves = "";

    string gameFileInfo = "";

    string DarkSoulsSaveFile = "";
    public string selectedFile = "";
    
    public Form1()
    {
      InitializeComponent();

      InitializeByGame("Dark Souls III");

      dlgSelectSource.InitialDirectory = SourceSaves;
      dlgSelectDestination.InitialDirectory = BackupSaves;

      txtSourceFolder.Text = SourceSaves;
      txtDestinationFolder.Text = BackupSaves;

      //string myDocuments = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");

      //CListHandler.SetDatFile(myDocuments + "\\_DARKSOULS_GameFileInfo.xml");
      //CListHandler.SetDatFile(BackupSaves + "\\_DARKSOULS_GameFileInfoIII.xml");
      CListHandler.SetDatFile(gameFileInfo);
      CListHandler.Load();

      txtSourceFile.Text = DarkSoulsSaveFile;

      //InitializeByGame("Dark Souls III");
      updateFileLists();
    }

    private void btnSource_Click(object sender, EventArgs e)
    {
      dlgSelectSource.ShowDialog();
    }

    private void btnDestination_Click(object sender, EventArgs e)
    {
      dlgSelectDestination.ShowDialog();
    }

    private void updateFileLists()
    {
      FileInfo[] fi;
      DirectoryInfo diSource = new DirectoryInfo(txtSourceFolder.Text);
      DirectoryInfo diDest = new DirectoryInfo(txtDestinationFolder.Text);

      listSourceFiles.Items.Clear();
      listDestinationFiles.Items.Clear();

      fi = diSource.GetFiles();
      foreach (FileInfo f in fi)
      {
        if (f.Name.Contains("GameFileInfo"))
          continue;
        listSourceFiles.Items.Add(f.Name);
      }

      fi = diDest.GetFiles();
      foreach (FileInfo f in fi)
      {
        if (f.Name.Contains("GameFileInfo"))
          continue;
        listDestinationFiles.Items.Add(f.Name);
      }

      CListHandler.Validate(listSourceFiles.Items, listDestinationFiles.Items);
    }

    private void radioSave_CheckedChanged(object sender, EventArgs e)
    {
      if (radioSave.Checked)
      {
        radioRestore.Checked = false;
        dlgSelectSource.InitialDirectory = SourceSaves;
        dlgSelectDestination.InitialDirectory = BackupSaves;

        txtSourceFile.Text = DarkSoulsSaveFile;
        txtDestinationFile.Text = "";

        txtSourceFolder.Text = SourceSaves;
        txtDestinationFolder.Text = BackupSaves;
      }
      else
      {
        radioRestore.Checked = true;
        dlgSelectSource.InitialDirectory = BackupSaves;
        dlgSelectDestination.InitialDirectory = SourceSaves;

        txtSourceFile.Text = "";
        txtDestinationFile.Text = DarkSoulsSaveFile;

        txtSourceFolder.Text = BackupSaves;
        txtDestinationFolder.Text = SourceSaves;
      }

      updateFileLists();
    }

    private void radioRestore_CheckedChanged(object sender, EventArgs e)
    {      
      if (radioRestore.Checked)
      {
        radioSave.Checked = false;
        dlgSelectSource.InitialDirectory = BackupSaves;
        dlgSelectDestination.InitialDirectory = SourceSaves;

        txtSourceFile.Text = "";
        txtDestinationFile.Text = DarkSoulsSaveFile;

        txtSourceFolder.Text = BackupSaves;
        txtDestinationFolder.Text = SourceSaves;
      }
      else
      {
        radioSave.Checked = true;
        dlgSelectSource.InitialDirectory = SourceSaves;
        dlgSelectDestination.InitialDirectory = BackupSaves;

        txtSourceFile.Text = DarkSoulsSaveFile;
        txtDestinationFile.Text = "";

        txtSourceFolder.Text = SourceSaves;
        txtDestinationFolder.Text = BackupSaves;
      }

      updateFileLists();
    }

    private void dlgSelectSource_FileOk(object sender, CancelEventArgs e)
    {
      string fullPath = dlgSelectSource.FileName;
      int lastSlash = fullPath.LastIndexOf('\\');

      txtSourceFile.Text = fullPath.Substring(lastSlash + 1);
    }

    private void dlgSelectDestination_FileOk(object sender, CancelEventArgs e)
    {
      string fullPath = dlgSelectDestination.FileName;
      int lastSlash = fullPath.LastIndexOf('\\');

      txtDestinationFile.Text = fullPath.Substring(lastSlash + 1);
    }

    private void listSourceFiles_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (null != listSourceFiles.SelectedItem)
      {
        try
        {
          txtSourceFile.Text = listSourceFiles.SelectedItem.ToString();
          selectedFile = txtSourceFile.Text;
          txtSelectedFile.Text = selectedFile;

          txtComments.Text = CListHandler.FindbyFilename(txtSourceFile.Text).comments;
        }
        catch (Exception ex)
        {
          string iex = "";
          if (ex.InnerException != null)
          {
            iex = "\n" + ex.InnerException.ToString();
          }
          MessageBox.Show("Exception (listSourceFiles_SelectedIndexChanged):\n" +
                           ex.Message.ToString() + iex);
        }
      }
    }

    private void btnDoIt_Click(object sender, EventArgs e)
    {
      if ((txtSourceFile.Text.Length > 0) && (txtDestinationFile.Text.Length > 0))
      {
        DialogResult msgStatus;
        String SaveOrRestore;

        if (radioSave.Checked == true)
        {
          SaveOrRestore = "SAVE ";
        }
        else
        {
          SaveOrRestore = "RESTORE ";
        }

        string msgText = SaveOrRestore + txtSourceFile.Text + " to " + txtDestinationFile.Text + "?";
        msgStatus = MessageBox.Show(msgText, "Confirm", MessageBoxButtons.OKCancel);

        if (msgStatus == DialogResult.OK)
        {
          string sourceFull = txtSourceFolder.Text + "\\" + txtSourceFile.Text;
          FileInfo sourceFI = new FileInfo(sourceFull);

          string destFull = txtDestinationFolder.Text + "\\" + txtDestinationFile.Text;
          FileInfo destFI = new FileInfo(destFull);

          bool copyFile = true;

          if (destFI.Exists)
          {
            msgStatus = MessageBox.Show("File exists - overwrite?", "", MessageBoxButtons.OKCancel);
            if (msgStatus == DialogResult.Cancel)
            {
              copyFile = false;
            }
          }

          if (copyFile)
          {
            File.Copy(sourceFull, destFull, true);

            if (radioRestore.Checked == true)
            {
              CListHandler.SetRestoredFileComments(txtSourceFile.Text, txtDestinationFile.Text);
            }

            updateInfo();
            updateFileLists();
            //CListHandler.Save();
          }
        }
      }
      else
      {
        MessageBox.Show("Please specify both source and destination file names");
      }
    }

    private void listDestinationFiles_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        txtDestinationFile.Text = listDestinationFiles.SelectedItem.ToString();

        selectedFile = txtDestinationFile.Text;
        txtSelectedFile.Text = selectedFile;

        txtComments.Text = CListHandler.FindbyFilename(selectedFile).comments;
      }
      catch
      {
      }
    }

    private void updateInfo()
    {
      string comments = txtComments.Text;

      CListHandler.Replace(selectedFile, comments);
      CListHandler.Save();
    }

    private void btnSaveComments_Click(object sender, EventArgs e)
    {
      updateInfo();
    }

    private void txtDestinationFile_TextChanged(object sender, EventArgs e)
    {
      selectedFile = txtDestinationFile.Text;
      txtSelectedFile.Text = selectedFile;
      txtComments.Text = CListHandler.FindbyFilename(selectedFile).comments;
    }

    public void InitializeByGame(string currentGame)
    {
      comboSelectedGame.Text = currentGame;

      string myDocuments = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
      //string gameFileInfo = "";

      string userName = Environment.UserName;

      if (currentGame == "Dark Souls I")
      {
        SourceSaves = "C:\\Users\\" + userName + "\\Documents\\NBGI\\DarkSouls";
        //BackupSaves = "D:\\UserData\\Games\\Dark Souls\\Backup Saves";
        BackupSaves = myDocuments + "\\Dark Souls\\Backup Saves";
        DarkSoulsSaveFile = "draks0005.sl2";
        //gameFileInfo = myDocuments + "\\_DARKSOULS_GameFileInfo.xml";
        gameFileInfo = BackupSaves + "\\_DARKSOULSI_GameFileInfo.xml";
      }
      if (currentGame == "Dark Souls II")
      {
        SourceSaves = "C:\\Users\\" + userName + "\\AppData\\Roaming\\DarkSoulsII\\0110000103a96006";
        //BackupSaves = "D:\\UserData\\Games\\Dark Souls II\\Backup Saves";
        BackupSaves = myDocuments + "\\Dark Souls II\\Backup Saves";
        DarkSoulsSaveFile = "DARKSII0000.sl2";
        //gameFileInfo = myDocuments + "\\_DARKSOULSII_GameFileInfo.xml";
        gameFileInfo = BackupSaves + "\\_DARKSOULSII_GameFileInfo.xml";
      }
      //C:\Users\us\AppData\Roaming\DarkSoulsIII\0110000103a96006

      if (currentGame == "Dark Souls III")
      {
        SourceSaves = "C:\\Users\\" + userName + "\\AppData\\Roaming\\DarkSoulsIII\\0110000103a96006";
        //BackupSaves = "D:\\UserData\\Games\\Dark Souls III\\Backup Saves";
        BackupSaves = myDocuments + "\\Dark Souls III\\Backup Saves";
        DarkSoulsSaveFile = "DS30000.sl2";
        //gameFileInfo = myDocuments + "\\_DARKSOULSII_GameFileInfo.xml";
        gameFileInfo = BackupSaves + "\\_DARKSOULSIII_GameFileInfo.xml";
      }

      if (!System.IO.Directory.Exists(BackupSaves))
      {
        try
        {
          System.IO.Directory.CreateDirectory(BackupSaves);
        }
        catch (Exception e)
        {
          MessageBox.Show("Unable to create save file folder:\n" + BackupSaves + "\n" + e.Message);          
        }
      }     

      dlgSelectSource.InitialDirectory = SourceSaves;
      dlgSelectDestination.InitialDirectory = BackupSaves;

      txtSourceFolder.Text = SourceSaves;
      txtDestinationFolder.Text = BackupSaves;

      CListHandler.siList.Clear();
      CListHandler.SetDatFile(gameFileInfo);
      CListHandler.Load();

      txtSourceFile.Text = DarkSoulsSaveFile;
      updateFileLists();
    }

    private void comboSelectedGame_SelectedIndexChanged(object sender, EventArgs e)
    {
      radioSave.Checked = true;

      InitializeByGame(comboSelectedGame.Text);
    }
  }
}
