using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dotNet5780_03_0761_6658
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public   List<Host> hostsList { get; set; }
        private Host currentHost;
        public MainWindow()
        {
            hostsList = new List<Host>();
            InitializeComponent();
            var host= new Host()
            {
                HostName = "Tsimerman1",
                HostKey = 1,
                Units = new List<HostingUnit>()
                {
                    new HostingUnit()
                    {
                        UnitName = "צימר נוף הגליל",
                        Rooms = 3,
                        HasSwimmingPool = true,
                        AllOrders = new List<DateTime>(),
                        Uris = new List<string>
                        {
                           
                           "https://img.mako.co.il/2014/10/13/asnbsdnsn05_c.jpg",
                           "https://img.mako.co.il/2014/12/16/Achuza1_i.jpg"
                        }
                    },
                    new HostingUnit()
                    {
                        UnitName = "צימר על המדבר",
                        Rooms = 2,
                        HasSwimmingPool = false,
                        AllOrders = new List<DateTime>(),
                        Uris = new List<string>
                        {
                           "https://r-cf.bstatic.com/images/hotel/max1280x900/188/188863198.jpg",
                           "https://r-cf.bstatic.com/images/hotel/max1280x900/107/107314557.jpg",
                           "https://r-cf.bstatic.com/images/hotel/max1280x900/188/188863912.jpg"
                        }
                    },
                }
            };
            hostsList.Add(host);
           host = new Host()
            { 
                HostName = "Tsimerman2",
                HostKey = 2,
                Units = new List<HostingUnit>()
                {
                    new HostingUnit()
                    {
                        UnitName = "צימר רחש גלים",
                        Rooms = 3,
                        HasSwimmingPool = false,
                        AllOrders = new List<DateTime>(),
                        Uris = new List<string> {"https://pic.rrr.co.il/images/rahashagalim/10%20(Big).jpg",
                        "https://pic.rrr.co.il/images/rahashagalim/4%20(Big).jpg"}
                    },
                    new HostingUnit()
                    {
                        UnitName = "צימר חול המדבר",
                        Rooms = 2,
                        HasSwimmingPool = true,
                        AllOrders = new List<DateTime>(),
                        Uris = new List<string> { "http://www.maxtron.co.il/tblgalilw/2.jpg",
                        "http://www.maxtron.co.il/tblgalilw/1(5).JPG" }
                    },
                }
            };
           hostsList.Add(host);
           host =  new Host()
            {
                HostName = "Tsimerman3",
                HostKey = 3,
                Units = new List<HostingUnit>()
                {
                    new HostingUnit()
                    {
                        UnitName = "צימר חוף הים",
                        Rooms = 3,
                        HasSwimmingPool = true,
                        AllOrders = new List<DateTime>(),
                        Uris = new List<string> {"https://pic.rrr.co.il/images/biktothagefen/33%20(Big).jpg",
                        "https://pic.rrr.co.il/images/biktothagefen/28%20(Big).jpg"}
                    },
                    new HostingUnit()
                    {
                        UnitName = "צימר מדבר הנגב",
                        Rooms = 2,
                        HasSwimmingPool = false,
                        AllOrders = new List<DateTime>(),
                        Uris = new List<string> {"https://pic.rrr.co.il/images/oazis/21.jpg",
                        "https://pic.rrr.co.il/images/oazis/1.jpg"},
                    },
                }
            };
           hostsList.Add(host);
            cbHostList.ItemsSource = hostsList;
            //cbHostList.DisplayMemberPath = "HostsName";
            cbHostList.SelectedIndex = 0;
        }
        

        private void CbHostList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            InitializeHost(cbHostList.SelectedIndex);
        }

        private void InitializeHost(int index)
        {
            MainGrid.Children.RemoveRange(1, 3);
            currentHost = hostsList[index];
            UpGrid.DataContext = currentHost;
            for (int i = 0; i < currentHost.Units.Count; i++)
            {
                HostingUnitUserControl a = new HostingUnitUserControl(currentHost.Units[i]);
                MainGrid.Children.Add(a);
                Grid.SetRow(a, i + 1);
            }
        }
    }
}
