using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace secpolo {
    class ListDat {
        List<OneDat>_ar = new List<OneDat>(); 

        //追加
        public bool Add(OneDat oneDat){
            foreach (var a in _ar){
                if (a.Id == oneDat.Id){
                    return false;
                }
            }
            _ar.Add(oneDat);
            return true;
        }

        //取得（存在しない場合null）
        public OneDat GetById(String id){
            foreach (var a in _ar) {
                if (a.Id == id) {
                    return a;
                }
            }
            return null;
        }

        //取得（存在しない場合null）
        public OneDat GetByUName(String uname) {
            foreach (var a in _ar) {
                if (a.UserName == uname) {
                    return a;
                }
            }
            return null;
        }
    }
}
