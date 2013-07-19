using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace secpolo{
    public class FacebookAuth{
        public  String AccessToken { get; private set; }
        
        private readonly WebBrowser _webBrowser;

        private const String AuthUrl = "https://graph.facebook.com/oauth/";

        private readonly String _appId;
        private readonly String _appSecret;
        private readonly String _redirectUrl;

        private LoginDlg dlg = null;

        //アクセストークンの取得が完了したときのイベント
        public delegate void CompleteDelegate(String accessToken);
        public event CompleteDelegate Complete;


        public FacebookAuth(String appId,String appSecret,String redirectUrl){
            AccessToken = "";
//            _webBrowser= new WebBrowser();
//            _webBrowser.DocumentCompleted += _webBrowser_DocumentCompleted;

            dlg = new LoginDlg();
            _webBrowser = dlg.WebBrowser;
            _webBrowser.DocumentCompleted += _webBrowser_DocumentCompleted;

            _appId = appId;
            _appSecret = appSecret;
            _redirectUrl = redirectUrl;


            //①
            var url = String.Format("https://www.facebook.com/dialog/oauth?client_id={0}&redirect_uri={1}", _appId, _redirectUrl);
            _webBrowser.Navigate(url);
        }

        void _webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {

            var url = e.Url.ToString();


            if (url.IndexOf("https://www.facebook.com/") == 0){ //②③未ログイン状態
                dlg.Show();
            }else{
                dlg.Visible = false;

            }
            if (url.IndexOf(_redirectUrl) == 0) {//④指定したリダイレクト先に飛ばされたとき
                var index = url.IndexOf("code=");
                if (index >= 0) {
                    var code = url.Substring(index + 5);
                    //⑤
                    url = String.Format("{0}access_token?client_id={1}&redirect_uri={2}&client_secret={3}&code={4}", AuthUrl, _appId, _redirectUrl, _appSecret, code);
                    _webBrowser.Navigate(url);
                }
            } else if (url.IndexOf(AuthUrl) == 0) {//最後のCode付のリクエストが完了したとき
                Debug.Assert(_webBrowser.Document != null, "_webBrowser.Document != null");


                if (_webBrowser.Document.Body != null){
                    var str = _webBrowser.Document.Body.InnerHtml;
                    var i = str.IndexOf("access_token=");
                    if (i >= 0) {
                        str = str.Substring(i + 13);

                        i = str.IndexOf("&amp;expires=");
                        if (i >= 0) {
                            AccessToken = str.Substring(0, i);
                            if (Complete != null) {
                                Complete(AccessToken);
                            }
                        }
                    }
                }
            }

        }
    }
    /*
Facebookの認証動作

{APP_ID}アプリ登録による取得
{APP_SECRET}アプリ登録による取得(変更可能)
{REDIRECT_URL}アプリ登録後に登録したもの（変更可能）
{CODE} 認証中に取得される（ログインしないと取得できない）
{ACCESS_TOKEN}アクセストークン<=これが最終的にほしい

①最初のリクエスト
https://www.facebook.com/dialog/oauth?client_id={APP_ID}&redirect_uri={REDIRECT_URL}
https://www.facebook.com/dialog/oauth?client_id=611601805540392&redirect_uri=http://www.sapporoworks.ne.jp/spw/

②次のURLにリダイレクトされる
https://www.facebook.com/login.php?skip_api_login=1&api_key={APP_ID}&signed_next=1&next=https://www.facebook.com/dialog/oauth?redirect_uri=http%253A%252F%252Fwww.sapporoworks.ne.jp%252Fspw%252F&client_id=611601805540392&ret=login&cancel_uri={REDIRECT_URL}?error=access_denied&error_code=200&error_description=Permissions+error&error_reason=user_denied%23_=_&display=page
https://www.facebook.com/login.php?skip_api_login=1&api_key=611601805540392&signed_next=1&next=https://www.facebook.com/dialog/oauth?redirect_uri=http%253A%252F%252Fwww.sapporoworks.ne.jp%252Fspw%252F&client_id=611601805540392&ret=login&cancel_uri=http://www.sapporoworks.ne.jp/spw/?error=access_denied&error_code=200&error_description=Permissions+error&error_reason=user_denied%23_=_&display=page

③IDとパスワードを入力すると下記に飛んで、ブラウザ保存するかどうかを問われる
https://www.facebook.com/checkpoint/?next=https%3A%2F%2Fwww.facebook.com%2Fdialog%2Foauth%3Fredirect_uri%3Dhttp%253A%252F%252Fwww.sapporoworks.ne.jp%252Fspw%252F%26client_id%3D611601805540392%26ret%3Dlogin
https://www.facebook.com/checkpoint/?next=https%3A%2F%2Fwww.facebook.com%2Fdialog%2Foauth%3Fredirect_uri%3Dhttp%253A%252F%252Fwww.sapporoworks.ne.jp%252Fspw%252F%26client_id%3D611601805540392%26ret%3Dlogin

④OKすると下記（リダイレクト指定先）に飛ぶ
http://www.sapporoworks.ne.jp/spw/?code={CODE}
http://www.sapporoworks.ne.jp/spw/?code=AQDoovRwrvDQFg3nbwbAsqnCZkyoFnK9RLx1Gn0Q1NAsnwFyJy_tQrb9A7XkNLLpsS_o3R4GNnp3LKFw1K46UUlGLZ-hwhB4m1kPJB3fiqlpJcoXCLVxSXKTxOTKy_ryo2a4s2-ON3xfK9lys_XRbuCazyC2YYn9HNzYqN9XD0p8dd6bQHrykDLbmxv06RW4n9Vazt1C8IHwZTl2YwdG1G2TpunnbPUZHn5-1Y3Wn-kKt-0EXqzqOXor6iBxohzZvLwSVkDzjQX6dUsZ-i88GHJoF4K9L4-gP_i1QT9_ysJhuOFp5CUviK0mLNCESrXG7Yw#_=_

■当初①をリクエストすると
ログインされていない場合は②に飛ぶ
ログインが終わっている場合は④に飛ぶ

■当初②をリクエストすると
ログインされていない場合はエラーとなる
ログインが終わっている場合は④に飛ぶ

■当初③をリクエストすると
ログインされていない場合はログイン画面に飛ぶ
ログインが終わっている場合は④に飛ぶ
     
 ※②及び③では、ユーザの入力が必要なのでウインドウを表示する
 

当初、Codeが分からないため、これ以上先をリクエストすることはできない
事後、④で得たCode=を取得する

⑤Codeを使用して下記のリクエストを送る
https://graph.facebook.com/oauth/access_token?client_id={APP_ID}&redirect_uri={REDIRECT_URL}&client_secret={APP_SECRET}&code={CODE}
https://graph.facebook.com/oauth/access_token?client_id=611601805540392&redirect_uri=http://www.sapporoworks.ne.jp/spw/&client_secret=61bfcc082d7d966468da7ec21c9e88e5&code=AQDzwzcWqZbZDTyLUUTzIoDy2NLME0hl3HaG8lnNCWloCxR33A-oFvHQC6frIy7LJo3obHmR2WwejkMM1xcW30sp6vvfyz-NQQEeFmcW74rLGKiiJMjRuQmkxOjsj_kG7EwLn19GlhiUQBRkEJrCYVAtAPdUZOJpxZxxt6irgDNs3r-GlWrJCWCthGjyeGwN7tJLaYeRfSyhVt5d5NALw4rtbtwkeQ7W3VuTDkiLLmL1YqWiYOgGB__Nxdof23ukipSoEIxGHw0Pa1vuQ11-zJWsyO3AFBmNNYdGQMCtlfzWDfKIN1OUNsYmojDleyJ4iSM#_=_

下記のBodyが返される
<pre>access_token={ACCESS_TOKEN}&amp;expires=5156379</pre>
<pre>access_token=CAAIsP6RcZCCgBAA7uXuY1782ZBXtQq07wNRUwzUoqmEB8rzYoYsJ9g9kjBynFULhYGyZC5LRXSqo31VSRCs1LGdhniz4qDTyIGZCJ0kZBUZBHaEhhH3ywZAp889WCYQUTjPi4z3k9uPRUfS7m2Rvtfm&amp;expires=5156379</pre>

このBodyの中身がアクセストークンである
     
     */
}
