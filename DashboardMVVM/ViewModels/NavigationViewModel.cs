using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using DashboardMVVM.Models;

namespace DashboardMVVM.ViewModels
{
    class NavigationViewModel : INotifyPropertyChanged
    {//mainwindow viewmodel

        /// <summary>
        /// CollectionViewSource enables XAML code to set the commonly used CollectionView
        /// properties, passing these settings to the underlying view.
        /// </summary>
        private CollectionViewSource _menuItemsCollection;

        /// <summary>
        /// ICollectionView enables collections to have the functionalities of current record management,
        /// custom sorting, filtering, and grouping
        /// </summary>
        public ICollectionView SourceCollection => _menuItemsCollection.View;

        public NavigationViewModel()
        {
            //observableCollection represents a dynamic data collection that provides 
            //notifications when items get added, removed, or when the whole list is refreshed.
            ObservableCollection<MenuItems> menuItems = new ObservableCollection<MenuItems>
            {
                new MenuItems{MenuName ="Home",MenuImage=@"Assets/Home_Icon.png"},
                new MenuItems{MenuName ="Desktop",MenuImage=@"Assets/Desktop_Icon.png"},
                new MenuItems{MenuName ="Document",MenuImage=@"Assets/Document_Icon.png"},
                new MenuItems{MenuName ="Download",MenuImage=@"Assets/Download_Icon.png"},
                new MenuItems{MenuName ="Picture",MenuImage=@"Assets/Images_Icon.png"},
                new MenuItems{MenuName ="Music",MenuImage=@"Assets/Music_Icon.png"},
                new MenuItems{MenuName ="Movie",MenuImage=@"Assets/Movies_Icon.png"},
                new MenuItems{MenuName ="Trash",MenuImage=@"Assets/Trash_Icon.png"}
            };

            //menuItems.Add(new MenuItems { MenuName = "zhb", MenuImage=@"Assets/Movies_Icon.png" });

            _menuItemsCollection = new CollectionViewSource { Source = menuItems };
            _menuItemsCollection.Filter+=MenuItems_Filter;

            //set Startup page
            SelectedViewModel = new StartupViewModel();
        }

        //Implement interface member for InotifyPropertyChanged.
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }

        //Text Serach Filter.
        private string filterText ="";
        public string FilterText
        {
            get => filterText;
            set
            {
                filterText = value;
                _menuItemsCollection.View.Refresh();
                OnPropertyChanged(filterText);
            }
        }

        private void MenuItems_Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted= true;
                return;
            }

            MenuItems _item = e.Item as MenuItems;
            if (_item.MenuName.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        //Select ViewModel
        private object _selectedViewModel;

        public object SelectedViewModel
        {
            get { return _selectedViewModel; }
            set 
            { 
                _selectedViewModel = value; 
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        //Switch Views
        public void SwitchViews(object para)
        {
            switch (para)
            {
                case "Home":
                    SelectedViewModel = new HomeViewModel();
                    break;
                case "Desktop":
                    SelectedViewModel = new DesktopViewModel();
                    break;
                case "Document":
                    SelectedViewModel = new DocumentViewModel();
                    break;
                case "Download":
                    SelectedViewModel = new DownloadViewModel();
                    break;
                case "Picture":
                    SelectedViewModel = new PictureViewModel();
                    break;
                case "Music":
                    SelectedViewModel = new MusicViewModel();
                    break;
                case "Movie":
                    SelectedViewModel = new MovieViewModel();
                    break;
                case "Trash":
                    SelectedViewModel = new TrashViewModel();
                    break;
                default:
                    SelectedViewModel = new HomeViewModel();
                    break;
            }
        }

        //Menu Button Command
        private ICommand _menuCommand;
        public ICommand MenuCommand
        {
            get
            {
                if( _menuCommand == null )
                {
                    _menuCommand = new RelayCommands(para =>SwitchViews(para));
                }
                return _menuCommand;
            }
        }

        //Show PC View
        public void PCView(object o)
        {
            SelectedViewModel = new PCViewModel();
        }

        public void PCView()
        {
            SelectedViewModel = new PCViewModel();
        }

        //This PC button Command
        private ICommand _pcCommand;
        public ICommand PCReviewCommand
        {
            get
            {
                if(_pcCommand == null)
                {
                    //System.Action<object> action = new System.Action<object>(PCView);

                    _pcCommand = new RelayCommands(para=>PCView(para));
                }
                return _pcCommand;
            }
        }

        // Show Home View
        private void ShowHome()
        {
            SelectedViewModel = new HomeViewModel();
        }

        //Back button Home
        private ICommand _backHomeCommand;
        public ICommand BackHomeCommand
        {
            get
            {
                if(_backHomeCommand == null)
                {
                    _backHomeCommand = new RelayCommands(para=> ShowHome());
                }
                return _backHomeCommand;
            }
        }

        //Close App
        public void CloseApp(object obj)
        { 
            MainWindow win = obj as MainWindow;
            win.Close();
        }

        private ICommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if(_closeCommand == null)
                {
                    _closeCommand = new RelayCommands(para=>CloseApp(para));
                }
                return _closeCommand;
            }
        }

    }
}
