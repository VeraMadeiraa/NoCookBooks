using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCookBooks.Repositories.Implementations
{
    public class BaseRepository
    {
        protected static SqlConnection Connection;

        static BaseRepository()
        {
            Connection = new SqlConnection(@"Server=DESKTOP-3V0O26V;Database=NoCookBooksDB;Trusted_Connection=True;");
        }
    }
}
