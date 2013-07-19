using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
//using mshtml;
using Timer = System.Windows.Forms.Timer;

namespace secpolo {
    class CreateFriendList:IDisposable {
        readonly Timer timer = new Timer();
        private readonly WebBrowser _webBrowser;
        private int _size;

        
        //友達が取得できた時のイベント
        public delegate void CompleteDelegate(OneDat oneDat);
        public event CompleteDelegate Complete;

        List<OneDat>_ar = new List<OneDat>(); 

        public CreateFriendList(String url){
            
            _webBrowser = new WebBrowser();
            
            timer.Interval = 250;
            timer.Tick += timer_Tick;

            _webBrowser.Navigate(url);
            _size = 0;
            counter = 0;
            timer.Enabled = true;
        }

        //タイマー処理 1秒後にサイズが変わっていたら下スクロールしてAjaxを起動させる
        private int counter = 0;
        private void timer_Tick(object sender, EventArgs e) {
            if (_webBrowser.Document == null) {
                return;
            }
            if (_webBrowser.Document.Body == null) {
                return;
            }
            if (_webBrowser.Document.Body.InnerHtml == null) {
                return;
            }
            var len = _webBrowser.Document.Body.InnerText.Length;
            if (len != _size) {
                _size = len;
                _webBrowser.Document.Window.ScrollTo(0, 500000);
                counter = 0;

                var list = GetLiList();
                if (_ar.Count != list.Count){
                    for (int i = _ar.Count; i < list.Count; i++){
                        OneDat oneDat = CreateOneDat(list[i]);
                        if (oneDat == null){
                            //設計問題
                            int x = 0;
                        }else{
                            if (Complete != null){
                                Complete(oneDat); //イベント発生
                            }
                            _ar.Add(oneDat);
                        }
                    }


                }
            } else {
                counter++;
                if (counter < 12) {
                    return;
                }

                timer.Enabled = false;
                if (Complete != null){
                    Complete(null); //イベント発生
                }
            }

        }

        private List<HtmlElement> GetLiList(){
            var ar = new List<HtmlElement>();
            var he = _webBrowser.Document.GetElementById("globalContainer");
            if (he != null){
                foreach (HtmlElement h in he.All) {
                    if (h.TagName == "UL") {
                        if (h.OuterText != null && h.OuterText.IndexOf("友達リクエスト送信済み") != -1) {
                            //キーワードで検索
                            foreach (HtmlElement li in h.Children) {
                                ar.Add(li);
                            }
                        }
                    }
                }
            }
            return ar;
        }


        private OneDat CreateOneDat(HtmlElement li){
            if (li.Children.Count >= 1){
                HtmlElement e0 = li.Children[0];
                if (e0.Children.Count >= 2){
                    var a = e0.Children[0]; //最初のAがイメージ
                    var e1 = e0.Children[1]; //次のDIVが画像以外の要素
                    
                    var e2 = e1.Children[0];
                    if (e1.Children.Count >= 2){
                        e2 = e1.Children[1];//自分以外の場合は、1番目は友達リクエストのボタンで2番目が個人情報
                    }
                    foreach (HtmlElement e3 in e2.All){
                        //最初のA属性が一番情報を取得しやすい
                        if (e3.TagName == "A"){
                            var name = e3.InnerText;
                            var jpg = GetJpg(a.OuterHtml);
                            var id = GetId(e3.OuterHtml);
                            var userName = GetUserName(e3.OuterHtml);
                            return new OneDat(name, userName, id, jpg);
                        }
                    }
                }
            }
            return null;
        }


        //Aタグの中ならjpgのリンクを抜き出す
        String GetJpg(String str){
            int i = str.IndexOf("src=\"");
            if (i != -1) {
                str = str.Substring(i+5);
                i = str.IndexOf("\">");
                if (i != -1) {
                    return str.Substring(0, i);
                }
            }
            return "";
        }

        //OuterHtmlの中ならidを抜き出す
        String GetId(String str) {
            var jpg = "";
            int i = str.IndexOf("id=");
            if (i != -1) {
                str = str.Substring(i+3);
                i = str.IndexOf("&");
                if (i != -1) {
                    return str.Substring(0, i);
                }
            }
            return "";
        }

        //OuterHtmlの中ならUserNameを抜き出す
        String GetUserName(String str) {
            var jpg = "";
            int i = str.IndexOf("https://www.facebook.com/");
            if (i != -1) {
                str = str.Substring(i + 25);
                if (str.IndexOf("profile.php?id") == 0){
                    str = str.Substring(15);
                    i = str.IndexOf("&");
                    if (i != -1){
                        return str.Substring(0, i);
                    }
                } else{
                    i = str.IndexOf("?");
                    if (i != -1){
                        return str.Substring(0, i);
                    }
                }
            }
            return "";
        }

        public void Dispose(){
            timer.Enabled = false;
            _webBrowser.Stop();
        }
    }
}
