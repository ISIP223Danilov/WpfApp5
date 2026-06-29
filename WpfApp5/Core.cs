using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5
{
    internal class Core
    {
        public static BarbershopDBEntities context=new BarbershopDBEntities();
        public static Haircuts haircuts = null;
        public static Masters masters = null;
    }
}
