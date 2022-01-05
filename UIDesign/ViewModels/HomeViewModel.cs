using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UIDesign.ViewModels
{
    internal class HomeViewModel:DependencyObject
    {
        public Func<LiveCharts.ChartPoint, string> PointLabel { get; set; }

        public HomeViewModel()
        {
            PointLabel = chartpoint => String.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);

            //strnamevm = "dependency property VM";
        }

        public int MyProperty { get; set; }

        public string strnamevm
        {
            get { return (string)GetValue(strnamevmProperty); }
            set { SetValue(strnamevmProperty, value); }
        }

        // Using a DependencyProperty as the backing store for strname.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty strnamevmProperty =
            DependencyProperty.Register("strnamevm", typeof(string), typeof(HomeViewModel), new PropertyMetadata("zhb metadata"));


    }
}
