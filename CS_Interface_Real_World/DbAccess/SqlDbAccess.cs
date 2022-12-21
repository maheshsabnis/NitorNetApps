using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Interface_Real_World.DbAccess
{
    public class SqlDbAccess : IDbAccess
    {
        void IDbAccess.GetDbConnection()
        {
            Console.WriteLine("Connected to Sql Server");
        }
    }
}
