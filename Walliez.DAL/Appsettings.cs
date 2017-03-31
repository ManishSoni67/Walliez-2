using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Walliez.DAL
{
    [Table]
    public class Appsettings : Entity
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }

        [Column]
        public string ImagePath { get; set; }

        [Column]
        public string Type { get; set; }

        [Column]
        public int ImageID { get; set; }


    }
}
