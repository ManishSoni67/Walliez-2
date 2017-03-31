using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Windows.Media;
using System.IO;
using Microsoft.Xna.Framework.Media;
using Microsoft.Phone.Tasks;

namespace Walliez_2
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            Str_NatureBrdClick.Completed += Str_NatureBrdClick_Completed;
            Str_NatureBrdUnClick.Completed += Str_NatureBrdUnClick_Completed;
            Str_EarthSpaceBrdClick.Completed += Str_EarthSpaceBrdClick_Completed;
            Str_EarthSpaceBrdUnClick.Completed += Str_EarthSpaceBrdUnClick_Completed;
            Str_GamesBrdClick.Completed += Str_GamesBrdClick_Completed;
            Str_GamesBrdUnClick.Completed += Str_GamesBrdUnClick_Completed;
            Str_SpecialBrdClick.Completed += Str_SpecialBrdClick_Completed;
            Str_SpecialBrdUnClick.Completed += Str_SpecialBrdUnClick_Completed;
            Str_NatureSavePictureClick.Completed += Str_NatureSavePictureClick_Completed;
            Str_NatureSavePictureUnClick.Completed += Str_NatureSavePictureUnClick_Completed;
            Str_NatureNextPictureClick.Completed += Str_NatureNextPictureClick_Completed;
            Str_NatureNextPictureUnClick.Completed += Str_NatureNextPictureUnClick_Completed;
            Str_NaturePicPictureClick.Completed += Str_NaturePicPictureClick_Completed;
            Str_NaturePicPictureUnClick.Completed += Str_NaturePicPictureUnClick_Completed;
            Str_NatureZoomPictureClick.Completed += Str_NatureZoomPictureClick_Completed;
            Str_NatureZoomPictureUnClick.Completed += Str_NatureZoomPictureUnClick_Completed;
            Str_EarthSpaceNextPictureClick.Completed += Str_EarthSpaceNextPictureClick_Completed;
            Str_EarthSpaceNextPictureUnClick.Completed += Str_EarthSpaceNextPictureUnClick_Completed;
            Str_EarthSpacePicPictureClick.Completed += Str_EarthSpacePicPictureClick_Completed;
            Str_EarthSpacePicPictureUnClick.Completed += Str_EarthSpacePicPictureUnClick_Completed;
            Str_EarthSpaceSavePictureClick.Completed += Str_EarthSpaceSavePictureClick_Completed;
            Str_EarthSpaceSavePictureUnClick.Completed += Str_EarthSpaceSavePictureUnClick_Completed;
            Str_EarthSpaceZoomPictureClick.Completed += Str_EarthSpaceZoomPictureClick_Completed;
            Str_EarthSpaceZoomPictureUnClick.Completed += Str_EarthSpaceZoomPictureUnClick_Completed;
            Str_SpecialNextPictureClick.Completed += Str_SpecialNextPictureClick_Completed;
            Str_SpecialNextPictureUnClick.Completed += Str_SpecialNextPictureUnClick_Completed;
            Str_SpecialPicPictureClick.Completed += Str_SpecialPicPictureClick_Completed;
            Str_SpecialPicPictureUnClick.Completed += Str_SpecialPicPictureUnClick_Completed;
            Str_SpecialSavePictureClick.Completed += Str_SpecialSavePictureClick_Completed;
            Str_SpecialSavePictureUnClick.Completed += Str_SpecialSavePictureUnClick_Completed;
            Str_SpecialZoomPictureClick.Completed += Str_SpecialZoomPictureClick_Completed;
            Str_SpecialZoomPictureUnClick.Completed += Str_SpecialZoomPictureUnClick_Completed;
            Str_GamesNextPictureClick.Completed += Str_GamesNextPictureClick_Completed;
            Str_GamesNextPictureUnClick.Completed += Str_GamesNextPictureUnClick_Completed;
            Str_GamesPicPictureClick.Completed += Str_GamesPicPictureClick_Completed;
            Str_GamesPicPictureUnClick.Completed += Str_GamesPicPictureUnClick_Completed;
            Str_GamesSavePictureClick.Completed += Str_GamesSavePictureClick_Completed;
            Str_GamesSavePictureUnClick.Completed += Str_GamesSavePictureUnClick_Completed;
            Str_GamesZoomPictureClick.Completed += Str_GamesZoomPictureClick_Completed;
            Str_GamesZoomPictureUnClick.Completed += Str_GamesZoomPictureUnClick_Completed;
            Str_PageTrnsRight.Completed += Str_PageTrnsRight_Completed;
            Str_PageTrnsleft.Completed += Str_PageTrnsleft_Completed;
            Str_NatureNotificationShow.Completed += Str_NatureNotificationShow_Completed;
            Str_EarthSpaceNotificationShow.Completed += Str_EarthSpaceNotificationShow_Completed;
            Str_SpecialNotificationShow.Completed += Str_SpecialNotificationShow_Completed;
            Str_GamesNotificationShow.Completed += Str_GamesNotificationShow_Completed;
            SplashScreenStartUp.Completed += SplashScreenStartUp_Completed;
            this.BackKeyPress += MainPage_BackKeyPress;
            this.Loaded += MainPage_Loaded;
            ImgNo = 1;
            ChangeAllPicture();
            SplashScreenStartUp.Begin();
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Popup.IsOpen = true;
        }

        void SplashScreenStartUp_Completed(object sender, EventArgs e)
        {
            ApplicationLoadsUp.Begin();
        }

        void Str_GamesNotificationShow_Completed(object sender, EventArgs e)
        {
            Str_GamesNotificationClose.Begin();
        }

        void Str_SpecialNotificationShow_Completed(object sender, EventArgs e)
        {
            Str_SpecialNotificationClose.Begin();
        }

        void Str_EarthSpaceNotificationShow_Completed(object sender, EventArgs e)
        {
            Str_EarthSpaceNotificationClose.Begin();
        }

        void Str_NatureNotificationShow_Completed(object sender, EventArgs e)
        {
            Str_NatureNotificationClose.Begin();
        }

        void Str_PageTrnsRight_Completed(object sender, EventArgs e)
        {
            //Str_PageTrnsBack.Begin();
        }

        void Str_PageTrnsleft_Completed(object sender, EventArgs e)
        {
            //  Str_PageTrnsBack.Begin();
        }
        void Str_GamesZoomPictureUnClick_Completed(object sender, EventArgs e)
        {
            ApplicationBar.IsVisible = false;
            Img_ZoomPopup.Source = new BitmapImage(new Uri("/Wallpapers/Games/Image (" + this.GamesPicID + ").jpg", UriKind.Relative));
            Str_PictureZoomPopUpStarts.Begin();
        }

        void Str_GamesZoomPictureClick_Completed(object sender, EventArgs e)
        {
            Str_GamesZoomPictureUnClick.Begin();
            //throw new NotImplementedException();
        }

        void Str_GamesSavePictureUnClick_Completed(object sender, EventArgs e)
        {
            WriteableBitmap bmp = new WriteableBitmap(480, 800);
            var source = Img_Games.Source as BitmapImage;
            Image img = new Image();
            img.Source = source;
            img.Stretch = Stretch.Uniform;
            bmp.Render(img, new ScaleTransform() { ScaleX = 1, ScaleY = 1 });
            bmp.Invalidate();
            using (MemoryStream stream = new MemoryStream())
            {
                bmp.SaveJpeg(stream, 480, 800, 0, 100);
                if (stream.Length != 0)
                {
                    MediaLibrary ml = new MediaLibrary();
                    ml.SavePicture("Games" + GamesPicID + ".jpg", stream.GetBuffer());
                }
            }
            Txt_GamesNotifications.Text = "Image Saved in Saved Directory";
            Str_GamesNotificationShow.Begin();
        }

        void Str_GamesSavePictureClick_Completed(object sender, EventArgs e)
        {
            Str_GamesSavePictureUnClick.Begin();
        }

        void Str_GamesPicPictureUnClick_Completed(object sender, EventArgs e)
        {
            //     throw new NotImplementedException();

            this.TypeID = 4;
            this.ChangeViewToAlbums(this.GamesPicID);
        }

        void Str_GamesPicPictureClick_Completed(object sender, EventArgs e)
        {
            Str_GamesPicPictureUnClick.Begin();
        }
        void Str_GamesNextPictureUnClick_Completed(object sender, EventArgs e)
        {
            ChangeGamesPicture();
        }

        void Str_GamesNextPictureClick_Completed(object sender, EventArgs e)
        {
            Str_GamesNextPictureUnClick.Begin();
        }

        void Str_SpecialZoomPictureUnClick_Completed(object sender, EventArgs e)
        {
            ApplicationBar.IsVisible = false;
            Img_ZoomPopup.Source = new BitmapImage(new Uri("/Wallpapers/Special/Image (" + this.SpecialPicID + ").jpg", UriKind.Relative));
            Str_PictureZoomPopUpStarts.Begin();
        }

        void Str_SpecialZoomPictureClick_Completed(object sender, EventArgs e)
        {
            Str_SpecialZoomPictureUnClick.Begin();
        }

        void Str_SpecialSavePictureUnClick_Completed(object sender, EventArgs e)
        {
            WriteableBitmap bmp = new WriteableBitmap(480, 800);
            var source = Img_Special.Source as BitmapImage;
            Image img = new Image();
            img.Source = source;
            img.Stretch = Stretch.Uniform;
            bmp.Render(img, new ScaleTransform() { ScaleX = 1, ScaleY = 1 });
            bmp.Invalidate();
            using (MemoryStream stream = new MemoryStream())
            {
                bmp.SaveJpeg(stream, 480, 800, 0, 100);
                if (stream.Length != 0)
                {
                    MediaLibrary ml = new MediaLibrary();
                    ml.SavePicture("Special" + SpecialPicID + ".jpg", stream.GetBuffer());
                }
            }
            Txt_SpecialNotifications.Text = "Image Saved in Saved Directory";
            Str_SpecialNotificationShow.Begin();
            // throw new NotImplementedException();
        }

        void Str_SpecialSavePictureClick_Completed(object sender, EventArgs e)
        {
            Str_SpecialSavePictureUnClick.Begin();
            //throw new NotImplementedException();
        }

        void Str_SpecialPicPictureUnClick_Completed(object sender, EventArgs e)
        {

            this.TypeID = 3;
            this.ChangeViewToAlbums(this.SpecialPicID);
        }

        void Str_SpecialPicPictureClick_Completed(object sender, EventArgs e)
        {
            Str_SpecialPicPictureUnClick.Begin();
        }

        void Str_SpecialNextPictureUnClick_Completed(object sender, EventArgs e)
        {
            ChangeSpecialPicture();
        }

        void Str_SpecialNextPictureClick_Completed(object sender, EventArgs e)
        {
            Str_SpecialNextPictureUnClick.Begin();
        }

        void Str_EarthSpaceZoomPictureUnClick_Completed(object sender, EventArgs e)
        {
            ApplicationBar.IsVisible = false;
            Img_ZoomPopup.Source = new BitmapImage(new Uri("/Wallpapers/EarthSpace/Image (" + this.EarthSpaceID + ").jpg", UriKind.Relative));
            Str_PictureZoomPopUpStarts.Begin();
        }

        void Str_EarthSpaceZoomPictureClick_Completed(object sender, EventArgs e)
        {
            Str_EarthSpaceZoomPictureUnClick.Begin();
        }

        void Str_EarthSpaceSavePictureUnClick_Completed(object sender, EventArgs e)
        {

            WriteableBitmap bmp = new WriteableBitmap(480, 800);
            var source = Img_EarthSpace.Source as BitmapImage;
            Image img = new Image();
            img.Source = source;
            img.Stretch = Stretch.Uniform;
            bmp.Render(img, new ScaleTransform() { ScaleX = 1, ScaleY = 1 });
            bmp.Invalidate();
            using (MemoryStream stream = new MemoryStream())
            {
                bmp.SaveJpeg(stream, 480, 800, 0, 100);
                if (stream.Length != 0)
                {
                    MediaLibrary ml = new MediaLibrary();
                    ml.SavePicture("Space" + EarthSpaceID + ".jpg", stream.GetBuffer());
                }
            }
            Txt_EarthNotifications.Text = "Image Saved in Saved Directory";
            Str_EarthSpaceNotificationShow.Begin();
        }

        void Str_EarthSpaceSavePictureClick_Completed(object sender, EventArgs e)
        {
            Str_EarthSpaceSavePictureUnClick.Begin();
            //throw new NotImplementedException();
        }

        void Str_EarthSpacePicPictureUnClick_Completed(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            this.TypeID = 2;
            this.ChangeViewToAlbums(this.EarthSpaceID);
        }

        void Str_EarthSpacePicPictureClick_Completed(object sender, EventArgs e)
        {
            Str_EarthSpacePicPictureUnClick.Begin();
            //throw new NotImplementedException();
        }

        void Str_EarthSpaceNextPictureUnClick_Completed(object sender, EventArgs e)
        {
            ChangeEarthSpacePicture();
            // throw new NotImplementedException();
        }

        void Str_EarthSpaceNextPictureClick_Completed(object sender, EventArgs e)
        {
            Str_EarthSpaceNextPictureUnClick.Begin(); // throw new NotImplementedException();
        }

        void MainPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Trnsfm_ImgZoomPopup.ScaleX > 0)
            {
                ApplicationBar.IsVisible = true;
                Str_PictureZoomPopUpCloses.Begin();
                Grd_PopUp_MenuPanel.Width = 50;
                Grd_ImageSaveStatus.Visibility = Visibility.Collapsed;
                e.Cancel = true;
            }
        }
        void Str_NatureZoomPictureUnClick_Completed(object sender, EventArgs e)
        {
            ApplicationBar.IsVisible = false;
            Img_ZoomPopup.Source = new BitmapImage(new Uri("/Wallpapers/Nature/Image (" + this.NaturePicId + ").jpg", UriKind.Relative));
            Str_PictureZoomPopUpStarts.Begin();
        }
        void Str_NatureZoomPictureClick_Completed(object sender, EventArgs e)
        {
            Str_NatureZoomPictureUnClick.Begin();
        }

        void Str_NaturePicPictureUnClick_Completed(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            this.TypeID = 1;
            this.ChangeViewToAlbums(this.NaturePicId);

        }
        void Str_NaturePicPictureClick_Completed(object sender, EventArgs e)
        {
            Str_NaturePicPictureUnClick.Begin();
            //throw new NotImplementedException();
        }

        void Str_NatureNextPictureUnClick_Completed(object sender, EventArgs e)
        {
            ChangeNaturePicture();
        }

        void Str_NatureNextPictureClick_Completed(object sender, EventArgs e)
        {
            Str_NatureNextPictureUnClick.Begin();
        }

        void Str_NatureSavePictureUnClick_Completed(object sender, EventArgs e)
        {
            WriteableBitmap bmp = new WriteableBitmap(480, 800);
            var source = Img_Nature.Source as BitmapImage;
            Image img = new Image();
            img.Source = source;
            img.Stretch = Stretch.Uniform;
            bmp.Render(img, new ScaleTransform() { ScaleX = 1, ScaleY = 1 });
            bmp.Invalidate();
            using (MemoryStream stream = new MemoryStream())
            {
                bmp.SaveJpeg(stream, 480, 800, 0, 100);
                if (stream.Length != 0)
                {
                    MediaLibrary ml = new MediaLibrary();
                    ml.SavePicture("Nature" + NaturePicId + ".jpg", stream.GetBuffer());
                }
            }
            Txt_NatureNotifications.Text = "Image Saved in Saved Directory";
            Str_NatureNotificationShow.Begin();
        }

        void Str_NatureSavePictureClick_Completed(object sender, EventArgs e)
        {
            Str_NatureSavePictureUnClick.Begin();
        }
        private void ChangeAllPicture()
        {
            Random r = new Random();
            var no = r.Next(1, 50);
            if (ImgNo != no)
            {
                ImgNo = no;
                NaturePicId = no;
                GamesPicID = no;
                SpecialPicID = no;
                EarthSpaceID = no;
                Img_Nature.Source = new BitmapImage(new Uri("/Wallpapers/Nature/Image (" + no + ").jpg", UriKind.Relative));
                Img_EarthSpace.Source = new BitmapImage(new Uri("/Wallpapers/EarthSpace/Image (" + no + ").jpg", UriKind.Relative));
                Img_Games.Source = new BitmapImage(new Uri("/Wallpapers/Games/Image (" + no + ").jpg", UriKind.Relative));
                Img_Special.Source = new BitmapImage(new Uri("/Wallpapers/Special/Image (" + no + ").jpg", UriKind.Relative));
            }
            else
            {
                ChangeAllPicture();
            }

        }
        private void Btn_ShuffleImages_Click(object sender, System.EventArgs e)
        {
            ChangeAllPicture();
        }

        private void ChangeNaturePicture()
        {
            Random r = new Random();
            var no = r.Next(1, 50);
            if (NaturePicId != no)
            {
                NaturePicId = no;
                Img_Nature.Source = new BitmapImage(new Uri("/Wallpapers/Nature/Image (" + no + ").jpg", UriKind.Relative));
            }
            else
            {
                ChangeNaturePicture();
            }

        }
        private void ChangeEarthSpacePicture()
        {
            Random r = new Random();
            var no = r.Next(1, 50);
            if (EarthSpaceID != no)
            {
                EarthSpaceID = no;
                Img_EarthSpace.Source = new BitmapImage(new Uri("/Wallpapers/EarthSpace/Image (" + no + ").jpg", UriKind.Relative));
            }
            else
            {
                ChangeEarthSpacePicture();
            }

        }
        private void ChangeSpecialPicture()
        {
            Random r = new Random();
            var no = r.Next(1, 50);
            if (SpecialPicID != no)
            {
                SpecialPicID = no;
                Img_Special.Source = new BitmapImage(new Uri("/Wallpapers/Special/Image (" + no + ").jpg", UriKind.Relative));
            }
            else
            {
                ChangeSpecialPicture();
            }
        }
        private void ChangeGamesPicture()
        {
            Random r = new Random();
            var no = r.Next(1, 50);
            if (GamesPicID != no)
            {
                GamesPicID = no;
                Img_Games.Source = new BitmapImage(new Uri("/Wallpapers/Games/Image (" + no + ").jpg", UriKind.Relative));
            }
            else
            {
                ChangeGamesPicture();
            }
        }
        private void Txt_Nature_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Str_NatureBrdClick.Begin();

        }
        void Str_NatureBrdClick_Completed(object sender, EventArgs e)
        {
            Str_NatureBrdUnClick.Begin();
        }
        void Str_SpecialBrdUnClick_Completed(object sender, EventArgs e)
        {

            this.TypeID = 3;
            this.ChangeViewToAlbums(this.GamesPicID);
        }

        void Str_SpecialBrdClick_Completed(object sender, EventArgs e)
        {
            Str_SpecialBrdUnClick.Begin();
        }

        void Str_GamesBrdUnClick_Completed(object sender, EventArgs e)
        {

            this.TypeID = 4;
            this.ChangeViewToAlbums(this.GamesPicID);
        }

        void Str_GamesBrdClick_Completed(object sender, EventArgs e)
        {
            Str_GamesBrdUnClick.Begin();
        }

        void Str_EarthSpaceBrdUnClick_Completed(object sender, EventArgs e)
        {

            this.TypeID = 2;
            this.ChangeViewToAlbums(this.EarthSpaceID);
        }

        void Str_EarthSpaceBrdClick_Completed(object sender, EventArgs e)
        {
            Str_EarthSpaceBrdUnClick.Begin();
        }

        void Str_NatureBrdUnClick_Completed(object sender, EventArgs e)
        {
            this.TypeID = 1;
            this.ChangeViewToAlbums(this.NaturePicId);

        }

        private void Txt_EarthSpace_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Str_EarthSpaceBrdClick.Begin();
        }

        private void Txt_Special_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Str_SpecialBrdClick.Begin();
        }

        private void Txt_Games_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Str_GamesBrdClick.Begin();
        }

        private void Img_NatureSave_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Str_NatureSavePictureClick.Begin();
        }

        private void Img_NatureZoom_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Str_NatureZoomPictureClick.Begin();
            // TODO: Add event handler implementation here.
        }

        private void Img_NatureNext_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Str_NatureNextPictureClick.Begin();
            // TODO: Add event handler implementation here.
        }

        private void Img_NaturePictures_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Str_NaturePicPictureClick.Begin();
            // TODO: Add event handler implementation here.
        }
        public int ImgNo { get; set; }

        public int NaturePicId { get; set; }

        public int SpecialPicID { get; set; }

        public int EarthSpaceID { get; set; }

        public int GamesPicID { get; set; }

        private void Img_EarthSpacePictures_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Str_EarthSpacePicPictureClick.Begin();
            // TODO: Add event handler implementation here.
        }

        private void Img_EarthSpaceNext_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Str_EarthSpaceNextPictureClick.Begin();
            // TODO: Add event handler implementation here.
        }

        private void Img_EarthSpaceZoom_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Str_EarthSpaceZoomPictureClick.Begin();
            // TODO: Add event handler implementation here.
        }

        private void Img_EarthSpaceSave_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Str_EarthSpaceSavePictureClick.Begin();
            // TODO: Add event handler implementation here.
        }

        private void Img_SpecialSave_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Str_SpecialSavePictureClick.Begin();
        }

        private void Img_SpecialZoom_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Str_SpecialZoomPictureClick.Begin();
            // TODO: Add event handler implementation here.
        }

        private void Img_SpecialNext_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Str_SpecialNextPictureClick.Begin();
            // TODO: Add event handler implementation here.
        }

        private void Img_SpecialPictures_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Str_SpecialPicPictureClick.Begin();
            // TODO: Add event handler implementation here.
        }

        private void Img_GamesPictures_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Str_GamesPicPictureClick.Begin();
            // TODO: Add event handler implementation here.
        }

        private void Img_GamesNext_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Str_GamesNextPictureClick.Begin();
            // TODO: Add event handler implementation here.
        }

        private void Img_GamesZoom_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Str_GamesZoomPictureClick.Begin();
            // TODO: Add event handler implementation here.
        }

        private void Img_GamesSave_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Str_GamesSavePictureClick.Begin();
            // TODO: Add event handler implementation here.
        }

        private void NextPage_Click(object sender, System.EventArgs e)
        {
            Str_PageTrnsleft.Begin();
            // TODO: Add event handler implementation here.
        }

        private void btn_Previous_Click(object sender, System.EventArgs e)
        {
            Str_PageTrnsRight.Begin();
            // TODO: Add event handler implementation here.
        }

        public void ChangeViewToAlbums(int CurrentID)
        {
            if (this.TypeID != 0)
            {
                this.NavigationService.Navigate(new Uri("/Views/PictureAlbum.xaml?TypeID=" + this.TypeID + "&ID=" + CurrentID, UriKind.Relative));
            }
        }

        public int TypeID { get; set; }

        private void Img_Nature_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            Str_NatureZoomPictureClick.Begin();
        	// TODO: Add event handler implementation here.
        }

        private void Img_EarthSpace_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
        	// TODO: Add event handler implementation here.

            Str_EarthSpaceZoomPictureClick.Begin();
        }

        private void Img_Special_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            Str_SpecialZoomPictureClick.Begin();
            // TODO: Add event handler implementation here.
        }

        private void Img_Games_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            Str_GamesZoomPictureClick.Begin();
        }

        private void Thmb_Panel_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            if (Grd_PopUp_MenuPanel.Width < 470)
            {
                var width = Grd_PopUp_MenuPanel.Width;
                var change = -e.HorizontalChange;

                var Chng = width + change;
                if (Chng > 30)
                {
                    Grd_PopUp_MenuPanel.Width +=  change;
                }
            }
            else
            {
                Grd_PopUp_MenuPanel.Width = 469;
            }
          
        }

        private void Thmb_Panel_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            if (Grd_PopUp_MenuPanel.Width < 400)
            {
                ShowPopupBtnPanel.Begin();
             
            }
            else
            {
                HidePopupBtnPanel.Begin();
            }
        }

        private void Btn_Close_Image_PopUp_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            ApplicationBar.IsVisible = true;
            Str_PictureZoomPopUpCloses.Begin();
            Grd_PopUp_MenuPanel.Width = 50;

            Grd_ImageSaveStatus.Visibility = Visibility.Collapsed;
        }

        private void Btn_Save_Image_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
        

            WriteableBitmap bmp = new WriteableBitmap(480, 800);
            var source =Img_ZoomPopup.Source as BitmapImage;
            Image img = new Image();
            img.Source = source;
            img.Stretch = Stretch.Uniform;
            bmp.Render(img, new ScaleTransform() { ScaleX = 1, ScaleY = 1 });
            bmp.Invalidate();
            using (MemoryStream stream = new MemoryStream())
            {
                bmp.SaveJpeg(stream, 480, 800, 0, 100);
                if (stream.Length != 0)
                {
                    MediaLibrary ml = new MediaLibrary();
                    ml.SavePicture("PopUp" + this.TypeID + ".jpg", stream.GetBuffer());

                }
            }
            Grd_ImageSaveStatus.Visibility = Visibility.Visible;
        }

        private void Btn_AboutApp_Click(object sender, System.EventArgs e)
        {
        	// TODO: Add event handler implementation here.
            this.NavigationService.Navigate(new Uri("/Views/About_App.xaml", UriKind.Relative));
          
        }

        private void Btn_Rate_Click(object sender, System.EventArgs e)
        {
            MarketplaceReviewTask rev = new MarketplaceReviewTask();
            
            rev.Show();
        }
    }
}