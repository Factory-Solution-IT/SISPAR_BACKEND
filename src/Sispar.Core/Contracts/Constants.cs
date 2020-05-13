using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sispar.Domain.Contracts
{
    public class Constants
    {
        public static string CONNECTION_STRING_PRODUCAO =
           //@"Server=tcp:flpsnomssql.database.windows.net,1433;Initial Catalog=sispardb;Persist Security Info=False;User ID=flpsno;Password=@Metal001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
           // @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Eng.Milton Honji\source\repos\sisparweb\Sispar.UI.WebApp\App_Data\sisparweb_mvc.mdf;Integrated Security=True";
           @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Eng.Milton Honji\source\repos\sisparweb\Sispar.UI.WebApp\App_Data\sisparweb_mvc_db.mdf;Integrated Security=True";
    }
}
