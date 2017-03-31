using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Xna.Framework.Media;
using System.Windows.Media.Imaging;

namespace Walliez_2.Views
{
    public partial class PicturesInfo : PhoneApplicationPage
    {
        public PicturesInfo()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Get a dictionary of query string keys and values.
            IDictionary<string, string> queryStrings = this.NavigationContext.QueryString;

            // Ensure that there is at least one key in the query string, and check whether the "token" key is present.
            if (queryStrings.ContainsKey("token"))
            {
                // Retrieve the photo from the media library using the token passed to the app.
                MediaLibrary library = new MediaLibrary();
                foreach (var pic in library.Pictures)
                {

                }
                Picture photoFromLibrary = library.GetPictureFromToken(queryStrings["token"]);
                int HashCode = photoFromLibrary.GetHashCode();



                BitmapImage bitmapFromPhoto = new BitmapImage();
                bitmapFromPhoto.SetSource(photoFromLibrary.GetImage());
                Img_Image.Source = bitmapFromPhoto;
            }
        }
    }
}