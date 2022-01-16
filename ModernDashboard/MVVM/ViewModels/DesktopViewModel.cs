
using ModernDashboard.MVVM.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace ModernDashboard.MVVM.ViewModels
{
    public class DesktopViewModel : INotifyPropertyChanged
    {
        private readonly CollectionViewSource DesktopItemsCollection;
        public ICollectionView DesktopSourceCollection => DesktopItemsCollection.View;

        public DesktopViewModel()
        {
            ObservableCollection<DesktopItems> desktopItems = new ObservableCollection<DesktopItems>
            {
                new DesktopItems { DesktopName = "File", DesktopImage = @"Assets/Images/file_icon.png" },
                new DesktopItems { DesktopName = "Music", DesktopImage = @"Assets/Images/musical_icon.png" },
                new DesktopItems { DesktopName = "Pictures", DesktopImage = @"Assets/Images/picture_icon.png" },
                new DesktopItems { DesktopName = "Analytics", DesktopImage = @"Assets/Images/analytics_icon.png" },
                new DesktopItems { DesktopName = "Webcam", DesktopImage = @"Assets/Images/webcam_icon.png" },
                new DesktopItems { DesktopName = "Printer", DesktopImage = @"Assets/Images/printer_icon.png" },
                new DesktopItems { DesktopName = "Services", DesktopImage = @"Assets/Images/services_icon.png" },
                new DesktopItems { DesktopName = "Chart", DesktopImage = @"Assets/Images/chart_icon.png" },
                new DesktopItems { DesktopName = "Film", DesktopImage = @"Assets/Images/film_icon.png" },
                new DesktopItems { DesktopName = "Alarm", DesktopImage = @"Assets/Images/alarm_icon.png" },
                new DesktopItems { DesktopName = "Headphone", DesktopImage = @"Assets/Images/headphone_icon.png" },
                new DesktopItems { DesktopName = "Password", DesktopImage = @"Assets/Images/password_icon.png" },
                new DesktopItems { DesktopName = "Calendar", DesktopImage = @"Assets/Images/calendar_icon.png" }

            };

            DesktopItemsCollection = new CollectionViewSource { Source = desktopItems };
            DesktopItemsCollection.Filter += MenuItems_Filter;

        }

        private string filterText;
        public string FilterText
        {
            get => filterText;
            set
            {
                filterText = value;
                DesktopItemsCollection.View.Refresh();
                OnPropertyChanged("FilterText");
            }
        }

        private void MenuItems_Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            DesktopItems _item = e.Item as DesktopItems;
            if (_item.DesktopName.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
