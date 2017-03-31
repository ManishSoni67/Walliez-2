using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Walliez.Model
{
    public class Pictures : BaseModel
    {
        public int ID { get; set; }

        public int TypeID { get; set; }

        public string ImageName { get; set; }

        BitmapImage _ImageSource;
        public BitmapImage ImageSource
        {
            get { return _ImageSource; }
            set
            {
                _ImageSource = value;
                Notify("ImageSource");
            }
        }

        public string FilePath { get; set; }

        Uri _ImageUri = new Uri("/Wallpapers/EarthSpace/Image (1).jpg", UriKind.Relative);
        public Uri ImageUri
        {
            get { return _ImageUri; }
            set
            {
                _ImageUri = value;
                Notify("ImageUri");
            }
        }

    }
}
