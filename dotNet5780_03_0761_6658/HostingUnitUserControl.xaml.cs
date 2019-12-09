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
    /// Interaction logic for HostingUnitUserControl.xaml
    /// </summary>
    public partial class HostingUnitUserControl : UserControl
    {
        int imageIndex;
        Viewbox vbImage;
        Image MyImage;
        private Calendar MyCalendar;
        public HostingUnit CurrentHostingUnit { get; set; }

        private string _label = "adsf";
        public String ggg
        {
            get { return _label; }
            set { _label = value; }
        }

       
        public HostingUnitUserControl(HostingUnit hostUnit)
        {
           
            vbImage = new Viewbox();
            InitializeComponent();
            this.CurrentHostingUnit = hostUnit;
            this.DataContext = this;
             
    
            
            UserControlGrid.DataContext = hostUnit;
            MyCalendar = CreateCalendar();
            vbCalendar.Child = null;
            vbCalendar.Child = MyCalendar;
            SetBlackOutDates();

            imageIndex = 0;
            vbImage.Width = 75;
            vbImage.Height = 75;
            vbImage.Stretch = Stretch.Fill;
            UserControlGrid.Children.Add(vbImage);
            Grid.SetColumn(vbImage, 2);
            Grid.SetRow(vbImage, 0);
            vbImage.MouseUp += vbImage_MouseUp;
            vbImage.MouseEnter += vbImage_MouseEnter;
            vbImage.MouseLeave += vbImage_MouseLeave;
            MyImage = CreateViewImage();
            vbImage.Child = null;
            vbImage.Child = MyImage;

        }
        private Image CreateViewImage()
        {
            Image dynamicImage = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@CurrentHostingUnit.Uris[imageIndex]);
            bitmap.EndInit();

            //Set Image.Source
            dynamicImage.Source = bitmap;

            //Add Image to Window
            return dynamicImage;
        }
        private Calendar CreateCalendar()
        {
            Calendar MonthlyCalendar = new Calendar
            {
                Name = "MonthlyCalendar",
                DisplayMode = CalendarMode.Month,
                SelectionMode = CalendarSelectionMode.SingleRange,
                IsTodayHighlighted = true
            };
            return MonthlyCalendar;
        }
        private void SetBlackOutDates()
        {
            foreach (DateTime date in CurrentHostingUnit.AllOrders)
            {
                MyCalendar.BlackoutDates.Add(new CalendarDateRange(date));
            }
        }


        private void BtOrder_Click_1(object sender, RoutedEventArgs e)
        {
            List<DateTime> myList = MyCalendar.SelectedDates.ToList();
            MyCalendar = CreateCalendar();
            vbCalendar.Child = null;
            vbCalendar.Child = MyCalendar;
            AddCurrentList(myList);
            SetBlackOutDates();
        }

        private void AddCurrentList(List<DateTime> tList)
        {
            foreach (DateTime d in tList)
            {
                CurrentHostingUnit.AllOrders.Add(d);
            }
        }

        private void vbImage_MouseLeave(object sender, MouseEventArgs e)
        {
            vbImage.Width = 75;
            vbImage.Height = 75;
        }
        private void vbImage_MouseEnter(object sender, MouseEventArgs e)
        {
            vbImage.Width = this.Width / 3;
            vbImage.Height = this.Height;
        }
        private void vbImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            vbImage.Child = null;
            imageIndex =
           (imageIndex + CurrentHostingUnit.Uris.Count - 1) % CurrentHostingUnit.Uris.Count;
            MyImage = CreateViewImage();
            vbImage.Child = MyImage;
        }
    }
}
