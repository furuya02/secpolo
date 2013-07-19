using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace secpolo {
    [Serializable()]
    public class OneDat {
        public String Name { get; private set; }
        public String UserName { get; private set; }
        public String Id { get; private set; }
        public String Jpg { get; private set; }
        public Image Image{ get; private set; }

        private Image _image = null;

        public OneDat(String name,String userName,String id,String jpg) {
            Name = name;
            UserName = userName;
            Jpg = jpg;
            Id = id;
            Image = Util.CreateImage(Jpg);
        }

    }
}
