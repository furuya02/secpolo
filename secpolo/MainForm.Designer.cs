namespace secpolo {
    partial class MainForm {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MainMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuTool = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.MainFormFind = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainerFriend = new System.Windows.Forms.SplitContainer();
            this.listViewFriend1 = new System.Windows.Forms.ListView();
            this.PopupMenuFriendList1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.popupMenuBrowse = new System.Windows.Forms.ToolStripMenuItem();
            this.popupMenuFriendList = new System.Windows.Forms.ToolStripMenuItem();
            this.panelFriendList1 = new System.Windows.Forms.Panel();
            this.buttonFriendList1 = new System.Windows.Forms.Button();
            this.labelFriendList1 = new System.Windows.Forms.Label();
            this.listViewFriend2 = new System.Windows.Forms.ListView();
            this.panelFriendList2 = new System.Windows.Forms.Panel();
            this.buttonFriendList2 = new System.Windows.Forms.Button();
            this.labelFriendList2 = new System.Windows.Forms.Label();
            this.panelFriend = new System.Windows.Forms.Panel();
            this.textBoxUName = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listViewSpam = new System.Windows.Forms.ListView();
            this.popupMenuSpam = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.popupMenuHome = new System.Windows.Forms.ToolStripMenuItem();
            this.popupMenuSearchFacebook = new System.Windows.Forms.ToolStripMenuItem();
            this.popupMenuGoogle = new System.Windows.Forms.ToolStripMenuItem();
            this.popupMenuDeleteSpam = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFriend)).BeginInit();
            this.splitContainerFriend.Panel1.SuspendLayout();
            this.splitContainerFriend.Panel2.SuspendLayout();
            this.splitContainerFriend.SuspendLayout();
            this.PopupMenuFriendList1.SuspendLayout();
            this.panelFriendList1.SuspendLayout();
            this.panelFriendList2.SuspendLayout();
            this.panelFriend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.popupMenuSpam.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 529);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(708, 22);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuFile,
            this.MainMenuTool});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(708, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MainMenuFile
            // 
            this.MainMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuExit});
            this.MainMenuFile.Name = "MainMenuFile";
            this.MainMenuFile.Size = new System.Drawing.Size(70, 20);
            this.MainMenuFile.Text = "ファイル(&F)";
            // 
            // MainMenuExit
            // 
            this.MainMenuExit.Name = "MainMenuExit";
            this.MainMenuExit.Size = new System.Drawing.Size(116, 22);
            this.MainMenuExit.Text = "終了(&X)";
            this.MainMenuExit.Click += new System.EventHandler(this.MainMenuExit_Click);
            // 
            // MainMenuTool
            // 
            this.MainMenuTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuSearch,
            this.MainFormFind});
            this.MainMenuTool.Name = "MainMenuTool";
            this.MainMenuTool.Size = new System.Drawing.Size(66, 20);
            this.MainMenuTool.Text = "ツール(&T)";
            // 
            // MainMenuSearch
            // 
            this.MainMenuSearch.Name = "MainMenuSearch";
            this.MainMenuSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.MainMenuSearch.Size = new System.Drawing.Size(218, 22);
            this.MainMenuSearch.Text = "Facdbook検索(&S)";
            this.MainMenuSearch.Click += new System.EventHandler(this.MainMenuSearch_Click);
            // 
            // MainFormFind
            // 
            this.MainFormFind.Name = "MainFormFind";
            this.MainFormFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.MainFormFind.Size = new System.Drawing.Size(218, 22);
            this.MainFormFind.Text = "検索(&F)";
            this.MainFormFind.Click += new System.EventHandler(this.MainFormFind_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(708, 505);
            this.tabControl.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainerFriend);
            this.tabPage1.Controls.Add(this.panelFriend);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(700, 479);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Friends";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainerFriend
            // 
            this.splitContainerFriend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFriend.Location = new System.Drawing.Point(3, 87);
            this.splitContainerFriend.Name = "splitContainerFriend";
            this.splitContainerFriend.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerFriend.Panel1
            // 
            this.splitContainerFriend.Panel1.Controls.Add(this.listViewFriend1);
            this.splitContainerFriend.Panel1.Controls.Add(this.panelFriendList1);
            // 
            // splitContainerFriend.Panel2
            // 
            this.splitContainerFriend.Panel2.Controls.Add(this.listViewFriend2);
            this.splitContainerFriend.Panel2.Controls.Add(this.panelFriendList2);
            this.splitContainerFriend.Size = new System.Drawing.Size(694, 389);
            this.splitContainerFriend.SplitterDistance = 199;
            this.splitContainerFriend.TabIndex = 3;
            // 
            // listViewFriend1
            // 
            this.listViewFriend1.ContextMenuStrip = this.PopupMenuFriendList1;
            this.listViewFriend1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFriend1.Location = new System.Drawing.Point(0, 0);
            this.listViewFriend1.Name = "listViewFriend1";
            this.listViewFriend1.Size = new System.Drawing.Size(694, 170);
            this.listViewFriend1.TabIndex = 2;
            this.listViewFriend1.UseCompatibleStateImageBehavior = false;
            this.listViewFriend1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewFriend1_ItemDrag);
            this.listViewFriend1.DoubleClick += new System.EventHandler(this.listViewFriend1_DoubleClick);
            // 
            // PopupMenuFriendList1
            // 
            this.PopupMenuFriendList1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.popupMenuBrowse,
            this.popupMenuFriendList});
            this.PopupMenuFriendList1.Name = "PopupMenuFriendList1";
            this.PopupMenuFriendList1.Size = new System.Drawing.Size(140, 48);
            // 
            // popupMenuBrowse
            // 
            this.popupMenuBrowse.Name = "popupMenuBrowse";
            this.popupMenuBrowse.Size = new System.Drawing.Size(139, 22);
            this.popupMenuBrowse.Text = "ホーム(&H)";
            this.popupMenuBrowse.Click += new System.EventHandler(this.popupMenuBrowse_Click);
            // 
            // popupMenuFriendList
            // 
            this.popupMenuFriendList.Name = "popupMenuFriendList";
            this.popupMenuFriendList.Size = new System.Drawing.Size(139, 22);
            this.popupMenuFriendList.Text = "友達一覧(&F)";
            this.popupMenuFriendList.Click += new System.EventHandler(this.popupMenuFriendList_Click);
            // 
            // panelFriendList1
            // 
            this.panelFriendList1.BackColor = System.Drawing.SystemColors.Control;
            this.panelFriendList1.Controls.Add(this.buttonFriendList1);
            this.panelFriendList1.Controls.Add(this.labelFriendList1);
            this.panelFriendList1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFriendList1.Location = new System.Drawing.Point(0, 170);
            this.panelFriendList1.Name = "panelFriendList1";
            this.panelFriendList1.Size = new System.Drawing.Size(694, 29);
            this.panelFriendList1.TabIndex = 1;
            // 
            // buttonFriendList1
            // 
            this.buttonFriendList1.Image = ((System.Drawing.Image)(resources.GetObject("buttonFriendList1.Image")));
            this.buttonFriendList1.Location = new System.Drawing.Point(5, 3);
            this.buttonFriendList1.Name = "buttonFriendList1";
            this.buttonFriendList1.Size = new System.Drawing.Size(32, 23);
            this.buttonFriendList1.TabIndex = 1;
            this.buttonFriendList1.UseVisualStyleBackColor = true;
            // 
            // labelFriendList1
            // 
            this.labelFriendList1.AutoSize = true;
            this.labelFriendList1.Location = new System.Drawing.Point(43, 8);
            this.labelFriendList1.Name = "labelFriendList1";
            this.labelFriendList1.Size = new System.Drawing.Size(35, 12);
            this.labelFriendList1.TabIndex = 0;
            this.labelFriendList1.Text = "label2";
            // 
            // listViewFriend2
            // 
            this.listViewFriend2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFriend2.Location = new System.Drawing.Point(0, 0);
            this.listViewFriend2.Name = "listViewFriend2";
            this.listViewFriend2.Size = new System.Drawing.Size(694, 157);
            this.listViewFriend2.TabIndex = 1;
            this.listViewFriend2.UseCompatibleStateImageBehavior = false;
            this.listViewFriend2.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewFriend2_ItemDrag);
            this.listViewFriend2.DoubleClick += new System.EventHandler(this.listViewFriend2_DoubleClick);
            // 
            // panelFriendList2
            // 
            this.panelFriendList2.BackColor = System.Drawing.SystemColors.Control;
            this.panelFriendList2.Controls.Add(this.buttonFriendList2);
            this.panelFriendList2.Controls.Add(this.labelFriendList2);
            this.panelFriendList2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFriendList2.Location = new System.Drawing.Point(0, 157);
            this.panelFriendList2.Name = "panelFriendList2";
            this.panelFriendList2.Size = new System.Drawing.Size(694, 29);
            this.panelFriendList2.TabIndex = 0;
            // 
            // buttonFriendList2
            // 
            this.buttonFriendList2.Image = ((System.Drawing.Image)(resources.GetObject("buttonFriendList2.Image")));
            this.buttonFriendList2.Location = new System.Drawing.Point(3, 2);
            this.buttonFriendList2.Name = "buttonFriendList2";
            this.buttonFriendList2.Size = new System.Drawing.Size(32, 23);
            this.buttonFriendList2.TabIndex = 2;
            this.buttonFriendList2.UseVisualStyleBackColor = true;
            // 
            // labelFriendList2
            // 
            this.labelFriendList2.AutoSize = true;
            this.labelFriendList2.Location = new System.Drawing.Point(41, 7);
            this.labelFriendList2.Name = "labelFriendList2";
            this.labelFriendList2.Size = new System.Drawing.Size(35, 12);
            this.labelFriendList2.TabIndex = 0;
            this.labelFriendList2.Text = "label1";
            // 
            // panelFriend
            // 
            this.panelFriend.AllowDrop = true;
            this.panelFriend.BackColor = System.Drawing.SystemColors.Control;
            this.panelFriend.Controls.Add(this.textBoxUName);
            this.panelFriend.Controls.Add(this.textBoxId);
            this.panelFriend.Controls.Add(this.labelUserName);
            this.panelFriend.Controls.Add(this.labelId);
            this.panelFriend.Controls.Add(this.pictureBox1);
            this.panelFriend.Controls.Add(this.labelName);
            this.panelFriend.Controls.Add(this.textBoxName);
            this.panelFriend.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFriend.Location = new System.Drawing.Point(3, 3);
            this.panelFriend.Name = "panelFriend";
            this.panelFriend.Size = new System.Drawing.Size(694, 84);
            this.panelFriend.TabIndex = 2;
            this.panelFriend.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelFriend_DragDrop);
            this.panelFriend.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelFriend_DragEnter);
            // 
            // textBoxUName
            // 
            this.textBoxUName.Location = new System.Drawing.Point(119, 58);
            this.textBoxUName.Name = "textBoxUName";
            this.textBoxUName.Size = new System.Drawing.Size(168, 19);
            this.textBoxUName.TabIndex = 7;
            this.textBoxUName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUName_KeyDown);
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(119, 33);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(168, 19);
            this.textBoxId.TabIndex = 6;
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(78, 61);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(38, 12);
            this.labelUserName.TabIndex = 5;
            this.labelUserName.Text = "uname";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(78, 36);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(14, 12);
            this.labelId.TabIndex = 4;
            this.labelId.Text = "id";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(5, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(78, 12);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(32, 12);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(119, 9);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(168, 19);
            this.textBoxName.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listViewSpam);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(700, 479);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Spam";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listViewSpam
            // 
            this.listViewSpam.ContextMenuStrip = this.popupMenuSpam;
            this.listViewSpam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSpam.Location = new System.Drawing.Point(3, 3);
            this.listViewSpam.Name = "listViewSpam";
            this.listViewSpam.Size = new System.Drawing.Size(694, 473);
            this.listViewSpam.TabIndex = 3;
            this.listViewSpam.UseCompatibleStateImageBehavior = false;
            this.listViewSpam.DoubleClick += new System.EventHandler(this.listViewSpam_DoubleClick);
            // 
            // popupMenuSpam
            // 
            this.popupMenuSpam.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.popupMenuHome,
            this.popupMenuSearchFacebook,
            this.popupMenuGoogle,
            this.popupMenuDeleteSpam});
            this.popupMenuSpam.Name = "popupMenuSpam";
            this.popupMenuSpam.Size = new System.Drawing.Size(218, 92);
            // 
            // popupMenuHome
            // 
            this.popupMenuHome.Name = "popupMenuHome";
            this.popupMenuHome.Size = new System.Drawing.Size(217, 22);
            this.popupMenuHome.Text = "ホーム(&H)";
            this.popupMenuHome.Click += new System.EventHandler(this.popupMenuHome_Click);
            // 
            // popupMenuSearchFacebook
            // 
            this.popupMenuSearchFacebook.Name = "popupMenuSearchFacebook";
            this.popupMenuSearchFacebook.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.popupMenuSearchFacebook.Size = new System.Drawing.Size(217, 22);
            this.popupMenuSearchFacebook.Text = "Facebook検索(&F)";
            this.popupMenuSearchFacebook.Click += new System.EventHandler(this.popupMenuSearchFacebook_Click);
            // 
            // popupMenuGoogle
            // 
            this.popupMenuGoogle.Name = "popupMenuGoogle";
            this.popupMenuGoogle.Size = new System.Drawing.Size(217, 22);
            this.popupMenuGoogle.Text = "google検索(&G)";
            this.popupMenuGoogle.Click += new System.EventHandler(this.popupMenuGoogle_Click);
            // 
            // popupMenuDeleteSpam
            // 
            this.popupMenuDeleteSpam.Name = "popupMenuDeleteSpam";
            this.popupMenuDeleteSpam.Size = new System.Drawing.Size(217, 22);
            this.popupMenuDeleteSpam.Text = "削除(&D)";
            this.popupMenuDeleteSpam.Click += new System.EventHandler(this.popupMenuDeleteSpam_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 551);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Spam Friend　Ver b0.0.3 2013.07.29";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainerFriend.Panel1.ResumeLayout(false);
            this.splitContainerFriend.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFriend)).EndInit();
            this.splitContainerFriend.ResumeLayout(false);
            this.PopupMenuFriendList1.ResumeLayout(false);
            this.panelFriendList1.ResumeLayout(false);
            this.panelFriendList1.PerformLayout();
            this.panelFriendList2.ResumeLayout(false);
            this.panelFriendList2.PerformLayout();
            this.panelFriend.ResumeLayout(false);
            this.panelFriend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.popupMenuSpam.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MainMenuFile;
        private System.Windows.Forms.ToolStripMenuItem MainMenuExit;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainerFriend;
        private System.Windows.Forms.Panel panelFriend;
        private System.Windows.Forms.TextBox textBoxUName;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Panel panelFriendList2;
        private System.Windows.Forms.Label labelFriendList2;
        private System.Windows.Forms.ListView listViewFriend2;
        private System.Windows.Forms.ListView listViewFriend1;
        private System.Windows.Forms.Panel panelFriendList1;
        private System.Windows.Forms.Label labelFriendList1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listViewSpam;
        private System.Windows.Forms.ContextMenuStrip popupMenuSpam;
        private System.Windows.Forms.ToolStripMenuItem popupMenuDeleteSpam;
        private System.Windows.Forms.ContextMenuStrip PopupMenuFriendList1;
        private System.Windows.Forms.ToolStripMenuItem popupMenuBrowse;
        private System.Windows.Forms.ToolStripMenuItem popupMenuFriendList;
        private System.Windows.Forms.ToolStripMenuItem popupMenuHome;
        private System.Windows.Forms.ToolStripMenuItem popupMenuGoogle;
        private System.Windows.Forms.ToolStripMenuItem popupMenuSearchFacebook;
        private System.Windows.Forms.ToolStripMenuItem MainMenuTool;
        private System.Windows.Forms.ToolStripMenuItem MainMenuSearch;
        private System.Windows.Forms.ToolStripMenuItem MainFormFind;
        private System.Windows.Forms.Button buttonFriendList1;
        private System.Windows.Forms.Button buttonFriendList2;

    }
}

