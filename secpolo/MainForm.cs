using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Codeplex.Data;

namespace secpolo {
    public partial class MainForm : Form{



        private readonly Facebook _facebook;

        private readonly FriendListView _listViewFriend1;
        private readonly FriendListView _listViewFriend2;
        private readonly SpamListView _listViewSpam;

        readonly ListDat _listDat = new ListDat();

        private OneDat _oneDat = null;

        public MainForm() {
            InitializeComponent();
            textBoxUName.Enabled = false;

            _facebook = new Facebook();
            _facebook.Complete += _facebook_Complete;

            _listViewSpam = new SpamListView(listViewSpam, _facebook);

            _listViewFriend1 = new FriendListView(listViewFriend1, panelFriendList1, labelFriendList1, _listViewSpam);
            _listViewFriend1.Complete += _listViewFriend_Complete;

            _listViewFriend2 = new FriendListView(listViewFriend2, panelFriendList2, labelFriendList2, _listViewSpam);
            _listViewFriend2.Complete += _listViewFriend_Complete;


        }

        void _listViewFriend_Complete(OneDat oneDat) {
            if (oneDat != null){
                _listDat.Add(oneDat);
            }
        }

        void _facebook_Complete(string accessToken) {
            textBoxUName.Enabled = true;
        }

        void DispMain(){
            if (_oneDat == null){
                pictureBox1.Image = null;
                textBoxId.Text = "";
                textBoxName.Text = "";
            } else{
                textBoxName.Text = _oneDat.Name;
                textBoxId.Text = _oneDat.Id;
                textBoxUName.Text = _oneDat.UserName;
                pictureBox1.Image = _oneDat.Image;
            }
        }


        void Refresh(){

            _listViewFriend1.Stop();
            _listViewFriend2.Stop();

            _listViewFriend1.Clear();
            _listViewFriend2.Clear();

            
            //個人情報取得
            _oneDat = null;
            DispMain();
            
            var uname = textBoxUName.Text;
            var oneDat = _listDat.GetByUName(uname);
            if (oneDat == null){

                oneDat = _facebook.CreateOneDat(uname);
                if (oneDat == null){
                    return;
                }
            }
            _listDat.Add(oneDat);
            _oneDat = oneDat;

            DispMain();

            //友達一覧
            _listViewFriend1.Refresh(oneDat);
        }

        //UserNameでエンターキー
        private void textBoxUName_KeyDown(object sender, KeyEventArgs e){
            if (e.KeyCode == Keys.Enter){
                Refresh();
            }
        }

        private void MainMenuExit_Click(object sender, EventArgs e) {
            Close();
        }

        //URLのドロップ
        private void panelFriend_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.All;
        }
        private void panelFriend_DragDrop(object sender, DragEventArgs e) {
            var str = (String)e.Data.GetData(DataFormats.Text);
            var userName = Util.GetUserName(str);
            if (userName != null && textBoxUName.Text != userName) {
                textBoxUName.Text = userName;
                Refresh();
            }
        }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            _listViewSpam.Dispose();
        }

        OneDat Selected(ListView listView){
            var items = listView.SelectedItems;
            if (items.Count > 0){
                return (OneDat) items[0].Tag;
            }
            return null;
        }

        //（FriendList1のメニュー）友達の友達一覧
        private void popupMenuFriendList_Click(object sender, EventArgs e){
            var oneDat = Selected(listViewFriend1);
            if (oneDat != null) {
                //友達の友達一覧
                _listViewFriend2.Refresh(oneDat);
            }
        }
        //（FriendList1のメニュー）ホーム
        private void popupMenuBrowse_Click(object sender, EventArgs e) {
            var oneDat = Selected(listViewFriend1);
            if (oneDat != null){
                Util.Home(oneDat.Id);
            }
        }
        //（FriendList1)ダブルクリック
        private void listViewFriend1_DoubleClick(object sender, EventArgs e) {
            var oneDat = Selected(listViewFriend1);
            if (oneDat != null){
                Util.Home(oneDat.Id);
            }
        }
        //（FriendList2)ダブルクリック
        private void listViewFriend2_DoubleClick(object sender, EventArgs e) {
            var oneDat = Selected(listViewFriend2);
            if (oneDat != null) {
                Util.Home(oneDat.Id);
            }
        }

        //（SpamListのメニュー）削除
        private void popupMenuDeleteSpam_Click(object sender, EventArgs e) {
            var oneDat = Selected(listViewSpam);
            if (oneDat != null) {
                if (DialogResult.OK == MessageBox.Show(String.Format("{0}({1})を削除してよろしいですか?", oneDat.Name, oneDat.Id), "削除確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)) {
                    _listViewSpam.Remove(oneDat);
                }
            }
       }
        //（SpamListのメニュー）ホーム
        private void popupMenuHome_Click(object sender, EventArgs e) {
            var oneDat = Selected(listViewSpam);
            if (oneDat != null){
                Util.Home(oneDat.Id);
            }
        }

        //（SpamListのメニュー）google検索
        private void popupMenuGoogle_Click(object sender, EventArgs e) {
            var oneDat = Selected(listViewSpam);
            if (oneDat != null){
                var str = Uri.EscapeDataString(oneDat.Name);
                Process.Start(String.Format("http://www.google.co.jp/#output=search&q={0}", str));
            }
        }
        //（SpamListのメニュー）Facebook検索
        private void popupMenuSearchFacebook_Click(object sender, EventArgs e){
            var oneDat = Selected(listViewSpam);
            if (oneDat != null){
                var dlg = new SearchDlg(oneDat.Name, _facebook, _listViewSpam);
                dlg.Show();
            }
        }
        //「ツール」ー「Facebook検索」
        private void MainMenuSearch_Click(object sender, EventArgs e) {
            var dlg = new SearchDlg("", _facebook,_listViewSpam);
            dlg.Show();
        }

        //（SpamList)ダブルクリック
        private void listViewSpam_DoubleClick(object sender, EventArgs e) {
            var oneDat = Selected(listViewSpam);
            if (oneDat != null) {
                Util.Home(oneDat.Id);
            }
        }

        private void MainFormFind_Click(object sender, EventArgs e){
            var dlg = new FindDlg();
            if (DialogResult.OK == dlg.ShowDialog()){
                var str = dlg.Str;
                if (tabControl.SelectedIndex == 1){
                    _listViewSpam.Find(str);
                } else{
                    _listViewFriend1.Find(str);
                    _listViewFriend2.Find(str);
                    
                }
            }
        }
    }
}
