using System.Diagnostics;
using System.Windows;
using Microsoft.Phone.Scheduler;
using Windows.Phone.System.UserProfile;
using System;
using System.Linq;
using Microsoft.Phone.Shell;
using Walliez.DAL;

namespace Walliez.BackgroundTasks
{
    public class ScheduledAgent : ScheduledTaskAgent
    {
        /// <remarks>
        /// ScheduledAgent constructor, initializes the UnhandledException handler
        /// </remarks>
        static ScheduledAgent()
        {
            // Subscribe to the managed exception handler
            Deployment.Current.Dispatcher.BeginInvoke(delegate
            {
                Application.Current.UnhandledException += UnhandledException;
            });

            // ImageNo = 1;
        }

        /// Code to execute on Unhandled Exceptions
        private static void UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                Debugger.Break();
            }
        }

        public static int ImageNo { get; set; }


        /// <summary>
        /// Agent that runs a scheduled task
        /// </summary>
        /// <param name="task">
        /// The invoked task
        /// </param>
        /// <remarks>
        /// This method is called when a periodic or resource intensive task is invoked
        /// </remarks>
        protected override void OnInvoke(ScheduledTask task)
        {
            var AppSetting = this.GetLatestAppsetting();
            string ImageName = "/Wallpapers/" + AppSetting.Type + "/Image (" + AppSetting.ImageID + ").jpg";
            if ((LockScreenManager.IsProvidedByCurrentApplication))
            {
                ShellToast toast = new ShellToast();
                toast.Content = "Wallpaper Changed Successfully";
                toast.Title = "Walliez - 2";
                try
                {

                    LockScreen.SetImageUri(new Uri("ms-appx://" + ImageName));
                    ChangeLockcreenParts(AppSetting, toast);
                }
                catch (Exception e)
                {
                    toast.Content = "ID:  " + AppSetting.ImageID + " Err: " + e.Message;
                    toast.Show();
                    ///throw e;
                }
                ScheduledActionService.LaunchForTest(task.Name, TimeSpan.FromSeconds(30));
            }
            else
            {
                NotifyComplete();

            }



            NotifyComplete();
        }

        public void ChangeLockcreenParts(Appsettings _AppSet, ShellToast _Toast)
        {
            try
            {
                var ImagePath = "Wallpapers/" + _AppSet.Type + "/Image (" + _AppSet.ImageID + ").jpg";
                var SmallImage = "ApplicationIcon.png";
                var Tile = ShellTile.ActiveTiles.FirstOrDefault();
                Tile.Update(new FlipTileData()
                {
                    Title = "Walliez-2",
                    BackTitle = ImagePath,
                    BackContent = ImagePath,
                    Count = _AppSet.ImageID,
                    WideBackContent = ImagePath,
                    BackBackgroundImage = new Uri(@ImagePath, UriKind.Relative),
                    BackgroundImage = new Uri(@ImagePath, UriKind.Relative),
                    SmallBackgroundImage = new Uri(@SmallImage, UriKind.Relative),
                    WideBackgroundImage = new Uri(@ImagePath, UriKind.Relative),
                    WideBackBackgroundImage = new Uri(@ImagePath, UriKind.Relative)

                });
            }
            catch (Exception e)
            {
                _Toast.Content = "ID:  " + _AppSet.ImageID + " Err: " + e.Message;
                _Toast.Show();
            }

        }


        public Appsettings GetLatestAppsetting()
        {
            try
            {
                using (var db = new WalliezDBContext(KeyStore.DBConnection))
                {
                    var Limit = 50;
                    var obj = db.AppSettings.Select(x => x).ToList().LastOrDefault();
                    obj.ImageID++;
                    if (obj.Type == KeyStore.SpecialKey)
                        Limit = 93;
                    if (obj.ImageID > Limit)
                    {
                        obj.ImageID = 1;
                    }
                    db.SubmitChanges();
                    return obj;
                }

            }
            catch (Exception e)
            {

                return new Appsettings() { ImageID = 1, Type = "Games" };
            }
        }

    }
}