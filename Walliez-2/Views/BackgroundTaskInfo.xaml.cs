using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Scheduler;
using System.ComponentModel;

namespace Walliez_2.Views
{
    public partial class BackgroundTaskInfo : PhoneApplicationPage, INotifyPropertyChanged
    {
        public BackgroundTaskInfo()
        {
            InitializeComponent();
            EvaluteForAgent();
            this.DataContext = this;
            this.NotifyAll();
        }

        #region Properties

        public PeriodicTask Task { get; set; }

        #endregion


        public void NotifyAll()
        {
            try
            {
                foreach (var prp in GetType().GetProperties())
                {
                    Notify(prp.Name);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void EvaluteForAgent()
        {
            try
            {
                string AgentName = "WalliezPeridicTaskAgent";
                PeriodicTask _Agent = ScheduledActionService.Find(AgentName) as PeriodicTask;
                if (_Agent != null)
                {
                    Task = _Agent;

                }
                else
                {
                    Task = new PeriodicTask(AgentName);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Notify(string Property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;



    }
}