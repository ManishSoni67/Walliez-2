using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walliez.DAL
{
    public class WalliezDBContext : DataContext
    {

        public WalliezDBContext(string ConnectionString)
            : base(ConnectionString)
        {


        }
        public Table<Appsettings> AppSettings
        {
            get
            {
                return GetTable<Appsettings>();
            }
        }
    }
}
