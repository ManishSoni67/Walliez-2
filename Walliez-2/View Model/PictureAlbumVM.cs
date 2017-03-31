using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using Walliez.Model;

namespace Walliez_2
{
    public class PictureAlbumVM : BaseModel
    {
        public PictureAlbumVM()
        {
            Oninit();
        }

        private void Oninit()
        {

        }
        public event EventHandler ImageLoaded;
        public void RaiseImageLoaded()
        {
            if (ImageLoaded != null)
                ImageLoaded(this, new EventArgs());
        }
        public int CurrentID { get; set; }
        public int TypeID { get; set; }
        public string Label { get; set; }
        Pictures _Picture = new Pictures();
        public Pictures Picture
        {
            get { return _Picture; }
            set
            {
                _Picture = value;
                Notify("Picture");
            }
        }
        ObservableCollection<Pictures> _AllPictures = new ObservableCollection<Pictures>();
        public ObservableCollection<Pictures> AllPictures
        {
            get { return _AllPictures; }
            set
            {
                _AllPictures = value;
                Notify("AllPictures");
            }
        }
        public void GetAllImages()
        {
            if (this.AllPictures.Count >= 1)
            {
                this.AllPictures.Clear();
            }
            if (TypeID == 1)
            {
                this.Label = "Nature";
            }
            else if (TypeID == 2)
            {
                this.Label = "EarthSpace";
            }
            else if (TypeID == 4)
            {
                this.Label = "Games";
            }
            else if (TypeID == 3)
            {
                this.Label = "Special";
            }
            else
            {
                this.Label = "Nature";
            }
            for (int i = 1; i <= 50; i++)
            {
                Pictures pic = new Pictures();
                pic.ID = i;
                pic.TypeID = this.TypeID;
                pic.ImageName = this.Label + "/Image (" + i + ").jpg";
                pic.FilePath = "/Wallpapers/" + this.Label + "/Image (" + i + ").jpg";
                Uri ImageUri = new Uri(pic.FilePath, UriKind.Relative);
                pic.ImageUri = ImageUri;
                pic.ImageSource = new BitmapImage(ImageUri);
                this.AllPictures.Add(pic);
            }
            RaiseImageLoaded();
        }
        public void GetImage()
        {
            var data = this.AllPictures.SingleOrDefault(x => x.ID == this.CurrentID);
            if (data != null)
            {
                this.Picture = data;
            }
        }




    }
}
