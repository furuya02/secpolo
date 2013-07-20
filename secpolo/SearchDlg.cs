using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace secpolo {
    public partial class SearchDlg : Form{
        private readonly Facebook _facebook;
        private SpamListView _spanListView;

        private Thread _t = null;
        List<OneDat> _ar = new List<OneDat>();

        public SearchDlg(String str,Facebook facebook,SpamListView spanListView) {

            InitializeComponent();

            _facebook = facebook;
            _spanListView = spanListView;

            textBox1.Text = str;
            
            listBox.ItemHeight = 50;
            listBox.DrawMode = DrawMode.OwnerDrawFixed;
            listBox.DrawItem += listBox_DrawItem;

            listBox.DoubleClick += listBox_DoubleClick;

            //文字列が指定されてこのダイアログがオープンしたときは、自動的に検索を開始する
            if (str != ""){
                Start();
            }
        }

        //ダブルによるブラウザによる「ホーム」表示
        void listBox_DoubleClick(object sender, EventArgs e){
            var index = listBox.SelectedIndex;
            if (index != -1){
                var id = _ar[index].Id;
                Util.Home(id);
            }

        }

        void listBox_DrawItem(object sender, DrawItemEventArgs e) {
            
            var oneDat = _ar[e.Index];

            e.DrawBackground();

            if (e.Index > -1) {

                // 画像表示
                e.Graphics.DrawImage(oneDat.Image, e.Bounds.X, e.Bounds.Y);

                //文字列表示
                Brush b = new SolidBrush(e.ForeColor); ;
                //スパムアカウントの場合は色を変える
//                if (_spanListView.IsSpam(oneDat.Id)){
//                    b = new SolidBrush(Color.Red);
//                }
                if (_spanListView.IsSpam(oneDat)) {
                    b = new SolidBrush(Color.Red);
                }

 
                var bounds = e.Bounds;
                bounds.X = e.Bounds.X + 55;
                bounds.Y = e.Bounds.Y + 20;
                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, b, bounds);
                //後始末
                b.Dispose();
            }

            e.DrawFocusRectangle();
        }

        //文字列入力時にEnterが押された場合
        private void textBox1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                Start();
            }
        }
        //検索キーが押された場合
        private void buttonSearch_Click(object sender, EventArgs e) {
            Start();
        }

        delegate void AddDelegate(OneDat oneDat);
        void Add(OneDat oneDat) {
            // 呼び出し元のコントロールのスレッドが異なるか確認をする
            if (listBox.InvokeRequired) {
                this.Invoke(new AddDelegate(Add), new object[] { oneDat });
            } else {
                _ar.Add(oneDat);
                var str = string.Format("{0} ({1})", oneDat.Name, oneDat.Id);
                listBox.Items.Add(str);
            }
        }

        void Job(){
            var ar = _facebook.Search(textBox1.Text);
            foreach (var a in ar) {
                var oneDat = _facebook.CreateOneDat(a);
                if (oneDat != null){
                    Add(oneDat);
                }
            }
        }

        void Start(){
            
            if (_t != null) {
                Stop();
            }

            listBox.Items.Clear();
            _ar.Clear();
            

            _t = new Thread(Job);
            _t.IsBackground = true;
            _t.Start();
        }

        void Stop(){
            if (_t != null){
                _t.Abort();
                while (_t.IsAlive) {
                    Thread.Sleep(100);
                }
            }
            _t = null;
        }

        //ダイアログが閉じる時
        private void SearchDlg_FormClosing(object sender, FormClosingEventArgs e){
            Stop();
        }
    }

}
