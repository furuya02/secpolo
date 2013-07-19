using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Codeplex.Data;

namespace secpolo {
    class Util {
        static private  String DecodeUtf(String str) {
            var sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++) {
                if (str[i] == '\\' && str[i + 1] == 'u' && i + 5 < str.Length) {
                    int code = Convert.ToInt32(str.Substring(i + 2, 4), 16);
                    sb.Append(Convert.ToChar(code));

                    i += 5;
                } else {
                    sb.Append(str[i]);
                }

            }
            return sb.ToString();
        }

        //Facebookホームページ表示
        static public void Home(String id){
            Process.Start(String.Format("https://www.facebook.com/profile.php?id={0}", id));
        }

        //TopMostメッセージボックス
        public static void TopMsg(String msg){
            using (Form dummyForm = new Form()) {
                dummyForm.TopMost = true;
                MessageBox.Show(msg);
                dummyForm.TopMost = false;
            }              
        }

        static public Image CreateImage(String url){
            //最初にキャッシュから検索する
            var info = IeCache.GetUrlCacheEntryInfo(url);
            try {
                return Image.FromFile(info.lpszLocalFileName);
            } catch (Exception) {
            }
            //存在しな場合は、ダウンロードする
             var tmpFileName = Path.GetTempFileName();
                    var wc = new System.Net.WebClient();
                    wc.DownloadFile(url,tmpFileName);
                    wc.Dispose();
            try{
                return Image.FromFile(tmpFileName);
            }catch(Exception){
                
            }
            return null;
        }
        //ドロップされたURLからユーザ名を取得する
        public static String GetUserName(String str) {
            if (str == null) {
                return null;
            }
            if (str.IndexOf("https://www.facebook.com/") != -1) {
                var tmp = str.Substring(25);

                var i = tmp.IndexOf("profile.php?id");
                if (i != -1){

                    tmp = tmp.Substring(i+15);
                    i = tmp.IndexOf("&");
                    if (i != -1) {
                        tmp = tmp.Substring(0, i);
                    }
                    return tmp;
                }

                i = tmp.IndexOf("photo.php?fbid=");
                if (i != -1) {
                    tmp = tmp.Substring(i + 15);

                    i = tmp.IndexOf("&set=");
                    if (i != -1) {
                        tmp = tmp.Substring(i+5);
                        i = tmp.IndexOf("&");
                        if (i != -1){
                            tmp = tmp.Substring(0, i);
                            var d = tmp.Split('.');
                            if (d.Count() > 0){
                                return d[d.Count() - 1];
                            }
                        }
                    }

                    return "";
                }


                i = tmp.IndexOf("/");
                if (i != -1) {
                    tmp = tmp.Substring(0, i);
                    return tmp;
                }
                i = tmp.IndexOf("&");
                if (i != -1) {
                    tmp = tmp.Substring(0, i);
                }
                return tmp;

            }
            return null;
        }


        static public dynamic Request(String url) {
            var HttpWReq = (HttpWebRequest)WebRequest.Create(url);
            HttpWReq.Method = "GET";           
            HttpWReq.UserAgent = "secpolo";
            HttpWReq.ReadWriteTimeout = 5 * 1000;
            HttpWReq.Timeout = 5 * 1000;
            HttpWReq.KeepAlive = true;
            HttpWReq.ContentType = "application/x-www-form-urlencoded";

            try{
                var HttpWResp = (HttpWebResponse) HttpWReq.GetResponse();

                var st = HttpWResp.GetResponseStream();
                var sr = new StreamReader(st, Encoding.ASCII);
                var str = sr.ReadToEnd();
                sr.Close();
                st.Close();
                HttpWResp.Close();

                return DynamicJson.Parse(DecodeUtf(str));

            } catch (Exception){
                return null;
            }

        }

    }
}
