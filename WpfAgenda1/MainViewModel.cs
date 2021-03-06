using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WpfAgenda1.Model;

namespace WpfAgenda1
{
    public class MainViewModel
    {
        private const string XML_NAME = "MyFriends.xml";

        private readonly IDataLayer dataLayer;
        private readonly IOService openFileService;

        private string filter;
        private Friend selectedFriend;
        private string[] countries = { "Romania", "Germania", "SUA", "Moldova", "Bulgaria", "China", "Franta", "Italia", "Spania", "Regatul Unit", "Tarile de jos" };

        public ObservableCollection<Friend> Friends { get; set; }

        public ICollectionView FilteredFriends { get; set; }

        public Friend SelectedFriend { get => selectedFriend; set { selectedFriend = value; ((DelegateCommand)DeleteCommand).RaiseCanExecuteChanged(); } }
        public string Filter { get => filter; set { filter = value; FilteredFriends.Refresh(); } }

        public string[] Countries { get => countries.OrderBy(s => s).ToArray(); set => countries = value; }
        
        public ICommand AddCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand BrowseCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public MainViewModel(IDataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
            dataLayer.LoadFriends(XML_NAME);

            openFileService = new OpenFileDialogService();

            Friends = new ObservableCollection<Friend>(dataLayer.AllFriends);
            FilteredFriends = CollectionViewSource.GetDefaultView(Friends);

            FilteredFriends.Filter = f => string.IsNullOrEmpty(Filter) ? true : ((Friend)f).Name.StartsWith(Filter, StringComparison.InvariantCultureIgnoreCase);

            var sort1 = new SortDescription("Name", ListSortDirection.Ascending);
            var sort2 = new SortDescription("Lastname", ListSortDirection.Ascending);
            FilteredFriends.SortDescriptions.Add(sort1);
            FilteredFriends.SortDescriptions.Add(sort2);

            //SelectedFriend = Friends[0];

            AddCommand = new DelegateCommand(AddFriend);
            DeleteCommand = new DelegateCommand(DeleteFriend, o => SelectedFriend != null);
            CloseCommand = new DelegateCommand(CloseApp);
            BrowseCommand = new DelegateCommand(BrowseFiles);
            SaveCommand = new DelegateCommand(SaveData);
        }

        private void SaveData(object obj)
        {
            dataLayer.AllFriends = Friends.ToList();

            dataLayer.SaveFriends(XML_NAME);
        }

        private void BrowseFiles(object obj)
        {
            var file = openFileService.OpenFileDialog();
            if (!string.IsNullOrEmpty(file))
            {
                if (SelectedFriend != null)
                {
                    SelectedFriend.ImagePath = file;
                    FilteredFriends.Refresh();
                }
            }
        }

        private void CloseApp(object obj)
        {
            Application.Current.MainWindow.Close();
        }

        private void DeleteFriend(object obj)
        {
            if (SelectedFriend == null) return;
            Friends.Remove(SelectedFriend);
            FilteredFriends.Refresh();
        }

        private void AddFriend(object obj)
        {
            Friends.Add(new Friend { Name = string.Empty });
            FilteredFriends.Refresh();
        }
    }
}
