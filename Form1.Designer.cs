namespace SaveGameFiles
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.txtSourceFolder = new System.Windows.Forms.TextBox();
      this.txtDestinationFolder = new System.Windows.Forms.TextBox();
      this.btnSource = new System.Windows.Forms.Button();
      this.btnDestination = new System.Windows.Forms.Button();
      this.dlgSelectSource = new System.Windows.Forms.OpenFileDialog();
      this.dlgSelectDestination = new System.Windows.Forms.OpenFileDialog();
      this.radioSave = new System.Windows.Forms.RadioButton();
      this.radioRestore = new System.Windows.Forms.RadioButton();
      this.txtSourceFile = new System.Windows.Forms.TextBox();
      this.txtDestinationFile = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.listSourceFiles = new System.Windows.Forms.ListBox();
      this.listDestinationFiles = new System.Windows.Forms.ListBox();
      this.btnDoIt = new System.Windows.Forms.Button();
      this.txtComments = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.btnSaveComments = new System.Windows.Forms.Button();
      this.txtSelectedFile = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.comboSelectedGame = new System.Windows.Forms.ComboBox();
      this.label7 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // txtSourceFolder
      // 
      this.txtSourceFolder.BackColor = System.Drawing.SystemColors.Info;
      this.txtSourceFolder.Location = new System.Drawing.Point(162, 78);
      this.txtSourceFolder.Name = "txtSourceFolder";
      this.txtSourceFolder.ReadOnly = true;
      this.txtSourceFolder.Size = new System.Drawing.Size(421, 20);
      this.txtSourceFolder.TabIndex = 1;
      // 
      // txtDestinationFolder
      // 
      this.txtDestinationFolder.BackColor = System.Drawing.SystemColors.Info;
      this.txtDestinationFolder.Location = new System.Drawing.Point(162, 151);
      this.txtDestinationFolder.Name = "txtDestinationFolder";
      this.txtDestinationFolder.ReadOnly = true;
      this.txtDestinationFolder.Size = new System.Drawing.Size(421, 20);
      this.txtDestinationFolder.TabIndex = 2;
      // 
      // btnSource
      // 
      this.btnSource.Location = new System.Drawing.Point(45, 76);
      this.btnSource.Name = "btnSource";
      this.btnSource.Size = new System.Drawing.Size(111, 23);
      this.btnSource.TabIndex = 4;
      this.btnSource.Text = "Source Folder";
      this.btnSource.UseVisualStyleBackColor = true;
      this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
      // 
      // btnDestination
      // 
      this.btnDestination.Location = new System.Drawing.Point(45, 151);
      this.btnDestination.Name = "btnDestination";
      this.btnDestination.Size = new System.Drawing.Size(111, 23);
      this.btnDestination.TabIndex = 5;
      this.btnDestination.Text = "Destination Folder";
      this.btnDestination.UseVisualStyleBackColor = true;
      this.btnDestination.Click += new System.EventHandler(this.btnDestination_Click);
      // 
      // dlgSelectSource
      // 
      this.dlgSelectSource.DefaultExt = "sl2";
      this.dlgSelectSource.FileName = "draks0005.sl2";
      this.dlgSelectSource.FileOk += new System.ComponentModel.CancelEventHandler(this.dlgSelectSource_FileOk);
      // 
      // radioSave
      // 
      this.radioSave.AutoSize = true;
      this.radioSave.Checked = true;
      this.radioSave.Location = new System.Drawing.Point(57, 49);
      this.radioSave.Name = "radioSave";
      this.radioSave.Size = new System.Drawing.Size(50, 17);
      this.radioSave.TabIndex = 6;
      this.radioSave.TabStop = true;
      this.radioSave.Text = "Save";
      this.radioSave.UseVisualStyleBackColor = true;
      this.radioSave.CheckedChanged += new System.EventHandler(this.radioSave_CheckedChanged);
      // 
      // radioRestore
      // 
      this.radioRestore.AutoSize = true;
      this.radioRestore.Location = new System.Drawing.Point(142, 49);
      this.radioRestore.Name = "radioRestore";
      this.radioRestore.Size = new System.Drawing.Size(62, 17);
      this.radioRestore.TabIndex = 7;
      this.radioRestore.Text = "Restore";
      this.radioRestore.UseVisualStyleBackColor = true;
      this.radioRestore.CheckedChanged += new System.EventHandler(this.radioRestore_CheckedChanged);
      // 
      // txtSourceFile
      // 
      this.txtSourceFile.BackColor = System.Drawing.SystemColors.Info;
      this.txtSourceFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtSourceFile.ForeColor = System.Drawing.Color.Black;
      this.txtSourceFile.Location = new System.Drawing.Point(162, 104);
      this.txtSourceFile.Name = "txtSourceFile";
      this.txtSourceFile.ReadOnly = true;
      this.txtSourceFile.Size = new System.Drawing.Size(229, 20);
      this.txtSourceFile.TabIndex = 8;
      // 
      // txtDestinationFile
      // 
      this.txtDestinationFile.Location = new System.Drawing.Point(162, 179);
      this.txtDestinationFile.Name = "txtDestinationFile";
      this.txtDestinationFile.Size = new System.Drawing.Size(229, 20);
      this.txtDestinationFile.TabIndex = 9;
      this.txtDestinationFile.TextChanged += new System.EventHandler(this.txtDestinationFile_TextChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(102, 107);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(54, 13);
      this.label1.TabIndex = 10;
      this.label1.Text = "File Name";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(62, 182);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(94, 13);
      this.label2.TabIndex = 11;
      this.label2.Text = "Backup File Name";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(42, 212);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(92, 13);
      this.label3.TabIndex = 14;
      this.label3.Text = "Original Game File";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(337, 212);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(68, 13);
      this.label4.TabIndex = 15;
      this.label4.Text = "Backup Files";
      // 
      // listSourceFiles
      // 
      this.listSourceFiles.FormattingEnabled = true;
      this.listSourceFiles.Location = new System.Drawing.Point(45, 228);
      this.listSourceFiles.Name = "listSourceFiles";
      this.listSourceFiles.Size = new System.Drawing.Size(260, 173);
      this.listSourceFiles.TabIndex = 16;
      this.listSourceFiles.SelectedIndexChanged += new System.EventHandler(this.listSourceFiles_SelectedIndexChanged);
      // 
      // listDestinationFiles
      // 
      this.listDestinationFiles.FormattingEnabled = true;
      this.listDestinationFiles.Location = new System.Drawing.Point(340, 228);
      this.listDestinationFiles.Name = "listDestinationFiles";
      this.listDestinationFiles.Size = new System.Drawing.Size(260, 173);
      this.listDestinationFiles.TabIndex = 17;
      this.listDestinationFiles.SelectedIndexChanged += new System.EventHandler(this.listDestinationFiles_SelectedIndexChanged);
      // 
      // btnDoIt
      // 
      this.btnDoIt.Location = new System.Drawing.Point(525, 46);
      this.btnDoIt.Name = "btnDoIt";
      this.btnDoIt.Size = new System.Drawing.Size(75, 23);
      this.btnDoIt.TabIndex = 18;
      this.btnDoIt.Text = "Do It!";
      this.btnDoIt.UseVisualStyleBackColor = true;
      this.btnDoIt.Click += new System.EventHandler(this.btnDoIt_Click);
      // 
      // txtComments
      // 
      this.txtComments.BackColor = System.Drawing.SystemColors.Window;
      this.txtComments.Location = new System.Drawing.Point(45, 442);
      this.txtComments.Multiline = true;
      this.txtComments.Name = "txtComments";
      this.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtComments.Size = new System.Drawing.Size(555, 93);
      this.txtComments.TabIndex = 19;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(42, 419);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(114, 13);
      this.label5.TabIndex = 20;
      this.label5.Text = "Comments/Description";
      // 
      // btnSaveComments
      // 
      this.btnSaveComments.Location = new System.Drawing.Point(162, 412);
      this.btnSaveComments.Name = "btnSaveComments";
      this.btnSaveComments.Size = new System.Drawing.Size(109, 26);
      this.btnSaveComments.TabIndex = 21;
      this.btnSaveComments.Text = "Update Comments";
      this.btnSaveComments.UseVisualStyleBackColor = true;
      this.btnSaveComments.Click += new System.EventHandler(this.btnSaveComments_Click);
      // 
      // txtSelectedFile
      // 
      this.txtSelectedFile.BackColor = System.Drawing.SystemColors.Info;
      this.txtSelectedFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtSelectedFile.ForeColor = System.Drawing.Color.Black;
      this.txtSelectedFile.Location = new System.Drawing.Point(277, 416);
      this.txtSelectedFile.Name = "txtSelectedFile";
      this.txtSelectedFile.ReadOnly = true;
      this.txtSelectedFile.Size = new System.Drawing.Size(323, 20);
      this.txtSelectedFile.TabIndex = 22;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(55, 9);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(250, 24);
      this.label6.TabIndex = 23;
      this.label6.Text = "Dark Souls Save Game Utility";
      // 
      // comboSelectedGame
      // 
      this.comboSelectedGame.FormattingEnabled = true;
      this.comboSelectedGame.Items.AddRange(new object[] {
            "Dark Souls I",
            "Dark Souls II",
            "Dark Souls III",
            "Ghost of a Tale"});
      this.comboSelectedGame.Location = new System.Drawing.Point(466, 14);
      this.comboSelectedGame.Name = "comboSelectedGame";
      this.comboSelectedGame.Size = new System.Drawing.Size(134, 21);
      this.comboSelectedGame.TabIndex = 24;
      this.comboSelectedGame.Text = "Dark Souls III";
      this.comboSelectedGame.SelectedIndexChanged += new System.EventHandler(this.comboSelectedGame_SelectedIndexChanged);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(392, 17);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(68, 13);
      this.label7.TabIndex = 25;
      this.label7.Text = "Select Game";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(667, 547);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.comboSelectedGame);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.txtSelectedFile);
      this.Controls.Add(this.btnSaveComments);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.txtComments);
      this.Controls.Add(this.btnDoIt);
      this.Controls.Add(this.listDestinationFiles);
      this.Controls.Add(this.listSourceFiles);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtDestinationFile);
      this.Controls.Add(this.txtSourceFile);
      this.Controls.Add(this.radioRestore);
      this.Controls.Add(this.radioSave);
      this.Controls.Add(this.btnDestination);
      this.Controls.Add(this.btnSource);
      this.Controls.Add(this.txtDestinationFolder);
      this.Controls.Add(this.txtSourceFolder);
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtSourceFolder;
    private System.Windows.Forms.TextBox txtDestinationFolder;
    private System.Windows.Forms.Button btnSource;
    private System.Windows.Forms.Button btnDestination;
    private System.Windows.Forms.OpenFileDialog dlgSelectSource;
    private System.Windows.Forms.OpenFileDialog dlgSelectDestination;
    private System.Windows.Forms.RadioButton radioSave;
    private System.Windows.Forms.RadioButton radioRestore;
    private System.Windows.Forms.TextBox txtSourceFile;
    private System.Windows.Forms.TextBox txtDestinationFile;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ListBox listSourceFiles;
    private System.Windows.Forms.ListBox listDestinationFiles;
    private System.Windows.Forms.Button btnDoIt;
    private System.Windows.Forms.TextBox txtComments;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button btnSaveComments;
    private System.Windows.Forms.TextBox txtSelectedFile;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ComboBox comboSelectedGame;
    private System.Windows.Forms.Label label7;
  }
}

