using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace secpolo {
    class FriendListView{
        private readonly ListView _listView;
        private readonly ImageList _imageList;
        private readonly List<OneDat> _ar = new List<OneDat>();
        private Label _label;
        private Panel _panel;

        private SpamListView _spanListView;

        private Color _color;
        private OneDat _target=null; //検索対象
        private int _spamCount = 0;


        CreateFriendList _createFriendList = null;

        //友達が取得できた時のイベント
        public delegate void CompleteDelegate(OneDat oneDat);
        public event CompleteDelegate Complete;

        public FriendListView(ListView listView, Panel panel, Label label, SpamListView spanListView) {
            _listView = listView;
            _listView.HideSelection = false;
            _label = label;
            _panel = panel;
            _spanListView = spanListView;

            _imageList = new ImageList();
            _imageList.ImageSize = new Size(50,50);

            _listView = listView;
            _listView.LargeImageList = _imageList;
        }

        public void Stop(){
            _panel.BackColor = _color;
            if (_createFriendList != null) {
                _createFriendList.Complete -= CreateFriendList_Complete;
                _createFriendList.Dispose();
            }
        }

        public void Refresh(OneDat oneDat){

            Stop();

            Clear();

            _target = oneDat;
            _color = _panel.BackColor;
            _panel.BackColor = Color.LightBlue;

            _label.Text =string.Format("「{0}」 の友達　検索開始   スパム={1}",_target.Name,_spamCount);



            var url = String.Format("https://www.facebook.com/profile.php?id={0}&sk=friends",oneDat.Id);
            _createFriendList = new CreateFriendList(url);
            _createFriendList.Complete += CreateFriendList_Complete;
        }

        private void CreateFriendList_Complete(OneDat oneDat){

            if (Complete != null){
                Complete(oneDat);
            }

            if (oneDat == null){
                //完了
                _panel.BackColor = _color;
                _label.Text = String.Format("「{0}」 の友達 {1}人  スパム {2}", _target.Name,_ar.Count,_spamCount);
            } else{
                Add(oneDat);
                _label.Text = string.Format("「{0}」 の友達 検索中...{1} スパム {2}", _target.Name, _ar.Count,_spamCount);
            }
        }


        public void Clear(){
            _listView.Items.Clear();
            _imageList.Images.Clear();
            _ar.Clear();
            _spamCount = 0;

            _panel.BackColor = _color;
            _label.Text = "";

        }

        void Add(OneDat oneDat){
            _ar.Add(oneDat);
            
            _imageList.Images.Add(oneDat.Image);

            var item = _listView.Items.Add(oneDat.Name, _ar.Count - 1);
            item.SubItems.Add(oneDat.Id);
            item.SubItems.Add(oneDat.Jpg);
            item.Tag = oneDat;

            if (_spanListView.IsSpam(oneDat.Id)){
                item.ForeColor = Color.Red;
                item.BackColor = Color.Pink;
                item.Font = new Font("Arial", 11, FontStyle.Bold);
                _spamCount++;
            }
        }

        //検索
        public void Find(String str) {
            _listView.SelectedItems.Clear();
            foreach (ListViewItem item in _listView.Items) {
                var oneDat = (OneDat)item.Tag;
                if (oneDat.Name.IndexOf(str) == 0) {
                    item.Selected = true;
                    item.EnsureVisible();
                    return;
                }
            }
        }

    }
}
