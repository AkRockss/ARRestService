using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARRestService.Models
{
    public class Secrets
    {
        //Azure
        //public static readonly string ConnectionString = "Server=tcp:chald.database.windows.net,1433;Initial Catalog=ArAppDB;Persist Security Info=False;User ID=chald;Password=Hald20280013;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //LOCAL
        public static readonly string ConnectionString = "Data Source=DESKTOP-E64SFNV/SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
    
    