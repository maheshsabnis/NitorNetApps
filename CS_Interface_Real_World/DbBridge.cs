using CS_Interface_Real_World.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Interface_Real_World
{
    public class DbBridge
    {
        string dbProviderName;

        /// <summary>
        /// Methd to return db access so that it can be connected
        /// </summary>
        /// <returns></returns>
        public IDbAccess GetDbAccess(string dbProviderName)
        {
            IDbAccess dbAccess = null;  
            switch (dbProviderName)
            {
                case "Sql":
                    dbAccess = new SqlDbAccess();
                    break;
                case "MySql":
                    dbAccess = new MySqlDbAccess();
                    break;
                default:
                    dbAccess = null;
                    break;
            }

            return dbAccess;
        }
    }
}
