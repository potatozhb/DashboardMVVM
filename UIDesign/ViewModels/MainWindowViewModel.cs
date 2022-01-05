using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using UIDesign;
using UIDesign.Models;
using UIDesign.Views;

namespace UIDesign.ViewModels
{
    public class MainWindowViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }

        /// <summary>
        /// use datatemplates to apply view on viewmodel object displayed in UI.
        /// </summary>
        private object _currentview = new CurrencyViewModel();
        public object MyCurrencyView
        {
            get { return _currentview; }
            set
            {
                _currentview = value;
                OnPropertyChanged(nameof(MyCurrencyView));
            }
        }

        private ICommand _closewindow;
        public ICommand CloseWindow
        {
            get 
            {
                if(_closewindow == null)
                {
                    _closewindow = new RelayCommands(para => ClosedWindow(para));
                }

                return _closewindow; 
            }
        }

        public void ClosedWindow(object obj)
        {
            MainWindow win = (MainWindow)obj;
            win.Close();
        }

        private ICommand _loadcurrencypage;
        public ICommand Loadcurrencypage
        {
            get
            {
                if(_loadcurrencypage == null)
                {
                    _loadcurrencypage= new RelayCommands(para =>LoadCurrency(para));
                }

                return _loadcurrencypage;
            }
        }

        private void LoadCurrency(object obj)
        {
            
            MyCurrencyView = new CurrencyView();
        }


        private ICommand _gohome;
        public ICommand GoHome
        {
            get
            {
                if (_gohome == null)
                {
                    _gohome= new RelayCommands(para => GoHomePage());
                }

                return _gohome;
            }
        }

        private void GoHomePage()
        {

            MyCurrencyView = new HomeView();
        }
    }
}
