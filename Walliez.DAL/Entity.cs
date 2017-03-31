using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walliez.DAL
{
    public class Entity
    {
        public WalliezDBContext db { get; set; }

        public Entity()
        {
            using (db = new WalliezDBContext(KeyStore.DBConnection))
            {
                if (db.DatabaseExists())
                {

                }
                else
                {
                    db.CreateDatabase();
                }
            }
        }

    }
}
