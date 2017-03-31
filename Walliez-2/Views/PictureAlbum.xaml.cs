using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Threading;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using Walliez.Model;
using System.Windows.Media;
using System.IO;
using Windows.Phone.System.UserProfile;
using Microsoft.Xna.Framework.Media;
using Microsoft.Phone.Scheduler;
using Windows.Storage;
using Windows.System;
using Walliez.DAL;

namespace Walliez_2
{
    public partial class PictureAlbum : PhoneApplicationPage
    {
        public PictureAlbumVM Model
        {
            get
            {
                return (PictureAlbumVM)this.DataContext;
            }
        }
        // Thread fun;
        BackgroundWorker bc = new BackgroundWorker();

        public PictureAlbum()
        {
            InitializeComponent();
            // fun = new Thread(LoadAllPivotItems); 
            this.StrPageStartUp.Completed += StrPageStartUp_Completed;
            this.Loaded += PictureAlbum_Loaded;
            this.BackKeyPress += PictureAlbum_BackKeyPress;
            this.Model.ImageLoaded += Model_ImageLoaded;
            Str_ImageSaved.Completed += Str_ImageSaved_Completed;
        }

        void Str_ImageSaved_Completed(object sender, EventArgs e)
        {
            Str_ImageSavedHide.Begin();
        }

        void StrPageStartUp_Completed(object sender, EventArgs e)
        {

        }

        void Model_ImageLoaded(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(() => LoadAllPivotItems());
            Dispatcher.BeginInvoke(() => SelectItem());
        }

        public void LoadAllPivotItems()
        {

            //foreach (var item in Model.AllPictures)
            //{
            //    PivotItem pvt = new PivotItem();
            //    pvt.Name = item.ID.ToString();
            //    pvt.Style = PhotoAlbum.Resources["PivotPictureStyle"] as Style;
            //    pvt.ContentTemplate = PhotoAlbum.Resources["PictureTemplate"] as DataTemplate;
            //    pvt.Content = item;
            //    if (!(PvtAlbums.Items.OfType<PivotItem>().Contains(pvt)))
            //    {
            //        PvtAlbums.Items.Add(pvt);
            //    }
            //}
            int i = 1;
            foreach (var pvt in PvtAlbums.Items.OfType<PivotItem>())
            {
                var item = Model.AllPictures.SingleOrDefault(x => x.ID == i);
                if (item != null)
                {
                    pvt.Name = item.ID.ToString();
                    //pvt.Style = PhotoAlbum.Resources["PivotPictureStyle"] as Style;
                    //pvt.ContentTemplate = PhotoAlbum.Resources["PictureTemplate"] as DataTemplate;
                    pvt.Content = item;
                }
                ++i;
            }
        }

