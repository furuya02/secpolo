using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace secpolo {
    public class SpamListView : IDisposable{
        private readonly ListView _listView;
        private readonly ImageList _imageList;
        private List<OneDat> _ar = new List<OneDat>();
        private const String FileName = "secpolo.db";
        private Facebook _facebook;

        public SpamListView(ListView listView,Facebook facebook){
            _facebook = facebook;

            _listView = listView;
            _listView.HideSelection = false;

            _listView.AllowDrop = true;
            _listView.DragEnter += _listView_DragEnter;
            _listView.DragDrop += _listView_DragDrop;

            _imageList = new ImageList();
            _imageList.ImageSize = new Size(50, 50);

            _listView = listView;
            _listView.LargeImageList = _imageList;

            _listView.ListViewItemSorter = new DelegateComparison(ItemCompare);


            Read();

            _listView.Sort();
        }

        int ItemCompare(object a, object b) {
            // 単純に型変換
            var _a = (OneDat)((ListViewItem)a).Tag;
            var _b = (OneDat)((ListViewItem)b).Tag;

            var result = _a.Name.CompareTo(_b.Name);

            if (result == 0){//名前が同じ場合は画像でソートする

//                ImageConverter ic = new ImageConverter();
//                byte[] byte1 = (byte[])ic.ConvertTo(_a.Image, typeof(byte[]));
//                byte[] byte2 = (byte[])ic.ConvertTo(_b.Image, typeof(byte[]));
//                if (byte1.SequenceEqual(byte2)){
//                    return 0;
//                }
//                for (int i = 0; i < byte1.Length; i++){
//                    return byte1[i].CompareTo(byte2[i]);
//                } 
                return _a.Id.CompareTo(_b.Id);
            }
            

            // 逆順ソートなら-1倍して返す。
            return result;
        }



        void _listView_DragDrop(object sender, DragEventArgs e) {
            var str = (String)e.Data.GetData(DataFormats.Text);

            string url = e.Data.GetData(DataFormats.Text).ToString();


            var userName = Util.GetUserName(str);
            if (userName != null){
                var oneDat = _facebook.CreateOneDat(userName);
                if (oneDat != null){
                    foreach (var a in _ar){
                        if (a.Id == oneDat.Id){
                            Util.TopMsg(String.Format("{0}({1})は、既に登録済みです", a.Name, a.Id));
                            return;
                        }
                    }
                    _ar.Add(oneDat);
                    var item = AddList(oneDat);
                    item.Selected = true;
                }
            }
        }

        void _listView_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent("UniformResourceLocator") == true){
                e.Effect = DragDropEffects.Link;
            } else{
                e.Effect = DragDropEffects.All;
            }
        }


        void Read() {
            if (File.Exists(FileName)){
                var fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                var f = new BinaryFormatter();
                _ar = (List<OneDat>)f.Deserialize(fs);
                fs.Close();
            }
            foreach (var a in _ar){
                AddList(a);
            }
        }

        void Save() {
            var fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            var bf = new BinaryFormatter();
            bf.Serialize(fs, _ar);
            fs.Close();
        }

        public bool IsSpam(String id){
            foreach (var a in _ar){
                if (a.Id == id){
                    return true;
                }
            }
            return false;
        }


        ListViewItem AddList(OneDat oneDat){
            _imageList.Images.Add(oneDat.Image);

            var str = String.Format("{0}\r\n({1})", oneDat.Name, oneDat.Id);

            var item = new ListViewItem(str, _imageList.Images.Count - 1);
            item.Tag = oneDat;
            item.SubItems.Add(oneDat.Id);
            item.SubItems.Add(oneDat.Jpg);
            _listView.Items.Add(item);
            return item;

        }

        public void Dispose(){
            Save();
        }

        public void Remove(OneDat oneDat){
            int index = _ar.IndexOf(oneDat);
            if (index != -1){
                _ar.RemoveAt(index);
                for (int i = 0; i < _listView.Items.Count; i++){
                    var o = (OneDat) _listView.Items[i].Tag;
                    if (o.Id == oneDat.Id){
                        _listView.Items.RemoveAt(i);
                    }
                }
            }
        
        }

        //ソート関連
        class DelegateComparison : IComparer {
            public delegate int CompareFunc(object a, object b);

            readonly CompareFunc _func;

            public DelegateComparison(CompareFunc func) {
                _func = func;
            }

            public int Compare(object a, object b) {
                return _func(a, b);
            }
        }
        //検索
        public void Find(String str){
            _listView.SelectedItems.Clear();
            foreach (ListViewItem item in _listView.Items){
                var oneDat = (OneDat) item.Tag;
                if (oneDat.Name.IndexOf(str) == 0){
                    item.Selected = true;
                    item.EnsureVisible();
                    return;
                }
            }
        }
    }
}
