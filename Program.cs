using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz11
{
    
    internal class Program
    {

        static void Main(string[] args)
        {
            
            Sql sql = new Sql();
            sql.Connected(new Insert());
            //sql.Connected(new Select_All());

            //sql.Connected(new Insert());
        }
    }
}