        public void SelectItem()
        {
            Model.IsBusy = false;
            if (this.CurrentID != 0)
            {
                var pvt = PvtAlbums.Items.OfType<PivotItem>().SingleOrDefault(x => x.Name == this.CurrentID.ToString());
                if (pvt != null)
                {
                    PvtAlbums.SelectedItem = pvt;
                }
            }
        }
        void PictureAlbum_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.StrPageCloses.Begin();
        }
        void PictureAlbum_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.CurrentID = int.Parse(NavigationContext.QueryString["ID"]);
                this.TypeID = int.Parse(NavigationContext.QueryString["TypeID"]);
                this.Model.TypeID = this.TypeID;
                this.Model.CurrentID = this.CurrentID;
                LoadAllImages();
                //Dispatcher.BeginInvoke(() => this.Model.GetAllImages());
                //  Model.GetImage();
            }
            catch
            {

            }

            this.StrPageStartUp.Begin();
        }

        private void LoadAllImages()
        {
            Model.IsBusy = true;
            bc = new BackgroundWorker();
            bc.WorkerReportsProgress = true;
            bc.WorkerSupportsCancellation = true;
            bc.DoWork += bc_DoWork;
            bc.RunWorkerCompleted += bc_RunWorkerCompleted;
            bc.ProgressChanged += bc_ProgressChanged;
            bc.RunWorkerAsync(Model);

        }

        void bc_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prg_Operation.Value = e.ProgressPercentage;
        }

        void bc_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Model.IsBusy = false;
        }

        void bc_DoWork(object sender, DoWorkEventArgs e)
        {
            Dispatcher.BeginInvoke(() => Model.GetAllImages());
            bc.ReportProgress(50);
        }

        public int TypeID { get; set; }
        public int CurrentID { get; set; }

        private void Btn_SaveImages_Click(object sender, System.EventArgs e)
        {
            // TODO: Add event handler implementation here.
            var ImageSource = (PvtAlbums.SelectedItem as PivotItem).Content;
            if (ImageSource != null)
            {
                WriteableBitmap wbmp = new WriteableBitmap(480, 800);
                Image img = new Image();
                img.Source = (ImageSource as Pictures).ImageSource;
                wbmp.Render(img, new ScaleTransform() { ScaleX = 1, ScaleY = 1 });
                wbmp.Invalidate();

                using (MemoryStream str = new MemoryStream())
                {
                    wbmp.SaveJpeg(str, 480, 800, 0, 100);
                    MediaLibrary ml = new MediaLibrary();
                    ml.SavePicture(this.TypeID + ".jpg", str.GetBuffer());
                }

                this.Str_ImageSaved.Begin();

            }

        }



        private void Btn_Back_Click(object sender, System.EventArgs e)
        {
            // TODO: Add event handler implementation here.

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void PvtAlbums_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // TODO: Add event handler implementation here.
        }

        private void btn_SetAsLocakScreenWall_Click(object sender, System.EventArgs e)
        {
            var Img = (PvtAlbums.SelectedItem as PivotItem).Content;
            if (Img != null)
            {
                ChangeLocScreen(Img as Pictures);
            }
        }


        public void ChangeWall(Pictures Pic)
        {
            try
            {
                StartPeriodicAgent();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public async void ChangeLocScreen(Pictures Pic)
        {
            try
            {
                if (LockScreenManager.IsProvidedByCurrentApplication)
                {
                    // Uri UriImage = new Uri("ms-appx://" + Pic.FilePath, UriKind.RelativeOrAbsolute);
                    //LockScreen.SetImageUri(UriImage);

                    UpdateAppSettings(Pic);
                    StartPeriodicAgent();

                }
                else
                {
                    //  var res = await Launcher.LaunchUriAsync(new Uri("ms-settings-lock:"));

                    await LockScreenManager.RequestAccessAsync();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }


        private void StartPeriodicAgent()
        {
            // is old task running, remove it
            var periodicTaskName = "WalliezPeridicTaskAgent";
            PeriodicTask periodicTask = ScheduledActionService.Find(periodicTaskName) as PeriodicTask;
            if (periodicTask != null)
            {
                try
                {

                    // NavigateToBackgroundTaskInfo();
                    ScheduledActionService.Remove(periodicTaskName);
                }
                catch (Exception)
                {
                }
            }
            // create a new task
            periodicTask = new PeriodicTask(periodicTaskName);
            // load description from localized strings
            periodicTask.Description = "This is Lockscreen image provider Walliez";
            // set expiration days
            periodicTask.ExpirationTime = DateTime.Now.AddDays(14);

            try
            {
                // add this to scheduled action service
                ScheduledActionService.Add(periodicTask);
                MessageBox.Show("The Task is Added Successfully");
                // debug, so run in every 30 secs
                ScheduledActionService.LaunchForTest(periodicTaskName, TimeSpan.FromSeconds(30));
#if(Debug_Agent)
                ScheduledActionService.LaunchForTest(periodicTaskName, TimeSpan.FromSeconds(30));     
                System.Diagnostics.Debug.WriteLine("Periodic task is started: " + periodicTaskName);
#endif
            }
            catch (InvalidOperationException exception)
            {
                if (exception.Message.Contains("BNS Error: The action is disabled"))
                {
                    // load error text from localized strings
                    MessageBox.Show("Background agents for this application have been disabled by the user.");
                }
                if (exception.Message.Contains("BNS Error: The maximum number of ScheduledActions of this type have already been added."))
                {
                    // No user action required. The system prompts the user when the hard limit of periodic tasks has been reached.
                }
            }
            catch (SchedulerServiceException)
            {
                // No user action required.
            }
        }

        public void UpdateAppSettings(Pictures Pic)
        {
            try
            {
                Appsettings App = new Appsettings()
                {
                    ImageID = Pic.ID,
                    Type = Model.Label,
                    ImagePath = Pic.FilePath,

                };
                using (var db = new WalliezDBContext(KeyStore.DBConnection))
                {
                    db.AppSettings.InsertOnSubmit(App);
                    db.SubmitChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void btn_AddLocScreen_Click(object sender, System.EventArgs e)
        {
            var Img = (PvtAlbums.SelectedItem as PivotItem).Content;
            if (Img != null)
            {
                SetPictureAsLocScreen(Img as Pictures);
            }
        }

        public void NavigateToBackgroundTaskInfo()
        {
            try
            {
                NavigationService.Navigate(new Uri("/Views/BackgroundTaskInfo.xaml", UriKind.Relative));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public async void SetPictureAsLocScreen(Pictures Pic)
        {
            try
            {
                if (LockScreenManager.IsProvidedByCurrentApplication)
                {
                    UpdateAppSettings(Pic);
                    Uri UriImage = new Uri("ms-appx://" + Pic.FilePath, UriKind.RelativeOrAbsolute);
                    LockScreen.SetImageUri(UriImage);
                    MessageBox.Show("Image Set Succesfully");

                }
                else
                {
                    var res = await Launcher.LaunchUriAsync(new Uri("ms-settings-lock:"));
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}