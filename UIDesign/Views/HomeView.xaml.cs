
using System.Windows;
using System.Windows.Controls;

namespace UIDesign.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();

        }


        public string strname
        {
            get { return (string)GetValue(strnameProperty); }
            set { SetValue(strnameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for strname.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty strnameProperty =
            DependencyProperty.Register("strname", typeof(string), typeof(HomeView), new PropertyMetadata("zhb metadata"));



    }
}
