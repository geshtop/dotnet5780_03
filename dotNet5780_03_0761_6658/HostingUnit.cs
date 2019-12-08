using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_03_0761_6658
{
    public class HostingUnit
    {
        public string UnitName;
        public int Rooms;
        public bool IsSwimingPool;
        public List<DateTime> AllOrders { get; set; }
        public List<string> Uris { get; set; }
    }
}
