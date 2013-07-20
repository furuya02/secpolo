using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace secpolo {
    public class Facebook{

        private const String RedirectUrl = "http://www.sapporoworks.ne.jp/spw/";
        private const String AppId = "611601805540392";
        private const String AppSecret = "61bfcc082d7d966468da7ec21c9e88e5";
        private String GraphUrl = "https://graph.facebook.com/"; 

        private readonly FacebookAuth _facebookAuth;

        //アクセストークンの取得が完了したときのイベント
        public delegate void CompleteDelegate(String accessToken);
        public event FacebookAuth.CompleteDelegate Complete;

        public Facebook(){
            _facebookAuth = new FacebookAuth(AppId, AppSecret, RedirectUrl);
            _facebookAuth.Complete+=_facebookAuth_Complete;
        }

        void _facebookAuth_Complete(string accessToken) {
            if (Complete != null){
                Complete(_facebookAuth.AccessToken);
            }
        }

        //友達一覧取得
        public List<String> GetFrientList(String id){
            List<String> ar = new List<string>();
            var url = String.Format("{0}{1}/friends?access_token={2}&locale=ja_JP", GraphUrl, id, _facebookAuth.AccessToken);
            var json = Util.Request(url);

            foreach (var j in json.data){
                ar.Add(j.id);
            }
            return ar;
        }

        
        //keyはunameでもidでもよい
        public OneDat CreateOneDat(String key){
            var url = String.Format("{0}{1}?access_token={2}&locale=ja_JP", GraphUrl, key, _facebookAuth.AccessToken);
            var json = Util.Request(url);
            if (json == null) {
                return null;
            }
            var name = json.name;
            var id = json.id;
            var username = id;
            if (json.IsDefined("username")) {
                username = json.username;
            }

            //画像URL取得
            url = String.Format("{0}/{1}?fields=picture", GraphUrl, id);
            //url = String.Format("{0}/{1}/picture?type=normal", GraphUrl, id);
            json = Util.Request(url);
            var jpg = "";
            if (json != null){
                jpg = json.picture.data.url;
            }
            return new OneDat(name, username, id, jpg);
            
        }

        //Facebook人物検索
        public List<String> Search(String str){
            var type = "user";//人物
            var query = HttpUtility.UrlEncode(str);
            var url = String.Format("{0}search?q={1}&type={2}&access_token={3}", GraphUrl, query, type, _facebookAuth.AccessToken);
            var json = Util.Request(url);
            //https://graph.facebook.com/search?q=QUERY&type=OBJECT_TYPE


            var ar = new List<String>();
            foreach (var j in json.data){
                var name = j.name;
                var id = j.id;
                ar.Add(id);
            }
            return ar;
        }
        
    }
}
