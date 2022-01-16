using ModernDashboard.Core;
using ModernDashboard.MVVM.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace ModernDashboard.MVVM.ViewModels
{
    public class NavigationViewModel : INotifyPropertyChanged
    {
        // CollectionViewSource enables XAML code to set the commonly used CollectionView properties
        // passing these settings to the underlying view
        private CollectionViewSource MenuItemsCollection;


        // ICollectionView enables collections to have the functionalities of current record management
        // custom sorting, filtering and grouping
        public ICollectionView SourceCollection => MenuItemsCollection.View;

        public NavigationViewModel()
        {
            // ObeservableCollection represents a dynamic data collection that provides notifications when items
            // get added , removed, or when the whole list is refreshed
            ObservableCollection<MenuItems> menuItems = new ObservableCollection<MenuItems>
            {
                new MenuItems{MenuName = "Home", MenuImage = @"Assets/Images/Home_Icon.png"},
                new MenuItems{MenuName = "Desktop", MenuImage = @"Assets/Images/Desktop_Icon.png"},
                new MenuItems{MenuName = "Documents", MenuImage = @"Assets/Images/Document_Icon.png"},
                new MenuItems{MenuName = "Downloads", MenuImage = @"Assets/Images/Download_Icon.png"},
                new MenuItems{MenuName = "Pictures", MenuImage = @"Assets/Images/Images_Icon.png"},
                new MenuItems{MenuName = "Music", MenuImage = @"Assets/Images/Music_Icon.png"},
                new MenuItems{MenuName = "Movies", MenuImage = @"Assets/Images/Movies_Icon.png"},
                new MenuItems{MenuName = "Trash", MenuImage = @"Assets/Images/Trash_Icon.png"},
            };


            MenuItemsCollection = new CollectionViewSource { Source = menuItems };
            MenuItemsCollection.Filter += MenuItems_Filter;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }


        // Text Search Filter
        private string _filterText;
        public string FilterText
        {
            get => _filterText;
            set
            {
                _filterText = value;
                MenuItemsCollection.View.Refresh();
                OnPropertyChanged(nameof(FilterText));
            }
        }


        private void MenuItems_Filter(object sender,FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
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



        // Select ViewModel
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

        public void SwitchViews(object parameter)
        {
            switch (parameter)
            {
                case "Desktop":
                    SelectedViewModel = new DesktopViewModel();
                    break;
                default:
                    break;
            }
        }

        // Show PC View
        public void PCView()
        {
            SelectedViewModel = new PCViewModel();
        }


        private ICommand _pccommand;
        public ICommand ThisPCCommand
        {
            get
            {
                if(_pccommand == null)
                {
                    _pccommand = new RelayCommand(param => PCView());
                }
                return _pccommand;
            }
        }



        // Show Home View
        private void ShowHome()
        {
            SelectedViewModel = new HomeViewModel();
        }

        private ICommand _backHomeCommand;
        public ICommand BackHomeCommand
        {
            get
            {
                if(_backHomeCommand == null)
                {
                    _backHomeCommand = new RelayCommand(p => ShowHome());
                }
                return _backHomeCommand;
            }
        }

        // Close App
        public void CloseApp(object obj)
        {
            MainWindow win = obj as MainWindow;
            win.Close();
        }

        private ICommand _closeAppCommand;
        public ICommand CloseAppCommand
        {
            get
            {
                if(_closeAppCommand == null)
                {
                    _closeAppCommand = new RelayCommand(p => CloseApp(p));
                }
                return _closeAppCommand;
            }
        }

    }
}
