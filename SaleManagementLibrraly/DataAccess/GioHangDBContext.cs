using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManagementLibrraly.DataAccess
{
    public class GioHangDBContext : BaseDAL
    {
        private static GioHangDBContext instance = null;
        private static readonly object instanceLock = new object();
        private GioHangDBContext() { }
        public static GioHangDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new GioHangDBContext();
                    }
                    return instance;
                }
            }
        }
    }
}
